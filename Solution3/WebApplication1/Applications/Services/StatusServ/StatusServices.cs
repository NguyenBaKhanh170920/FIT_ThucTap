using WebApplication1.Applications.Entities;
using WebApplication1.Applications.Repositories.StatusRepo;

namespace WebApplication1.Applications.Services.StatusServ
{
    public class StatusServices : IStatusServices
    {
        private readonly IStatusRepository _statusRepository;
        private readonly ILogger<StatusServices> _logger;
        public StatusServices(IStatusRepository statusRepository, ILogger<StatusServices> logger)
        {
            _statusRepository = statusRepository;
            _logger = logger;
        }
        public async Task<Status> AddStatus(Status status)
        {
            try
            {
                return await _statusRepository.AddStatus(status);
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
                return await (_statusRepository.DeleteStatus(id));
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
                return await _statusRepository.GetAllStatus();
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
                return await _statusRepository.UpdateStatus(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
