using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrungTamController : Controller
    {

        public IActionResult Index()
        {
            TempData["menu"] = "TrungTam";
            return View();
        }
        public IActionResult BaoCaoThongKe()
        {
            TempData["menu"] = "TrungTamBaoCaoThongKe";
            return View();
        }
    }
}
