using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;
using Restaraunt.Application.Reservation_Tables.Queries.GetReservationTableList;

namespace Restaraunt.Application.Reservation_Tables.Queries
{
	public class GetReservationTableListQueryHandler : IRequestHandler<GetReservationTableListQuery, ReservationTableListVm>
	{
		private readonly ICustomerDbContext _context;
		private readonly IMapper _mapper;
		public GetReservationTableListQueryHandler(ICustomerDbContext context, IMapper mapper) =>
			(_context, _mapper) = (context, mapper);

		public async Task<ReservationTableListVm> Handle(GetReservationTableListQuery request,
			CancellationToken cancellationToken)
		{
			var reservationTablesQuery = await _context.ReservationTables
				.AsNoTracking()
				.ProjectTo<ReservationTableLookupDto>(_mapper.ConfigurationProvider)
				.OrderBy(x => x.Number)
				.ToListAsync(cancellationToken);

			return new ReservationTableListVm { ReservationTables = reservationTablesQuery };
		}
	}
}
