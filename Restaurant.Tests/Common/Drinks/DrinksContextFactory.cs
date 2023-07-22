using Microsoft.EntityFrameworkCore;
using Restaraunt.Domain;
using Restaraunt.Domain.Entities;
using Restaraunt.Persistence;

namespace Restaurant.Tests.Common.Drinks
{
	public class DrinksContextFactory
	{
		public static Random rnd = new Random();

		public static int DrinkIdForDelete = rnd.Next(5, 100);
		public static int DrinkIdForUpdate = rnd.Next(5, 100);
		public static ProductDbContext Create()
		{
			var options = new DbContextOptionsBuilder<ProductDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;

			var context = new ProductDbContext(options);
			context.Database.EnsureCreated();
			context.Drinks.AddRange(
				//new Drink()
				//{
				//	Id = 1,
				//	Description = "Drink1",
				//	Name = "Drink1",
				//	Price = 3.5,
				//	Size = 300,
				//	IsCarbonated = true,
				//},
				//new Drink()
				//{
				//	Id = 2,
				//	Description = "Test2",
				//	Name = "Burger2",
				//	Price = 2.5,
				//	Weight = 150
				//},
				//new Drink()
				//{
				//	Id = DrinkIdForDelete,
				//	Description = "Test3",
				//	Name = "Burger3",
				//	Price = 2.2,
				//	Weight = 130
				//},
				//new Drink()
				//{
				//	Id = DrinkIdForUpdate,
				//	Description = "Test4",
				//	Name = "Burger4",
				//	Price = 2.9,
				//	Weight = 160
				//}
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
