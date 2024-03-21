namespace ProductAPI.Models
{
    public partial class Products
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int RemainingAmount { get; set; }
    }
}
