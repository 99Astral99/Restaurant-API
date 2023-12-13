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

namespace Restaraunt.WebApi.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	public class UserController : BaseController
	{
		private readonly UserManager<User> _userManager;
		private readonly ProductDbContext _context;
		private readonly ITokenService _tokenService;
		private readonly IConfiguration _configuration;

		public UserController(UserManager<User> userManager, ProductDbContext context,
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
	}
}
