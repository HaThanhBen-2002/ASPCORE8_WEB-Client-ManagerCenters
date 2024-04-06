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

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.TrungTam.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.TrungTam.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.TrungTam.GetById(Convert.ToInt32(id));
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
            var status = await _unit.TrungTam.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(TrungTam item)
        {
            var status = await _unit.TrungTam.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.TrungTam.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.TrungTam.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(TrungTam item)
        {
            var data = await _unit.TrungTam.Search(item);
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(TrungTam item)
        {
            var data = await _unit.TrungTam.SearchName(item);
            return Json(data);
        }

        public async Task<IActionResult> SearchCount(TrungTam item)
        {
            var data = await _unit.TrungTam.SearchCount(item);
            return Ok(data);
        }

        public async Task<IActionResult> LoadingDataTableView(TrungTam item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.TrungTam.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
