namespace WebApplication1.Applications.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AdditionalAddress { get; set; }
        public List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
