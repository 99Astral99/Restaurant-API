using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Products.Drinks.Queries.GetDrinkDetails
{
	public class GetDrinkDetailsQueryHandler
		: IRequestHandler<GetDrinkDetailsQuery, DrinkDetailsVm>
	{
		private readonly IProductDbContext _context;
		private readonly IMapper _mapper;
		public GetDrinkDetailsQueryHandler(IMapper mapper, IProductDbContext context) =>
			 (_mapper, _context) = (mapper, context);


		public async Task<DrinkDetailsVm> Handle(GetDrinkDetailsQuery request,
			CancellationToken cancellationToken)
		{
			var entity = await _context.Drinks
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

			if (entity is null || entity.Id != request.Id)
			{
				throw new NotFoundException(nameof(Drink), request.Id);
			}

			return _mapper.Map<DrinkDetailsVm>(entity);
		}
	}
}
