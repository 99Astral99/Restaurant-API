using Microsoft.EntityFrameworkCore;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Interfaces
{
	public interface ICustomerDbContext
	{
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Order> Orders { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
