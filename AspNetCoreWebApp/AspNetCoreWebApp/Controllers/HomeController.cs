using AspNetCoreWebApp.Models;
using AspNetCoreWebApp.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace AspNetCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger, IUserService userService, ChungKhoanContext con)
        {
            _logger = logger;
            _userService = userService;
            this.con = con;
        }

        public ChungKhoanContext con = new ChungKhoanContext();
        public IActionResult Index()
        {
            return View();
        }
        public object[] SetParameterBang(TbBangHienThi bangHienThi)
        {
            object[] param = {
                new SqlParameter("@Ma",bangHienThi.Ma),
                new SqlParameter("@TC",bangHienThi.Tc),
                new SqlParameter("@Tran",bangHienThi.Tran),
                new SqlParameter("@San",bangHienThi.San),
                new SqlParameter("@MuaG3",(object)bangHienThi.MuaG3??DBNull.Value),
                new SqlParameter("@MuaKL3",(object)bangHienThi.MuaKl3??DBNull.Value),
                new SqlParameter("@MuaG2",(object)bangHienThi.MuaG2??DBNull.Value),
                new SqlParameter("@MuaKL2",(object)bangHienThi.MuaKl2??DBNull.Value),
                new SqlParameter("@MuaG1",(object)bangHienThi.MuaG1??DBNull.Value),
                new SqlParameter("@MuaKL1",(object)bangHienThi.MuaKl1??DBNull.Value),
                new SqlParameter("@KhopLenhGia",(object)bangHienThi.KhopLenhGia??DBNull.Value),
                new SqlParameter("@KhopLenhKL",(object)bangHienThi.KhopLenhKl??DBNull.Value),
                new SqlParameter("@TileTangGiam",(object)bangHienThi.TileTangGiam??DBNull.Value),
                new SqlParameter("@BanG1",(object)bangHienThi.BanG1??DBNull.Value),
                new SqlParameter("@BanKL1",(object)bangHienThi.BanKl1??DBNull.Value),
                new SqlParameter("@BanG2",(object)bangHienThi.BanG2??DBNull.Value),
                new SqlParameter("@BanKL2",(object)bangHienThi.BanKl2??DBNull.Value),
                new SqlParameter("@BanG3",(object)bangHienThi.BanG3??DBNull.Value),
                new SqlParameter("@BanKL3",(object)bangHienThi.BanKl3??DBNull.Value),
                new SqlParameter("@TongKL",(object)bangHienThi.TongKl??DBNull.Value),
                new SqlParameter("@MoCua",(object)bangHienThi.MoCua??DBNull.Value),
                new SqlParameter("@CaoNhat",(object)bangHienThi.CaoNhat??DBNull.Value),
                new SqlParameter("@ThapNhat",(object)bangHienThi.ThapNhat??DBNull.Value),
                new SqlParameter("@NNMua",(object)bangHienThi.Nnmua??DBNull.Value),
                new SqlParameter("@NNBan",(object)bangHienThi.Nnban??DBNull.Value),
                new SqlParameter("@Room",(object)bangHienThi.Room??DBNull.Value),
            };
            return param;
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

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> DisplayUser()
        {

            var user = await _userService.GetAll();
            return View(user);
        }
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            return View(user);
        }
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(TbUser user)
        {
            var rs = _userService.AddUser(user);
            if (rs.IsCompletedSuccessfully)
            {
                TempData["Mes"] = "Khong thanh cong";
            }
            return RedirectToAction(nameof(DisplayUser));
        }
        public async Task<IActionResult> EditUser(int id)
        {
            var user = await _userService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(TbUser user)
        {
            var rs = _userService.UpdateUser(user);
            if (!rs.IsCompletedSuccessfully)
            {
                ViewBag.Mes = "Khong thanh cong";
            }
            return RedirectToAction(nameof(DisplayUser));
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            var rs = _userService.DeleteUser(id);
            if (!rs.IsCompletedSuccessfully)
            {
                ViewBag.Mes = "Khong thanh cong";
            }
            return RedirectToAction(nameof(DisplayUser));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}