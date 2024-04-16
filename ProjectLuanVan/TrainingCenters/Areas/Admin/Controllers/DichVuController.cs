using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using TrainingCenters.Models.Auth;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DichVuController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        public IActionResult Index()
        {
            TempData["menu"] = "DichVu";
            return View();
        }

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.DichVu.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.DichVu.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            
            var data = await _unit.DichVu.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable = new
            {
                maDichVu = data.MaDichVu,
                tenDichVu = data.TenDichVu,
                gia = data.Gia
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(DichVu item)
        {
            
            var status = await _unit.DichVu.Create(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(DichVu item)
        {
            
            var status = await _unit.DichVu.Update(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    
                    dl = await _unit.DichVu.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            
            var status = await _unit.DichVu.CheckId(Convert.ToInt32(id), GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(DichVu item)
        {
            
            var data = await _unit.DichVu.Search(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(DichVu item)
        {
            
            var data = await _unit.DichVu.SearchName(item, GetXacThuc());
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(DichVu item)
        {
            
            var data = await _unit.DichVu.SearchCount(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> LoadingDataTableView(DichVu item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            
            var data = await _unit.DichVu.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
