using ProductAPI.Models;

namespace ProductAPI.Applications.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Products> AddProduct(Products products);
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(string productId);
        Task<bool> UpdateProductAmount(string productId, int amount);
    }
}
