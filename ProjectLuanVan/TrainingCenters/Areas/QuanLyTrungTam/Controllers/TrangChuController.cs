using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.QuanLyTrungTam.Controllers
{
    [Area("QuanLyTrungTam")]
    public class TrangChuController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        public IActionResult TrangChu()
        {
            TempData["menu"] = "TrangChu";
            return View();
        }

    }
}
