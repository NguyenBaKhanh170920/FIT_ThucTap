using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> UpdateInventory(int id, int inventory);
        Task<Product> UpdateStatus(int id, int status);
        Task<Product> UpdateCost(int id, int cost);
        Task<Product> UpdateRentailPrice(int id, int RentaiPrice);

    }
}
