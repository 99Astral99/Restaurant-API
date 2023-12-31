﻿namespace Restaraunt.Domain.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public Guid ProductId { get; set; }
		public int Count { get; set; }
		public string UserName { get; set; }
		public DateTime DateCreated { get; set; }
		public int? CartId { get; set; }
		public virtual Cart Cart { get; set; }
	}
}
