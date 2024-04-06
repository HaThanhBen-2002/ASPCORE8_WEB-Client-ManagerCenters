using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChiTietThuChiController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        public IActionResult Index()
        {
            TempData["menu"] = "ChiTietThuChi";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> Create(ChiTietThuChi item)
        {
            var status = await _unit.ChiTietThuChi.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(ChiTietThuChi item)
        {
            var status = await _unit.ChiTietThuChi.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.ChiTietThuChi.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.ChiTietThuChi.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(ChiTietThuChi item)
        {
            var data = await _unit.ChiTietThuChi.Search(item);
            return Ok(data);
        }

        public async Task<IActionResult> SearchByPhieuThuChiId(string id)
        {
            var data = await _unit.ChiTietThuChi.SearchByPhieuThuChiId(Convert.ToInt32(id));
            return Ok(data);
        }

        #endregion
    }
}
