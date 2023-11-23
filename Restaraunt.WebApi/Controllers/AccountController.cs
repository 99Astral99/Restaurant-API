using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.Extensions;
using Restaraunt.Domain.Entities.Identity;
using Restaraunt.WebApi.Models.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Restaraunt.WebApi.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	public class AccountController : BaseController
	{
		private readonly UserManager<User> _userManager;
		private readonly IConfiguration _configuration;

		public AccountController(UserManager<User> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_configuration = configuration;
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

		[Authorize(Roles = "Administrator")]
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

