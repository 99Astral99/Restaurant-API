using AutoMapper;
using Restaraunt.Application.Products.Burgers.Queries.GetBurgerDetails;
using Restaraunt.Persistence;
using Restaurant.Tests.Common.Burgers;
using Shouldly;

namespace Restaurant.Tests.Burgers.Queries
{
	[Collection("QueryBurgerCollection")]
	public class GetBurgerDetailsQueryHandlerTests
	{
		private readonly ProductDbContext Context;
		private readonly IMapper Mapper;

		public GetBurgerDetailsQueryHandlerTests(QueryBurgerTestFixture fixture)
		{
			Context = fixture.Context;
			Mapper = fixture.Mapper;
		}

		[Fact]
		public async Task GetBurgerDetailsQueryHandler_Success()
		{
			//Arrange
			var handler = new GetBurgerDetailsQueryHandler(Mapper, Context);

			//Act
			var result = await handler.Handle(
				new GetBurgerDetailsQuery(Guid.Parse("9D1E3509-F3DF-453D-9F10-C87C48CA4DE6")),
					CancellationToken.None);

			//Assert
			result.ShouldBeOfType<BurgerDetailsVm>();

			result.Name.ShouldBe("Burger2");
			result.Description.ShouldBe("Test2");
			result.Price.ShouldBe(2.5);
			result.Weight.ShouldBe(150);
		}
	}

}
