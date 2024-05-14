using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.GiaoVien.Controllers
{
    [Area("GiaoVien")]
    public class MonHocController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "MonHoc";
            return View();
        }
    }
}
