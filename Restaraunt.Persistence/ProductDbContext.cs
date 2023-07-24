using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain;
using Restaraunt.Domain.Entities;
using Restaraunt.Domain.Entities.Identity;
using Restaraunt.Persistence.EntityTypeConfiguration;

namespace Restaraunt.Persistence
{
	public class ProductDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IProductDbContext
	{
		public DbSet<Drink> Drinks { get; set; }
		public DbSet<Burger> Burgers { get; set; }
		public ProductDbContext(DbContextOptions<ProductDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new DrinkTypeConfiguration());
			builder.ApplyConfiguration(new BurgerTypeConfiguration());
			builder.ApplyConfiguration(new UserTypeConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
