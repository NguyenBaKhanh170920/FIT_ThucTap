namespace WebApplication1.Applications.Entities
{
    public class Order
    {
        public int OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int TotalPrice { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string seller { get; set; }
        public int Paid { get; set; }
        public int Sale { get; set; }
        public int Status { get; set; }
    }
}
