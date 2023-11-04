using AutoMapper;
using Restaraunt.Application.Products.Drinks.Queries.GetDrinkList;
using Restaraunt.Persistence;
using Restaurant.Tests.Common.Drinks;
using Shouldly;

namespace Restaurant.Tests.Products.Drinks.Queries
{
	[Collection("QueryDrinkCollection")]
	public class GetDrinkListQueryHandlerTests
	{
		private readonly ProductDbContext Context;
		private readonly IMapper Mapper;
		public GetDrinkListQueryHandlerTests(QueryDrinkTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async void GetDrinkListQueryHandler_Success()
		{
			//Arrange
			var handler = new GetDrinkListQueryHandler(Mapper, Context);
			//Act
			var result = await handler.Handle(
				new GetDrinkListQuery(), CancellationToken.None);
			//Assert
			result.ShouldBeOfType<DrinkListVm>();
			result.Drinks.Count.ShouldBe(Context.Drinks.Count());

		}
	}
}
