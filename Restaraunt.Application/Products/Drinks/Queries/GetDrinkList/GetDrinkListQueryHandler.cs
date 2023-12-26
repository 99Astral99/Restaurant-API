using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;

namespace Restaraunt.Application.Products.Drinks.Queries.GetDrinkList
{
	public class GetDrinkListQueryHandler
		: IRequestHandler<GetDrinkListQuery, DrinkListVm>
	{
		private readonly IMapper _mapper;
		private readonly IProductDbContext _context;
		public GetDrinkListQueryHandler(IMapper mapper, IProductDbContext context) =>
			(_context, _mapper) = (context, mapper);

		public async Task<DrinkListVm> Handle(GetDrinkListQuery request,
			CancellationToken cancellationToken)
		{
			var drinksQuery = await _context.Drinks
				.AsNoTracking()
				.ProjectTo<DrinkLookupDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new DrinkListVm { Drinks = drinksQuery };
		}
	}
}
