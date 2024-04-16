using ManagementService.Models.Authentication.Login;
using ManagementService.Models.Authentication.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using System.Diagnostics;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models.Auth;

namespace TrainingCenters.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unit; // Đây là đoạn code bạn đã cung cấp

        public LoginController( IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CapNhatToken(LoginResponse item)
        {
            var data = await _unit.XacThuc.CapNhatToken(item);
            return Ok(data);
        }

        //xông
        public async Task<IActionResult> DangNhapApi (LoginModel item)
        {
            var data = await _unit.XacThuc.DangNhap(item);
            return Ok(data);
        }
        // xông
        public IActionResult DoiMatKhau(string token, string email)
        {
            ViewData["Token"] = token;
            ViewData["Email"] = email;
            return View();
        }
        // xông
        public IActionResult QuenMatKhau()
        {
            return View();
        }
        // Xông 
        public async Task<IActionResult> QuenMatKhauApi(string email)
        {
            //var request = _httpContextAccessor.HttpContext.Request;
            //string url = "https://" + request.Host.ToString() + "/Login/DoiMatKhau";
            //var data = await _unit.XacThuc.QuenMatKhau(email, url );
            var data = await _unit.XacThuc.QuenMatKhau(email, "url" );
            return Ok(data);
        }
        // xông
        public async Task<IActionResult> DoiMatKhauApi(ResetPassword item)
        {
            var data = await _unit.XacThuc.DoiMatKhau(item);
            return Ok(data);
        }
    }
}