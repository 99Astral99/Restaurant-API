using MediatR;

namespace Restaraunt.Application.Products.Burgers.Commands.DeleteBurger
{
    public sealed record DeleteBurgerCommand
        (int Id) : IRequest<Unit>;
}
