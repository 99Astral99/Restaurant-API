using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Products.Burgers.Commands.DeleteBurger;
using Restaurant.Tests.Common.Burgers;

namespace Restaurant.Tests.Burgers.Commands
{
	public class DeleteBurgerCommandHandlerTests : TestBurgerCommandBase
	{
		[Fact]
		public async Task DeleteBurgerCommandHandler_Success()
		{
			//Arrange
			var handler = new DeleteBurgerCommandHandler(Context);

			//Act
			await handler.Handle(new DeleteBurgerCommand(BurgersContextFactory.BurgerIdForDelete),
				CancellationToken.None);

			//Assert
			Assert.Null(
				await Context.Burgers.SingleOrDefaultAsync(burger =>
					burger.Id == BurgersContextFactory.BurgerIdForDelete));
		}

		[Fact]
		public async Task DeleteBurgerCommandHandler_FailOnWrongId()
		{
			//Arrange
			var handler = new DeleteBurgerCommandHandler(Context);
			//Act
			//Assert
			await Assert.ThrowsAsync<NotFoundException>(async () =>
			await handler.Handle(
				new DeleteBurgerCommand(Context.Burgers.Max(burger => burger.Id + 1)),
				CancellationToken.None));
		}
	}
}
