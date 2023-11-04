using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Products.Burgers.Commands.CreateBurger;
using Restaurant.Tests.Common.Burgers;

namespace Restaurant.Tests.Burgers.Commands
{
	public class CreateBurgerCommandHandlerTests : TestBurgerCommandBase
	{
		[Fact]
		public async Task CreateBurgerCommandHandler_Success()
		{
			//Arrange
			var handler = new CreateBurgerCommandHandler(Context);
			var burgerName = "Burger";
			var burgerDescription = "Description";
			var burgerPrice = 3.5;
			var burgerWeight = 105;

			//Act
			var burgerId = await handler.Handle(new CreateBurgerCommand(burgerName,
				burgerDescription,
				burgerPrice,
				burgerWeight), CancellationToken.None);

			//Assert
			Assert.NotNull(
				await Context.Burgers.SingleOrDefaultAsync(burger =>
				burger.Id == burgerId && burger.Name == burgerName &&
				burger.Description == burgerDescription && burger.Price == burgerPrice
				&& burger.Weight == burgerWeight));
		}
	}
}
