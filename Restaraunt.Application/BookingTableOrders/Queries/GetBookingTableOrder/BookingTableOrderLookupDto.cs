using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.BookingTableOrders.Queries.GetBookingTableOrder
{
	public class BookingTableOrderLookupDto : IMapWith<BookingTableOrder>
	{
		public Guid Id { get; set; }
		public int TableNumber { get; set; }
		public string ClientName { get; set; }
		public int ReservedPeopleAmount { get; set; }
		public DateTime Date { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<BookingTableOrder, BookingTableOrderLookupDto>();
		}
	}
}