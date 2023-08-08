using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Domain;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerList
{
	public sealed class BurgerLookupDto : IMapWith<Burger>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public int Weight { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Burger, BurgerLookupDto>();
		}
	}
}
