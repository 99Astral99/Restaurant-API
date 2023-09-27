using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Reservation_Tables.Queries.GetReservationTableList
{
	public class ReservationTableLookupDto : IMapWith<ReservationTable>
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public bool IsReserved { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<ReservationTable, ReservationTableLookupDto>();
		}
	}
}
