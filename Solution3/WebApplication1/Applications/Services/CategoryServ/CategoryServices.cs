using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.CategoryRepo;

namespace WebApplication1.Applications.Services.CategoryServ
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryServices> _logger;
        public CategoryServices(ICategoryRepository categoryRepository, ILogger<CategoryServices> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                return await _categoryRepository.AddCategory(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Category> DeleteCategory(int id)
        {
            try
            {
                return await _categoryRepository.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Category>> GetAllCategory()
        {
            try
            {
                return await _categoryRepository.GetAllCategory();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            try
            {
                return await _categoryRepository.UpdateCategory(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
