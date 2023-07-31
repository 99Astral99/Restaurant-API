using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Extensions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;
using Restaraunt.Domain.Entities.Identity;
using Restaraunt.Persistence;
using Restaraunt.WebApi.Models.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Restaraunt.WebApi.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : BaseController
	{
		private readonly UserManager<User> _userManager;
		private readonly ProductDbContext _context;
		private readonly ITokenService _tokenService;
		private readonly IConfiguration _configuration;

		public AccountController(UserManager<User> userManager, ProductDbContext context,
			ITokenService tokenService, IConfiguration configuration)
		{
			_userManager = userManager;
			_context = context;
			_tokenService = tokenService;
			_configuration = configuration;
		}

		[HttpPost("login")]
		public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var managedUser = await _userManager.FindByEmailAsync(request.Email);

			if (managedUser == null)
			{
				return BadRequest("Bad credentials");
			}

			var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

			if (!isPasswordValid)
			{
				return BadRequest("Bad credentials");
			}

			var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

			if (user is null)
				return Unauthorized();

			var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
			var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

			var accessToken = _tokenService.CreateToken(user, roles);
			user.RefreshToken = _configuration.GenerateRefreshToken();
			user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

			await _context.SaveChangesAsync();

			return Ok(new AuthResponse
			{
				Username = user.UserName!,
				Email = user.Email!,
				Token = accessToken,
				RefreshToken = user.RefreshToken
			});
		}

		[HttpPost("register")]
		public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
		{
			if (!ModelState.IsValid) return BadRequest(request);

			var user = new User
			{
				Email = request.Email,
				UserName = request.UserName
			};
			var result = await _userManager.CreateAsync(user, request.Password);

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}

			if (!result.Succeeded) return BadRequest(request);

			var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

			if (findUser == null) throw new Exception($"User {request.Email} not found");

			var cart = new Cart() { UserId = findUser.Id };
			await _context.Carts.AddAsync(cart);

			await _userManager.AddToRoleAsync(findUser, RoleConsts.Customer);

			return await Login(new AuthRequest
			{
				Email = request.Email,
				Password = request.Password
			});
		}

		[HttpPost]
		[Route("refresh-token")]
		public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
		{
			if (tokenModel is null)
			{
				return BadRequest("Invalid client request");
			}

			var accessToken = tokenModel.AccessToken;
			var refreshToken = tokenModel.RefreshToken;
			var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

			if (principal == null)
			{
				return BadRequest("Invalid access token or refresh token");
			}

			var username = principal.Identity!.Name;
			var user = await _userManager.FindByNameAsync(username!);

			if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
			{
				return BadRequest("Invalid access token or refresh token");
			}

			var newAccessToken = _configuration.CreateNewToken(principal.Claims.ToList());
			var newRefreshToken = _configuration.GenerateRefreshToken();

			user.RefreshToken = newRefreshToken;
			await _userManager.UpdateAsync(user);

			return new ObjectResult(new
			{
				accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
				refreshToken = newRefreshToken
			});
		}

		[Authorize]
		[HttpPost]
		[Route("revoke/{username}")]
		public async Task<IActionResult> Revoke(string username)
		{
			var user = await _userManager.FindByNameAsync(username);
			if (user == null) return BadRequest("Invalid user name");

			user.RefreshToken = null;
			await _userManager.UpdateAsync(user);

			return Ok();
		}

		[Authorize]
		[HttpPost]
		[Route("revoke-all")]
		public async Task<IActionResult> RevokeAll()
		{
			var users = _userManager.Users.ToList();
			foreach (var user in users)
			{
				user.RefreshToken = null;
				await _userManager.UpdateAsync(user);
			}

			return Ok();
		}
	}
}

