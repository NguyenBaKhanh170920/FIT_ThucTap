namespace ProductAPI.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
