using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HocSinhController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        public IActionResult Index()
        {
            TempData["menu"] = "HocSinh";
            return View();
        }

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.HocSinh.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.HocSinh.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> GetHocSinhView(string id)
        {
            var data = await _unit.HocSinh.GetHocSinhView(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.HocSinh.GetById(Convert.ToInt32(id), GetXacThuc());
            Lop item1 = await _unit.Lop.GetById(Convert.ToInt32(data.MaLop), GetXacThuc());
            var rTable = new
            {

                maHocSinh = data.MaHocSinh,
                tenHocSinh = data.TenHocSinh,
                ngaySinh = data.NgaySinh,
                gioiTinh = data.GioiTinh,
                tenLop = item1.TenLop,
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(HocSinh item)
        {
            var status = await _unit.HocSinh.Create(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(HocSinh item)
        {
            var status = await _unit.HocSinh.Update(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.HocSinh.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.HocSinh.CheckId(Convert.ToInt32(id), GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(HocSinh item)
        {
            var data = await _unit.HocSinh.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(HocSinh item)
        {
            var data = await _unit.HocSinh.SearchName(item, GetXacThuc());
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(HocSinh item)
        {
            var data = await _unit.HocSinh.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(HocSinh item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.HocSinh.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
