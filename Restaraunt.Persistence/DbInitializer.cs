using Microsoft.EntityFrameworkCore;

namespace Restaraunt.Persistence
{
	public class DbInitializer
	{
		public static void Initialize(ProductDbContext context)
		{
			context.Database.Migrate();
		}
	}
}
