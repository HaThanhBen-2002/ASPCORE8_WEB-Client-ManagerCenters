using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using System.Linq;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.QuanLyTrungTam.Controllers
{
    [Area("QuanLyTrungTam")]
    public class PhieuThuChiController : Controller
    {
        public IActionResult Index()
        {
            TempData["menu"] = "PhieuThuChi";
            return View();
        }

        public IActionResult ChiTietHoaDon()
        {
            TempData["menu"] = "TaoPhieuThuChi";
            return View();
        }
    }
}
