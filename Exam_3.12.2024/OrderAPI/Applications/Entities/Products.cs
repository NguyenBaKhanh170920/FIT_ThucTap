namespace OrderAPI.Applications.Entities
{
    public class Products
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int RemainingAmount { get; set; }
    }
}
