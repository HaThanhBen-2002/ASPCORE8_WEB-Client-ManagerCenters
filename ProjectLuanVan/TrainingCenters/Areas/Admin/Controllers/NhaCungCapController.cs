using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhaCungCapController: Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "NhaCungCap";
            return View();
        }
    }
}
