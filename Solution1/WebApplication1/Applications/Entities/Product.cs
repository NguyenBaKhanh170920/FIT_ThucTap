namespace WebApplication1.Applications.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AvailableQuantity { get; set; }
        public Product() { }
        public Product(int id, string name, int price, int availableQuantity)
        {
            Id = id;
            Name = name;
            Price = price;
            AvailableQuantity = availableQuantity;
        }
    }
}
