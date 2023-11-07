using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Products.Drinks.Commands.CreateDrink;
using Restaurant.Tests.Common.Drinks;

namespace Restaurant.Tests.Products.Drinks.Commands
{
    public class CreateDrinkCommandHandlerTests : TestDrinkCommandBase
    {
        [Fact]
        public async Task CreateDrinkCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateDrinkCommandHandler(Context);
            var drinkName = "Drink";
            var drinkDescription = "Description";
            var drinkPrice = 2.0;
            var drinkSize = 1000;
            var IsCarbonated = true;

            //Act
            var drinkId = await handler.Handle(new CreateDrinkCommand(drinkName,
                drinkDescription,
                drinkPrice,
                drinkSize,
                IsCarbonated), CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Drinks.SingleOrDefaultAsync(drink =>
                drink.Id == drinkId &&
                drink.Description == drinkDescription &&
                drink.Price == drinkPrice &&
                drink.Size == drinkSize &&
                drink.IsCarbonated == IsCarbonated));
        }
    }
}
