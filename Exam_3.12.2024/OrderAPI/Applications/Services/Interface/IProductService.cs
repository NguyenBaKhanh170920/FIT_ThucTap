using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Services.Interface
{
    public interface IProductService
    {
        Task<Products> AddProduct(Products products);
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(string productId);
        Task<bool> UpdateProductAmount(string productId, int amount);
    }
}
