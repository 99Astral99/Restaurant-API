using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Products.Drinks.Queries.GetDrinkDetails
{
	public class DrinkDetailsVm : IMapWith<Drink>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Size { get; set; }
		public bool IsCarbonated { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Drink, DrinkDetailsVm>();
		}
	}
}
