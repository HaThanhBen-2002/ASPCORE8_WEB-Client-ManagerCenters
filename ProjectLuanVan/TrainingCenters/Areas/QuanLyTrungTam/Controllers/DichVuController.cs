using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using TrainingCenters.Models.Auth;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.QuanLyTrungTam.Controllers
{
    [Area("QuanLyTrungTam")]
    public class DichVuController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "DichVu";
            return View();
        }
    }
}
