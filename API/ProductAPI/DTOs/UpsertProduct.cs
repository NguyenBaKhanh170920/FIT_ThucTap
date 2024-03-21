namespace ProductAPI.DTOs
{
    public class UpsertProduct
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public UpsertProduct(string message, object data)
        {
            Message = message;
            Data = data;
        }
        public UpsertProduct() { }
    }
}
