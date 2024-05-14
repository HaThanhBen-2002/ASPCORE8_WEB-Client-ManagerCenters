using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.ThuKho.Controllers
{
    [Area("ThuKho")]
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "SanPham";
            return View();
        }
        
    }
}
