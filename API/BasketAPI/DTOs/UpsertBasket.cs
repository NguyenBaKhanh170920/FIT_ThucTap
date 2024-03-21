namespace BasketAPI.DTOs
{
    public class UpsertBasket
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public UpsertBasket(string message, object data)
        {
            Message = message;
            Data = data;
        }
        public UpsertBasket() { }
    }
}
