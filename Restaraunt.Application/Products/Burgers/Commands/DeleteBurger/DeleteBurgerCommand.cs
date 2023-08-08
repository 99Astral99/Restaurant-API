using MediatR;

namespace Restaraunt.Application.Products.Burgers.Commands.DeleteBurger
{
    public sealed record DeleteBurgerCommand
        (Guid id) : IRequest<Unit>;
}
