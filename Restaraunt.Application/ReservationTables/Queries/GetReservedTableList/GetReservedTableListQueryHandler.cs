using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;
using Restaraunt.Application.Reservation_Tables.Queries;
using Restaraunt.Application.Reservation_Tables.Queries.GetReservationTableList;

namespace Restaraunt.Application.ReservationTables.Queries.GetReservedTableList
{
	public class GetReservedTableListQueryHandler : IRequestHandler<GetReservedTableListQuery, ReservationTableListVm>
	{
		private readonly ICustomerDbContext _context;
		private readonly IMapper _mapper;
		public GetReservedTableListQueryHandler(ICustomerDbContext context, IMapper mapper) =>
			(_context, _mapper) = (context, mapper);
		public async Task<ReservationTableListVm> Handle(GetReservedTableListQuery request,
			CancellationToken cancellationToken)
		{
			var reservedTableQuery = await _context.ReservationTables
				.AsNoTracking()
				.Where(x => x.IsReserved == true)
				.ProjectTo<ReservationTableLookupDto>(_mapper.ConfigurationProvider)
				.OrderBy(x => x.Number)
				.ToListAsync(cancellationToken);

			return new ReservationTableListVm { ReservationTables = reservedTableQuery };
		}
	}
}
