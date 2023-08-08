using MediatR;

namespace Restaraunt.Application.Products.Drinks.Commands.DeleteDrink
{
	public sealed record DeleteDrinkCommand
		(Guid Id) : IRequest<Unit>;
}
