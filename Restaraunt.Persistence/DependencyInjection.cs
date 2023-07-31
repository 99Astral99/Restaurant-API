using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaraunt.Application.Interfaces;

namespace Restaraunt.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration["ConnectionStrings:pg-connection"];
			services.AddDbContext<ProductDbContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});

			services.AddScoped<IProductDbContext>(provider =>
				provider.GetService<ProductDbContext>());

			services.AddScoped<ICustomerDbContext>(provider =>
				provider.GetService<ProductDbContext>());


			return services;
		}
	}
}
