namespace ProductAPI.DTOs
{
    public class OutPutMessageValue
    {
        public string RefId { get; set; }
        public int BusinessType { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ProductId { get; set; }
    }
}
