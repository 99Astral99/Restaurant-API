using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Products.Drinks.Commands.DeleteDrink;
using Restaurant.Tests.Common.Drinks;

namespace Restaurant.Tests.Products.Drinks.Commands
{
    public class DeleteDrinkCommandHandlerTests : TestDrinkCommandBase
    {
        [Fact]
        public async Task DeleteDrinkCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteDrinkCommandHandler(Context);

            //Act
            await handler.Handle(
                new DeleteDrinkCommand(DrinksContextFactory.DrinkIdForDelete),
                CancellationToken.None);
            //Assert
            Assert.Null(
                await Context.Drinks.SingleOrDefaultAsync(drink =>
                drink.Id == DrinksContextFactory.DrinkIdForDelete));
        }

        [Fact]
        public async Task DeleteDrinkCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteDrinkCommandHandler(Context);

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
            new DeleteDrinkCommand(new Guid("2894E494-3E35-4DE5-94D3-989B6705DA55")),
            CancellationToken.None));
        }
    }
}
