using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DichVuController : Controller
    {
        private readonly IUnitOfWork _unit;

        public DichVuController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IActionResult> Index()
        {
            TempData["menu"] = "DichVu";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.DichVu.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.DichVu.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.DichVu.GetById(Convert.ToInt32(id));
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
            var status = await _unit.DichVu.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(DichVu item)
        {
            var status = await _unit.DichVu.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.DichVu.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.DichVu.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(DichVu item)
        {
            var data = await _unit.DichVu.Search(item);
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(DichVu item)
        {
            var data = await _unit.DichVu.SearchName(item);
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(DichVu item)
        {
            var data = await _unit.DichVu.SearchCount(item);
            return Ok(data);
        }

        public async Task<IActionResult> LoadingDataTableView(DichVu item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.DichVu.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
