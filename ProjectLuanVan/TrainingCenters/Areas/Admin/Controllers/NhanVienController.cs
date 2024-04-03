using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhanVienController : Controller
    {
        private readonly IUnitOfWork _unit;

        public NhanVienController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IActionResult> Index()
        {
            TempData["menu"] = "NhanVien";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.NhanVien.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.NhanVien.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.NhanVien.GetById(Convert.ToInt32(id));
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
            var status = await _unit.NhanVien.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(NhanVien item)
        {
            var status = await _unit.NhanVien.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.NhanVien.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.NhanVien.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(NhanVien item)
        {
            var data = await _unit.NhanVien.Search(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(NhanVien item)
        {
            var data = await _unit.NhanVien.SearchName(item);
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(NhanVien item)
        {
            var data = await _unit.NhanVien.SearchCount(item);
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(NhanVien item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.NhanVien.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
