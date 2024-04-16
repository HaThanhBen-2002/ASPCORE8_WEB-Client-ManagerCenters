using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoSanPhamController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        public IActionResult Index()
        {
            TempData["menu"] = "LoSanPham";
            return View();
        }

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.LoSanPham.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.LoSanPham.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.LoSanPham.GetById(Convert.ToInt32(id), GetXacThuc());
            SanPham item1 = await _unit.SanPham.GetById(Convert.ToInt32(data.MaSanPham), GetXacThuc());
            var rTable = new
            {
                maLoSanPham = data.MaLoSanPham,
                tenLoSanPham = data.TenLoSanPham,
                tenSanPham = item1.TenSanPham,
                trangThai = data.TrangThai,
                ngayNhap = data.NgayNhap,
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(LoSanPham item)
        {
            var status = await _unit.LoSanPham.Create(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(LoSanPham item)
        {
            var status = await _unit.LoSanPham.Update(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.LoSanPham.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.LoSanPham.CheckId(Convert.ToInt32(id), GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(LoSanPham item)
        {
            var data = await _unit.LoSanPham.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(LoSanPham item)
        {
            var data = await _unit.LoSanPham.SearchName(item, GetXacThuc());
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(LoSanPham item)
        {
            var data = await _unit.LoSanPham.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(LoSanPham item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.LoSanPham.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
