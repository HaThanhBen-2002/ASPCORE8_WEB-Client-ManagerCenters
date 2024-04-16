using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MonHocController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;


        public IActionResult Index()
        {
            TempData["menu"] = "MonHoc";
            return View();
        }

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.MonHoc.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.MonHoc.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.MonHoc.GetById(Convert.ToInt32(id), GetXacThuc());
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
            var status = await _unit.MonHoc.Create(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(MonHoc item)
        {
            var status = await _unit.MonHoc.Update(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.MonHoc.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.MonHoc.CheckId(Convert.ToInt32(id), GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(MonHoc item)
        {
            var data = await _unit.MonHoc.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(MonHoc item)
        {
            var data = await _unit.MonHoc.SearchName(item, GetXacThuc());
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(MonHoc item)
        {
            var data = await _unit.MonHoc.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(MonHoc item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.MonHoc.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
