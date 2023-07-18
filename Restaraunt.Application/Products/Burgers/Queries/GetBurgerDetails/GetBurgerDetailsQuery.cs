using MediatR;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerDetails
{
    public sealed record GetBurgerDetailsQuery
        (int Id) : IRequest<BurgerDetailsVm>;
}
