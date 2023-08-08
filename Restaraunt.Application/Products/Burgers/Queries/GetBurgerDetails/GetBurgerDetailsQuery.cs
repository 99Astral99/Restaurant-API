using MediatR;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerDetails
{
    public sealed record GetBurgerDetailsQuery
        (Guid Id) : IRequest<BurgerDetailsVm>;
}
