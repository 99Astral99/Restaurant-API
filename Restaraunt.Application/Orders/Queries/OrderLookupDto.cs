using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Orders.Queries
{
    public class OrderLookupDto : IMapWith<Order>
    {
		public int Id { get; set; }
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
		public double ProductPrice { get; set; }
		public int Count { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Order, OrderLookupDto>();
		}
	}
}
