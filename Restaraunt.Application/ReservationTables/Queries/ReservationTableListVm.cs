using Restaraunt.Application.Reservation_Tables.Queries.GetReservationTableList;

namespace Restaraunt.Application.Reservation_Tables.Queries
{
	public class ReservationTableListVm
	{
		public IList<ReservationTableLookupDto> ReservationTables { get; set; }
	}
}
