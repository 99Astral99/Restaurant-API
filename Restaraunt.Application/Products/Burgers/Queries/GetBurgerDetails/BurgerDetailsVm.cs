using AutoMapper;
using Restaraunt.Application.Common.Mappings;
using Restaraunt.Domain;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerDetails
{
    public class BurgerDetailsVm : IMapWith<Burger>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Burger, BurgerDetailsVm>();
        }
    }
}
