using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.QuanLyTrungTam.Controllers
{
    [Area("QuanLyTrungTam")]
    public class HocSinhController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "HocSinh";
            return View();
        }
        
    }
}
