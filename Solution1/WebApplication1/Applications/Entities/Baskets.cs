namespace WebApplication1.Applications.Entities
{
    public class Baskets
    {
        public int CustomerId { get; set; }
        public List<BasketItems> BasketItems { get; set; } = new List<BasketItems>();
    }
}
