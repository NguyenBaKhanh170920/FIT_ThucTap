using AspNetCoreWebApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApp.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ChungKhoanContext _context;
        private readonly ILogger<UserService> _logger;
        public UserService(ChungKhoanContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public object[] SetParameteruser(TbUser user)
        {
            object[] param = {
                new SqlParameter("@Id",user.Id),
                new SqlParameter("@Name",user.Name),
                new SqlParameter("@Email",user.Email),
                new SqlParameter("@Password",user.Password),
                new SqlParameter("@Temppass",user.Temppass)
            };
            return param;
        }

        public async Task<bool> AddUser(TbUser user)
        {
            bool bl = true;
            try
            {
                var rs = await _context.Database
                   .ExecuteSqlRawAsync("SP_Insert_User @Name, @Email, @Password, @Temppass", SetParameteruser(user));
                if (rs == 0)
                {
                    bl = false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                bl = false;
            }
            return bl;
        }

        public async Task<bool> DeleteUser(int id)
        {
            bool bl = true;
            try
            {
                var param = new SqlParameter("@id", id);
                int rs = await _context.Database
                           .ExecuteSqlRawAsync("SP_Delete_User @id", param);
                if (rs == 0)
                {
                    bl = false;
                }
                return bl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                bl = false;
                return bl;
            }
        }

        public async Task<List<TbUser>> GetAll()
        {
            try
            {
                var user = await _context.Set<TbUser>().FromSqlRaw("SP_Get_All_User").ToListAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }


        }

        public async Task<TbUser> GetById(int id)
        {
            try
            {
                TbUser user = new TbUser();
                await Task.Run(() =>
                {
                    var param = new SqlParameter("@id", id);
                    user = _context.Set<TbUser>()
                         .FromSqlRaw($"SP_Get_User_By_Id @id", param)
                         .AsEnumerable()
                         .FirstOrDefault();
                });
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }


        }

        public async Task<bool> UpdateUser(TbUser user)
        {
            bool bl = true;
            try
            {
                int rs = await _context.Database
                       .ExecuteSqlRawAsync("SP_Update_User @Id, @Name, @Email, @Password, @Temppass", SetParameteruser(user));
                if (rs == 0)
                {
                    bl = false;
                }
                return bl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                bl = false;
                return bl;

            }
        }
    }
}
