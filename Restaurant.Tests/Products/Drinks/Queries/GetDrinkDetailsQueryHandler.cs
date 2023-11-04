using AutoMapper;
using Restaraunt.Application.Products.Drinks.Queries.GetDrinkDetails;
using Restaraunt.Persistence;
using Restaurant.Tests.Common.Drinks;
using Shouldly;

namespace Restaurant.Tests.Products.Drinks.Queries
{
	[Collection("QueryDrinkCollection")]
	public class GetBurgerDetailsQueryHandlerTests
	{
		private readonly ProductDbContext Context;
		private readonly IMapper Mapper;

		public GetBurgerDetailsQueryHandlerTests(QueryDrinkTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetDrinkDetailsQueryHandler_Success()
		{
			//Arrange
			var handler = new GetDrinkDetailsQueryHandler(Mapper, Context);
			//Act
			var result = await handler.Handle(
				new GetDrinkDetailsQuery(Guid.Parse("BA5D1EFF-B4AA-46C5-8B44-24882F7B1336")),
				CancellationToken.None);

			//Assert
			result.ShouldBeOfType<DrinkDetailsVm>();

			result.Name.ShouldBe("Drink2");
			result.Description.ShouldBe("Test2");
			result.IsCarbonated.ShouldBeTrue();
			//result.Price.ShouldBe(2.5);
			result.Size.ShouldBe(750);
		}
	}
}
