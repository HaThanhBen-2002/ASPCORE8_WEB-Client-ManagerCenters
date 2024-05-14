using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.GiaoVien.Controllers
{
    [Area("GiaoVien")]
    public class KetQuaController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "KetQua";
            return View();
        }
    }
}
