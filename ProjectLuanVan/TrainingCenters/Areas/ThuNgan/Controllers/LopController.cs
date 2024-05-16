using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.ThuNgan.Controllers
{
    [Area("ThuNgan")]
    public class LopController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "Lop";
            return View();
        }
    }
}
