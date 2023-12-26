using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;
using Restaraunt.Application.Reservation_Tables.Queries.GetReservationTableList;

namespace Restaraunt.Application.Reservation_Tables.Queries.GetUnreservedTableList
{
	public class GetUnreservedTableListQueryHandler : IRequestHandler<GetUnreservedTableListQuery, ReservationTableListVm>
	{
		private readonly ICustomerDbContext _context;
		private readonly IMapper _mapper;
		public GetUnreservedTableListQueryHandler(ICustomerDbContext context, IMapper mapper) =>
			(_context, _mapper) = (context, mapper);
		public async Task<ReservationTableListVm> Handle(GetUnreservedTableListQuery request,
			CancellationToken cancellationToken)
		{
			var unreservedTableQuery = await _context.ReservationTables
				.AsNoTracking()
				.Where(x => x.IsReserved == false)
				.ProjectTo<ReservationTableLookupDto>(_mapper.ConfigurationProvider)
				.OrderBy(x => x.Number)
				.ToListAsync(cancellationToken);

			return new ReservationTableListVm { ReservationTables = unreservedTableQuery };
		}
	}
}
