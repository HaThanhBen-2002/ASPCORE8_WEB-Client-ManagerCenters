using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.QuanLyTrungTam.Controllers
{
    [Area("QuanLyTrungTam")]
    public class ChiTietThuChiController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "ChiTietThuChi";
            return View();
        }
        
    }
}
