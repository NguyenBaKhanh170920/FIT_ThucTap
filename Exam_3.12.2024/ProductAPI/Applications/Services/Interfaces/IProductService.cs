using ProductAPI.DTOs;
using ProductAPI.Models;

namespace ProductAPI.Applications.Services.Interfaces
{
    public interface IProductService
    {
        Task<Products> AddProduct(Products products);
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(string productId);
        Task<bool> UpdateProductAmount(string productId, int amount);
        Task<bool> FOutPutMessageValue(CheckProductAmount amount, string status);
    }
}
