namespace WebApplication1.Memories
{
    public class BasketMemory
    {
        public Dictionary<int, BasketMemory> Memory { get; set; } = new Dictionary<int, BasketMemory>();
        BasketMemory() { }
    }
}
