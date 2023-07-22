using AutoMapper;
using Restaraunt.Application.Products.Burgers.Queries.GetBurgerDetails;
using Restaraunt.Persistence;
using Restaurant.Tests.Common.Burgers;
using Shouldly;

namespace Restaurant.Tests.Burgers.Queries
{
	[Collection("QueryCollection")]
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
				new GetBurgerDetailsQuery(2), 
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
