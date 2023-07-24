using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Restaraunt.Application.Extensions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Restaraunt.Application.Services
{
	public class TokenService : ITokenService
	{
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string CreateToken(User user, List<IdentityRole<Guid>> roles)
		{
			var token = user
				.CreateClaims(roles)
				.CreateJwtToken(_configuration);
			var tokenHandler = new JwtSecurityTokenHandler();

			return tokenHandler.WriteToken(token);
		}
	}
}
