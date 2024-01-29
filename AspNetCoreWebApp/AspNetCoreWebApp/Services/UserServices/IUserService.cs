using AspNetCoreWebApp.Models;

namespace AspNetCoreWebApp.Services.UserServices
{
    public interface IUserService
    {
        Task<List<TbUser>> GetAll();
        Task<TbUser> GetById(int id);
        Task<bool> AddUser(TbUser user);
        Task<bool> UpdateUser(TbUser user);
        Task<bool> DeleteUser(int id);
    }
}
