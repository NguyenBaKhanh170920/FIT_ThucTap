using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.CategoryRepo
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(int id);
    }
}
