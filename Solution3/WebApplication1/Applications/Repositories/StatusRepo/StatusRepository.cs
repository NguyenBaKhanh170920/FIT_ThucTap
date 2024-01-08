using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.StatusRepo
{
    public class StatusRepository : IStatusRepository
    {
        private readonly Bai1DbContext _dbContext;
        private readonly ILogger<StatusRepository> _logger;
        public StatusRepository(Bai1DbContext context, ILogger<StatusRepository> logger)
        {
            _dbContext = context;
            _logger = logger;
        }
        public async Task<Status> AddStatus(Status status)
        {
            try
            {
                var rs = _dbContext.Add(status);
                _dbContext.SaveChanges();
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Status> DeleteStatus(int id)
        {
            try
            {
                Status sta = _dbContext.Statuses.FirstOrDefault(x => x.Id == id);
                if (sta != null)
                {
                    _dbContext.Statuses.Remove(sta);
                    _dbContext.SaveChanges();
                    return sta;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<List<Status>> GetAllStatus()
        {
            try
            {
                var rs = _dbContext.Statuses.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Status> UpdateStatus(Status status)
        {
            try
            {
                var rs = _dbContext.Statuses.Update(status);
                _dbContext.SaveChanges();
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }

        }
    }
}
