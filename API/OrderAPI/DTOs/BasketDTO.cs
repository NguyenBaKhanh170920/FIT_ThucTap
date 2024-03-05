namespace OrderAPI.DTOs
{
    public class BasketDTO
    {
        public int CustomerId { get; set; }
        public List<BasketItems> BasketItems { get; set; } = new List<BasketItems>();
    }
}
