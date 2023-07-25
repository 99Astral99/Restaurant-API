using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Products.Burgers.Commands.UpdateBurger;
using Restaurant.Tests.Common.Burgers;

namespace Restaurant.Tests.Burgers.Commands
{
	public class UpdateBurgerCommandHandlerTests : TestBurgerCommandBase
	{
		[Fact]
		public async Task UpdateBurgerCommandHandler_Success()
		{
			//Arrange
			var handler = new UpdateBurgerCommandHandler(Context);
			var burgerName = "Updated Burger";
			var burgerDescription = "Updated burger description";
			var burgerPrice = 2.35;
			var burgerWeight = 105;

			//Act
			await handler.Handle(new UpdateBurgerCommand(BurgersContextFactory.BurgerIdForUpdate,
				burgerName, burgerDescription, burgerPrice, burgerWeight), CancellationToken.None);

			//Assert
			Assert.NotNull(
				await Context.Burgers.SingleOrDefaultAsync(burger =>
				burger.Id == BurgersContextFactory.BurgerIdForUpdate && burger.Name == burgerName
				&& burger.Description == burgerDescription && burger.Price == burgerPrice
				&& burger.Weight == burgerWeight));
		}

		[Fact]
		public async Task UpdateCommandHandlerTests_FailOnWrongId()
		{
			//Arrange
			var handler = new UpdateBurgerCommandHandler(Context);
			var burgerName = "Updated Burger";
			var burgerDescription = "Updated burger description";
			var burgerPrice = 2.35;
			var burgerWeight = 105;
			//Act
			//Assert
			await Assert.ThrowsAsync<NotFoundException>(async () =>
			await handler.Handle(new UpdateBurgerCommand(Context.Burgers.Max(x => x.Id + 1),
			burgerName, burgerDescription, burgerPrice, burgerWeight), CancellationToken.None));
		}
	}
}
