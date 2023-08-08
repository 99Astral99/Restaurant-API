using Microsoft.EntityFrameworkCore;
using Restaraunt.Domain;
using Restaraunt.Persistence;

namespace Restaurant.Tests.Common.Burgers
{
    public class BurgersContextFactory
    {
        public static Random rnd = new Random();

        public static Guid BurgerIdForDelete = new Guid("FBA1A8C9-6D1E-45BD-90C0-C7BDECAF2B8D");
        public static Guid BurgerIdForUpdate = new Guid("4C89AC34-ADE2-4E72-8847-B5F8A1A7C1F4");
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
                    Id = new Guid("D087F7B5-345E-4274-BE5D-75CE9B037DFC"),
                    Description = "Test1",
                    Name = "Burger1",
                    Price = 3.5,
                    Weight = 250
                },
                new Burger()
                {
                    Id = new Guid("9D1E3509-F3DF-453D-9F10-C87C48CA4DE6"),
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
