using ProductAPI.Applications.Entities;
using ProductAPI.DTOs;

namespace WebApplication1.Applications.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> UpdateProductPrice(int id, int price);
        Task<UpsertProduct> UpdateProductName(int id, string name);
        Task<Product> UpdateProductQuantity(int id, int quantity);
        Task<Product> GetProductById(int id);
        Task<bool> UpdateProductQuantityAfterOrder(int productId, int quantity);
        Task<bool> KafkaCheckProductQuantity(int OrderId, string value);
    }
}
