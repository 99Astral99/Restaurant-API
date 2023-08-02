using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Orders.Queries
{
    public class OrderLookupDto : IMapWith<Order>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }   
        public int Count { get; set; }
        public string UserName { get; set; }
        public int? CartId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDto>();
        }
    }
}
