namespace Restaraunt.Domain.Entities
{
	public class ReservationTable
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public bool IsReserved { get; set; }
		public virtual BookingTableOrder BookingTableOrder { get; set; }
	}
}
