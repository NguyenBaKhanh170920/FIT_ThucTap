using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.CategoryServ
{
    public interface ICategoryServices
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> DeleteCategory(int id);
    }
}
