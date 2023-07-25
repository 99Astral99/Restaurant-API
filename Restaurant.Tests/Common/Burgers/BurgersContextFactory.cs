using Microsoft.EntityFrameworkCore;
using Restaraunt.Domain;
using Restaraunt.Persistence;

namespace Restaurant.Tests.Common.Burgers
{
    public class BurgersContextFactory
    {
        public static Random rnd = new Random();

        public static int BurgerIdForDelete = rnd.Next(100, 1000);
        public static int BurgerIdForUpdate = rnd.Next(100, 1000);
        public static ProductDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ProductDbContext(options);
            context.Database.EnsureCreated();
            context.Burgers.AddRange(
                new Burger()
                {
                    Id = 10,
                    Description = "Test1",
                    Name = "Burger1",
                    Price = 3.5,
                    Weight = 250
                },
                new Burger()
                {
                    Id = 11,
                    Description = "Test2",
                    Name = "Burger2",
                    Price = 2.5,
                    Weight = 150
                },
                new Burger()
                {
                    Id = BurgerIdForDelete,
                    Description = "Test3",
                    Name = "Burger3",
                    Price = 2.2,
                    Weight = 130
                },
                new Burger()
                {
                    Id = BurgerIdForUpdate,
                    Description = "Test4",
                    Name = "Burger4",
                    Price = 2.9,
                    Weight = 160
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
