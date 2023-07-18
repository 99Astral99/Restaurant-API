namespace Restaraunt.Domain.Entities
{
    public class Drink : BaseProduct
    {
        public int Size { get; set; }
        public bool IsCarbonated { get; set; }
    }
}
