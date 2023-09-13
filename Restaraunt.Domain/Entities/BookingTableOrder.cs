namespace Restaraunt.Domain.Entities
{
	public class BookingTableOrder
	{
		public Guid Id { get; set; }
		public int ReservationTableId { get; set; }
		public virtual ReservationTable ReservationTable { get; set; }
		public int TableNumber { get; set; }
		public string ClientName { get; set; }
		public int ReservedPeopleAmount { get; set; }
		public DateTime Date { get; set; }
	}
}
