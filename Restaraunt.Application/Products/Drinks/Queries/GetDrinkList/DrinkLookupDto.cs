using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Products.Drinks.Queries.GetDrinkList
{
	public sealed class DrinkLookupDto : IMapWith<Drink>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Size { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Drink, DrinkLookupDto>();
		}
	}
}
