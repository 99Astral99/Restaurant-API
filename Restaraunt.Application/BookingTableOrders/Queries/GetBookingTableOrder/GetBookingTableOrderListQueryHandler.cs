using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;

namespace Restaraunt.Application.BookingTableOrders.Queries.GetBookingTableOrder
{
	public class GetBookingTableOrderListQueryHandler : IRequestHandler<GetBookingTableOrderListQuery, BookingTableOrderListVm>
	{
		private readonly ICustomerDbContext _context;
		private readonly IMapper _mapper;
		public GetBookingTableOrderListQueryHandler(ICustomerDbContext context, IMapper mapper) =>
			(_context, _mapper) = (context, mapper);

		public async Task<BookingTableOrderListVm> Handle(GetBookingTableOrderListQuery request,
			CancellationToken cancellationToken)
		{
			var bookingTableOrdersQuery = await _context.BookingTableOrders
				.ProjectTo<BookingTableOrderLookupDto>(_mapper.ConfigurationProvider)
				.ToListAsync();

			return new BookingTableOrderListVm { BookingTableOrders = bookingTableOrdersQuery };
		}
	}
}
