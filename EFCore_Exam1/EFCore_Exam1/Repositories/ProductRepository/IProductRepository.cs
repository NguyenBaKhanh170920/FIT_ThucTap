using EFCore_Exam1.Models;

namespace EFCore_Exam1.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll(int? CategoryId);
        Task<Product> DeleteProduct(int? Id);
        Task<Product> CreateProduct(Product product);
        Task<List<Product>> GetAllEfCore(int? CategoryId);
        Task<Product> DeleteProductEfCore(int? Id);
        Task<Product> CreateProductEfCore(Product product);

    }
}
