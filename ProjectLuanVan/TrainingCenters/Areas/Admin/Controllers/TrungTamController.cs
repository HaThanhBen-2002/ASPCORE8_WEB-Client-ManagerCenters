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
    public class TrungTamController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;


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

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.TrungTam.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.TrungTam.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.TrungTam.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable =new { 
                maTrungTam=data.MaTrungTam, 
                tenTrungTam =data.TenTrungTam, 
                email =data.Email, 
                soDienThoai =data.SoDienThoai, 
                dienTich =data.DienTich, 
                diaChi =data.DiaChi
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(TrungTam item)
        {
            var status = await _unit.TrungTam.Create(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(TrungTam item)
        {
            var status = await _unit.TrungTam.Update(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.TrungTam.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.TrungTam.CheckId(Convert.ToInt32(id), GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(TrungTam item)
        {
            var data = await _unit.TrungTam.Search(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(TrungTam item)
        {
            var data = await _unit.TrungTam.SearchName(item, GetXacThuc());
            return Json(data);
        }

        public async Task<IActionResult> SearchCount(TrungTam item)
        {
            var data = await _unit.TrungTam.SearchCount(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> LoadingDataTableView(TrungTam item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.TrungTam.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
