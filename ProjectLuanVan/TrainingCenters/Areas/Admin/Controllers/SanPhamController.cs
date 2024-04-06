using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        public IActionResult Index()
        {
            TempData["menu"] = "SanPham";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.SanPham.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.SanPham.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetById2(string id)
        {
            var data = await _unit.SanPham.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.SanPham.GetById(Convert.ToInt32(id));
            NhaCungCap item1 = await _unit.NhaCungCap.GetById(Convert.ToInt32(data.MaNhaCungCap));
            var rTable = new
            {
                maSanPham = data.MaSanPham,
                tenSanPham = data.TenSanPham,
                loaiSanPham = data.LoaiSanPham,
                hanSuDung = data.HanSuDung,
                gia = data.Gia,
                tenNhaCungCap = item1.TenNhaCungCap
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(SanPham item)
        {
            var status = await _unit.SanPham.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(SanPham item)
        {
            var status = await _unit.SanPham.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.SanPham.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.SanPham.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(SanPham item)
        {
            var data = await _unit.SanPham.Search(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(SanPham item)
        {
            var data = await _unit.SanPham.SearchName(item);
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(SanPham item)
        {
            var data = await _unit.SanPham.SearchCount(item);
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(SanPham item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.SanPham.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
