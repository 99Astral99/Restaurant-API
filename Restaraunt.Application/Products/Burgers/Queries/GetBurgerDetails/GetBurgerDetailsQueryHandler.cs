using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerDetails
{
    public class GetBurgerDetailsQueryHandler
        : IRequestHandler<GetBurgerDetailsQuery, BurgerDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IProductDbContext _context;
        public GetBurgerDetailsQueryHandler(IMapper mapper, IProductDbContext context) =>
              (_mapper, _context) = (mapper, context);

        public async Task<BurgerDetailsVm> Handle(GetBurgerDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Burgers
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Burger), request.Id);
            }

            return _mapper.Map<BurgerDetailsVm>(entity);
        }
    }
}
