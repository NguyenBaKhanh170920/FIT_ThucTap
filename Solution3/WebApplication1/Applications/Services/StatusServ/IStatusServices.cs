using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Services.StatusServ
{
    public interface IStatusServices
    {
        Task<List<Status>> GetAllStatus();
        Task<Status> AddStatus(Status status);
        Task<Status> UpdateStatus(Status status);
        Task<Status> DeleteStatus(int id);
    }
}
