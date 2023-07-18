using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerList
{
	public class GetBurgerListQueryHandler
		: IRequestHandler<GetBurgerListQuery, BurgerListVm>
	{
		private readonly IMapper _mapper;
		private readonly IProductDbContext _context;
		public GetBurgerListQueryHandler(IMapper mapper, IProductDbContext context) =>
			(_mapper, _context) = (mapper, context);

		public async Task<BurgerListVm> Handle(GetBurgerListQuery request,
			CancellationToken cancellationToken)
		{
			var burgersQuery = await _context.Burgers
				.ProjectTo<BurgerLookupDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new BurgerListVm { Burgers = burgersQuery };
		}
	}
}
