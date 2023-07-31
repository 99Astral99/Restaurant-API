using Microsoft.AspNetCore.Identity;

namespace Restaraunt.Domain.Entities.Identity
{
	public class User : IdentityUser<Guid>
	{
		public string? RefreshToken { get; set; }
		public Cart Cart { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
	}
}
