using AutoMapper;
using Restaraunt.Application.Products.Burgers.Queries.GetBurgerList;
using Restaraunt.Persistence;
using Restaurant.Tests.Common.Burgers;
using Shouldly;

namespace Restaurant.Tests.Burgers.Queries
{
	[Collection("QueryBurgerCollection")]
	public class GetBurgerListQueryHandlerTests
	{
		private readonly ProductDbContext Context;
		private readonly IMapper Mapper;
		public GetBurgerListQueryHandlerTests(QueryBurgerTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async void GetBurgerListQueryHandler_Success()
		{
			//Arrange
			var handler = new GetBurgerListQueryHandler(Mapper, Context);
			//Act
			var result = await handler.Handle(
				new GetBurgerListQuery(), 
				CancellationToken.None);
			//Assert
			result.ShouldBeOfType<BurgerListVm>();
			result.Burgers.Count.ShouldBe(Context.Burgers.Count());
		}
	}
}
