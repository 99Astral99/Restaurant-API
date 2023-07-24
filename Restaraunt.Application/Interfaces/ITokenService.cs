using Microsoft.AspNetCore.Identity;
using Restaraunt.Domain.Entities.Identity;

namespace Restaraunt.Application.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(User user, List<IdentityRole<Guid>> role);
	}
}
