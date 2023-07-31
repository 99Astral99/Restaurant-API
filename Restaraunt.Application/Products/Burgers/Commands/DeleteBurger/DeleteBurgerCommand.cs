using MediatR;

namespace Restaraunt.Application.Products.Burgers.Commands.DeleteBurger
{
    public sealed record DeleteBurgerCommand
        (int id) : IRequest<Unit>;
}
