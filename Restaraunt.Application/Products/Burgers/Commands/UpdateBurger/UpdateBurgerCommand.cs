using MediatR;

namespace Restaraunt.Application.Products.Burgers.Commands.UpdateBurger
{
    public sealed record UpdateBurgerCommand
        (int Id,
        string Name,
        string Description,
        double Price,
        int Weight) : IRequest<Unit>;
}

