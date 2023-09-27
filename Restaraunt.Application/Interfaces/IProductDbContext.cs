using Microsoft.EntityFrameworkCore;
using Restaraunt.Domain;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Interfaces
{
	public interface IProductDbContext
	{
		DbSet<Burger> Burgers { get; set; }
		DbSet<Drink> Drinks { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
