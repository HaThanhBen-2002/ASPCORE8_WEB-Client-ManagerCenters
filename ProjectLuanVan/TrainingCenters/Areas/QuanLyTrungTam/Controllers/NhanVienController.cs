using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.QuanLyTrungTam.Controllers
{
    [Area("QuanLyTrungTam")]
    public class NhanVienController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "NhanVien";
            return View();
        }
    }
}
