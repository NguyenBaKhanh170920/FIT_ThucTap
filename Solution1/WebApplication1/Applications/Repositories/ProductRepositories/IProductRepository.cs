using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> UpdateProductPrice(int id, int price);
        Task<Product> UpdateProductName(int id, string name);
        Task<Product> UpdateProductQuantity(int id, int quantity);
    }
}
