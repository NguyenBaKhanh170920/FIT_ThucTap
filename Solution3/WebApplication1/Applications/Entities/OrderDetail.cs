namespace WebApplication1.Applications.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductCode { get; set; }
        public int OrderCode { get; set; }
        public int NumberProduct { get; set; }
        public int TotalPrice { get; set; }
        public int Sale { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
