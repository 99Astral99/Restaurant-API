using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Application.Interfaces;
using Restaraunt.Persistence;

namespace Restaurant.Tests.Common.Drinks
{
	public class QueryDrinkTestFixture : IDisposable
	{
		public ProductDbContext Context;
		public IMapper Mapper;
		public QueryDrinkTestFixture()
		{
			Context = DrinksContextFactory.Create();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingProfile(
					typeof(IProductDbContext).Assembly));
			});
			Mapper = configurationProvider.CreateMapper();
		}

		public void Dispose()
		{
			DrinksContextFactory.Destroy(Context);
		}

		[CollectionDefinition("QueryDrinkCollection")]
		public class QueryDrinkCollection : ICollectionFixture<QueryDrinkTestFixture> { }
	}
}
