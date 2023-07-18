using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain;
using Restaraunt.Domain.Entities;
using Restaraunt.Persistence.EntityTypeConfiguration;

namespace Restaraunt.Persistence
{
	public class ProductDbContext : DbContext, IProductDbContext
	{
		public DbSet<Drink> Drinks { get; set; }
		public DbSet<Burger> Burgers { get; set; }
		public ProductDbContext(DbContextOptions<ProductDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.ApplyConfiguration(new ProductTypeConfiguration());
			builder.ApplyConfiguration(new DrinkTypeConfiguration());
			builder.ApplyConfiguration(new BurgerTypeConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
