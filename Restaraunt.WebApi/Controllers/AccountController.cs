using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.Extensions;
using Restaraunt.Domain.Entities.Identity;
using Restaraunt.WebApi.Models.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Restaraunt.WebApi.Controllers
{
	[Authorize]
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

		/// <summary>
		/// Refreshes the JWT token
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /account/refresh-token
		/// {
		///	  AccessToken: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI1ZGE5ZTdmOS1iOTQ0LTQ0MWItOTJkOC04NDM5YmQ1NDQwMTEiLCJpYXQiOiIxMi8xOC8yMDIzIDExOjA3OjAzIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiI5NzllMDNlOC0yNDY1LTQ2MTktYTM0My00NTdlYmY1NjU5N2QiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW5Hb2RpIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiYWRtaW5pc3RyYXRvckBleGFtcGxlLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzAyODk3NjgzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MTIzIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzEyMyJ9.ic-InQcbP32UTznOHcuuepcKeEqQycS9tupmIs5R95w",
		///	  RefreshToken: "otGfQ42xyIh5O3fNepq8I4tkXofBU1xwjI2lltbAScvUvRHckQnq/VXLiyBXYkMQpE/bj73TzbgIe8tDVYakNw=="
		/// }
		/// </remarks>
		/// <paramref name="tokenModel">TokenModel object</paramref>
		/// <returns>Returns new JWT Token (int)</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised with "Admin" role </response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

		/// <summary>
		/// Revokes JWT token
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /account/revoke/username
		/// </remarks>
		/// <paramref name="username">Username</paramref>
		/// <returns>Returns Ok</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised with "Admin" role </response>
		[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
		[HttpPost]
		[Route("revoke/{username}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> Revoke(string username)
		{
			var user = await _userManager.FindByNameAsync(username);
			if (user == null) return BadRequest("Invalid user name");

			user.RefreshToken = null;
			await _userManager.UpdateAsync(user);

			return Ok();
		}

		/// <summary>
		/// Revokes all JWT tokens
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /account/revoke-all/username
		/// </remarks>
		/// <returns>Returns Ok</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised with "Admin" role </response>
		[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
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

