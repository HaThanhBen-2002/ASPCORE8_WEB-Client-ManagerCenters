using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SuDungDichVuController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "SuDungDichVu";
            return View();
        }
        public IActionResult SuDungDichVu_BaoCaoThongKe()
        {
            TempData["menu"] = "SuDungDichVu_BaoCaoThongKe";
            return View();
        }
        public IActionResult SuDungDichVu_YeuCauThanhToan()
        {
            TempData["menu"] = "SuDungDichVu_YeuCauThanhToan";
            return View();
        }
        public IActionResult SuDungDichVu_ThongBaoGiaHan()
        {
            TempData["menu"] = "SuDungDichVu_ThongBaoGiaHan";
            return View();
        }
        public IActionResult SuDungDichVu_CanhBaoHuyDichVu()
        {
            TempData["menu"] = "SuDungDichVu_CanhBaoHuyDichVu";
            return View();
        }
        public IActionResult SuDungDichVu_CapNhatTrangThai()
        {
            TempData["menu"] = "SuDungDichVu_CapNhatTrangThai";
            return View();
        }
    }
}
