using MediatR;

namespace Restaraunt.Application.Products.Burgers.Commands.CreateBurger
{
    public sealed record CreateBurgerCommand
        (string Name,
        string Description,
        double Price,
        int Weight) : IRequest<Guid>;
}
