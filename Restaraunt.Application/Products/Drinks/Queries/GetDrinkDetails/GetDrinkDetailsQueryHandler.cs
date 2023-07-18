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
		public GetDrinkDetailsQueryHandler(IProductDbContext context, IMapper mapper) =>
			 (_context, _mapper) = (context, mapper);


		public async Task<DrinkDetailsVm> Handle(GetDrinkDetailsQuery request,
			CancellationToken cancellationToken)
		{
			var entity = await _context.Drinks
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

			if (entity is null || entity.Id != request.Id)
			{
				throw new NotFoundException(nameof(Drink), request.Id);
			}

			return _mapper.Map<DrinkDetailsVm>(entity);
		}
	}
}
