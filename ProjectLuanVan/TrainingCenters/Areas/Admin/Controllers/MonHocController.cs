using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MonHocController : Controller
    {
        private readonly IUnitOfWork _unit;

        public MonHocController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IActionResult> Index()
        {
            TempData["menu"] = "MonHoc";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.MonHoc.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.MonHoc.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.MonHoc.GetById(Convert.ToInt32(id));
            var rTable = new
            {
                maMonHoc = data.MaMonHoc,
                tenMonHoc = data.TenMonHoc,
                gia = data.Gia,
                thongTin = data.ThongTin,
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(MonHoc item)
        {
            var status = await _unit.MonHoc.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(MonHoc item)
        {
            var status = await _unit.MonHoc.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.MonHoc.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.MonHoc.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(MonHoc item)
        {
            var data = await _unit.MonHoc.Search(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(MonHoc item)
        {
            var data = await _unit.MonHoc.SearchName(item);
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(MonHoc item)
        {
            var data = await _unit.MonHoc.SearchCount(item);
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(MonHoc item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.MonHoc.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
