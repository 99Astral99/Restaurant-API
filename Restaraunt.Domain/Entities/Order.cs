namespace Restaraunt.Domain.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public double ProductPrice { get; set; }
		public int Count { get; set; }
		public string UserName { get; set; }
		public DateTime DateCreated { get; set; }
		public int? CartId { get; set; }
		public virtual Cart Cart { get; set; }
	}
}
