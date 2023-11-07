using Microsoft.EntityFrameworkCore;
using Restaraunt.Domain;
using Restaraunt.Domain.Entities;
using Restaraunt.Persistence;

namespace Restaurant.Tests.Common.Drinks
{
	public class DrinksContextFactory
	{
		public static Random rnd = new Random();

		public static Guid DrinkIdForDelete = new Guid("D2A3CA19-B658-4C19-93E8-6B5843288CE0");
		public static Guid DrinkIdForUpdate = new Guid("D550C2C8-BB04-481A-90D8-FF70A98C181F");
		public static ProductDbContext Create()
		{
			var options = new DbContextOptionsBuilder<ProductDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;

			var context = new ProductDbContext(options);
			context.Database.EnsureCreated();
			context.Drinks.AddRange(
				new Drink()
				{
					Id = new Guid("DA5BF5A1-0C35-4309-BD86-338169E87ED7"),
					Description = "Drink1",
					Name = "Drink1",
					Price = 3.5,
					Size = 500,
					IsCarbonated = true,
				},
				new Drink()
				{
					Id = new Guid("BA5D1EFF-B4AA-46C5-8B44-24882F7B1336"),
					Description = "Test2",
					Name = "Drink2",
					Price = 2.5,
					IsCarbonated = true,
					Size = 750
				},
				new Drink()
				{
					Id = DrinkIdForDelete,
					Description = "Test3",
					Name = "Drink3",
					Price = 2.2,
					Size = 600,
					IsCarbonated = true,
				},
				new Drink()
				{
					Id = DrinkIdForUpdate,
					Description = "Test4",
					Name = "Drink4",
					Price = 2.9,
					Size = 750,
					IsCarbonated = true,
				}
			);

			context.SaveChanges();
			return context;
		}

		public static void Destroy(ProductDbContext context)
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}
	}
}
