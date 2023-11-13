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

			var dbHost = Environment.GetEnvironmentVariable("POSTGRES_HOST");
			var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
			var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
			var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
			var connectionString = $"Host={dbHost};User Id={dbUser};Password={dbPassword};Port=5432;Database={dbName}";
			
			//if you'll want to use a localhost
			//var connectionString = configuration["ConnectionStrings:pg-connection"];

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
