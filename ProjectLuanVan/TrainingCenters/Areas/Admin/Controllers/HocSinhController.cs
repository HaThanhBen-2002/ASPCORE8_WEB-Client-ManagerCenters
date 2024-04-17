using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HocSinhController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "HocSinh";
            return View();
        }
        
    }
}
