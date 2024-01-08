using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Bai1DbContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(Bai1DbContext dbContext, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                var rs = await _dbContext.AddAsync(category);
                if (rs != null)
                {
                    await _dbContext.SaveChangesAsync();
                    return category;
                }
                return null;
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
                Category category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
                if (category != null)
                {
                    var rs = _dbContext.Remove(category);
                    await _dbContext.SaveChangesAsync();
                    return category;
                }
                return null;
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
                var rs = _dbContext.Categories.ToList();
                return rs;
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
                var rs = _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
