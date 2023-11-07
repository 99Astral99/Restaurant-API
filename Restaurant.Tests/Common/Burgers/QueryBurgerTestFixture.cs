using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Application.Interfaces;
using Restaraunt.Persistence;

namespace Restaurant.Tests.Common.Burgers
{
	public class QueryBurgerTestFixture : IDisposable
	{
		public ProductDbContext Context;
		public IMapper Mapper;

		public QueryBurgerTestFixture()
		{
			Context = BurgersContextFactory.Create();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingProfile(
					typeof(IProductDbContext).Assembly));
			});

			Mapper = configurationProvider.CreateMapper();
		}

		public void Dispose()
		{
			BurgersContextFactory.Destroy(Context);
		}
	}

	[CollectionDefinition("QueryBurgerCollection")]
	public class QueryBurgerCollection : ICollectionFixture<QueryBurgerTestFixture> { }
}
