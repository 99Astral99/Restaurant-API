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
	public class ProductDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>,
		IProductDbContext, ICustomerDbContext
	{
		public DbSet<Drink> Drinks { get; set; }
		public DbSet<Burger> Burgers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<ReservationTable> ReservationTables { get; set; }
		public DbSet<BookingTableOrder> BookingTableOrders { get; set; }
		public ProductDbContext(DbContextOptions<ProductDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new DrinkTypeConfiguration());
			builder.ApplyConfiguration(new BurgerTypeConfiguration());

			builder.ApplyConfiguration(new OrderTypeConfiguration());
			builder.ApplyConfiguration(new CartTypeConfiguration());
			builder.ApplyConfiguration(new UserTypeConfiguration());

			builder.ApplyConfiguration(new BookingTableOrderTypeConfiguration());
			builder.ApplyConfiguration(new ReservationTableTypeConfiguration());


			builder.Entity<IdentityRole<Guid>>().HasData(
				new IdentityRole<Guid>
				{
					Id = new Guid("76BA16A2-158A-46EF-89E7-24E8684AAB20"),
					Name = "Customer",
					NormalizedName = "CUSTOMER",
					ConcurrencyStamp = "76BA16A2-158A-46EF-89E7-24E8684AAB20"
				});

			builder.Entity<IdentityRole<Guid>>().HasData(
				new IdentityRole<Guid>
				{
					Id = new Guid("417EA524-3412-4929-8533-74354E887CC5"),
					Name = "Admin",
					NormalizedName = "ADMIN",
					ConcurrencyStamp = "417EA524-3412-4929-8533-74354E887CC5"
				});

			base.OnModelCreating(builder);
		}
	}
}
