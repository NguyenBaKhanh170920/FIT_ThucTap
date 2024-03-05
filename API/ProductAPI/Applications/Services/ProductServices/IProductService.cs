using ProductAPI.Applications.Entities;

namespace WebApplication1.Applications.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> UpdateProductPrice(int id, int price);
        Task<Product> UpdateProductName(int id, string name);
        Task<Product> UpdateProductQuantity(int id, int quantity);
        Task<Product> GetProductById(int id);
    }
}
