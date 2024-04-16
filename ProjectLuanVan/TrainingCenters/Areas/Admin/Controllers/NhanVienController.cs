using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhanVienController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;


        public IActionResult Index()
        {
            TempData["menu"] = "NhanVien";
            return View();
        }

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.NhanVien.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.NhanVien.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.NhanVien.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable = new
            {
                maNhanVien = data.MaNhanVien,
                tenNhanVien = data.TenNhanVien,
                ngaySinh = data.NgaySinh,
                gioiTinh = data.GioiTinh,
                loaiNhanVien = data.LoaiNhanVien,
                phongBan = data.PhongBan
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(NhanVien item)
        {
            var status = await _unit.NhanVien.Create(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(NhanVien item)
        {
            var status = await _unit.NhanVien.Update(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.NhanVien.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.NhanVien.CheckId(Convert.ToInt32(id), GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(NhanVien item)
        {
            var data = await _unit.NhanVien.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(NhanVien item)
        {
            var data = await _unit.NhanVien.SearchName(item, GetXacThuc());
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(NhanVien item)
        {
            var data = await _unit.NhanVien.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(NhanVien item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.NhanVien.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
