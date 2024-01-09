using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.ProductService
{
    public interface IProductServices
    {
        Task<Products> GetProductsByProductId(int id);
        Task<List<Products>> GetAllProducts();
        Task<Products> AddProduct(Products product);
        Task<Products> UpdateProductQuantity(int id, int quantity);
        Task<Products> UpdateProductImage(int id, IFormFile file);

    }
}
