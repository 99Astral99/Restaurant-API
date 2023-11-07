using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Products.Drinks.Commands.UpdateDrink;
using Restaurant.Tests.Common.Drinks;

namespace Restaurant.Tests.Products.Drinks.Commands
{
    public class UpdateDrinkCommandHandlerTests : TestDrinkCommandBase
    {
        [Fact]
        public async Task UpdateDrinkCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateDrinkCommandHandler(Context);
            var drinkName = "Update ";
            var drinkDescription = "Updated drink description";
            var drinkPrice = 1.4;
            var drinkSize = 800;
            var IsCarbonated = true;

            //Act
            await handler.Handle(new UpdateDrinkCommand(DrinksContextFactory.DrinkIdForUpdate,
                drinkName,
                drinkDescription,
                drinkPrice,
                drinkSize,
                IsCarbonated), CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Drinks.SingleOrDefaultAsync(drink =>
                drink.Id == DrinksContextFactory.DrinkIdForUpdate &&
                drink.Description == drinkDescription &&
                drink.Price == drinkPrice &&
                drink.Size == drinkSize &&
                drink.IsCarbonated == IsCarbonated));
        }


        public async Task UpdateDrinkCommandHandlerTests_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateDrinkCommandHandler(Context);
            var drinkName = "Update ";
            var drinkDescription = "Updated drink description";
            var drinkPrice = 1.4;
            var drinkSize = 800;
            var IsCarbonated = true;

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
            new UpdateDrinkCommand(new Guid("03337B53-3E05-4CE5-8C32-1B38016778A3"),
            drinkName,
            drinkDescription,
            drinkPrice,
            drinkSize,
            IsCarbonated),
            CancellationToken.None));
        }
    }
}
