using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhieuThuChiController : Controller
    {
        private readonly IUnitOfWork _unit;

        public PhieuThuChiController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IActionResult> Index()
        {
            TempData["menu"] = "PhieuThuChi";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.PhieuThuChi.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.PhieuThuChi.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.PhieuThuChi.GetById(Convert.ToInt32(id));
            var rTable = new
            {
                maPhieu = data.MaPhieu,
                loaiPhieu = data.LoaiPhieu,
                tongTien = data.TongTien,
                ngayTao = data.NgayTao,
                hinhThucThanhToan = data.HinhThucThanhToan,
                trangThai = data.TrangThai
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(PhieuThuChi item)
        {
            var status = await _unit.PhieuThuChi.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(PhieuThuChi item)
        {
            var status = await _unit.PhieuThuChi.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.PhieuThuChi.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.PhieuThuChi.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.Search(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchTongTien(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.SearchTongTien(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.SearchCount(item);
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(PhieuThuChi item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.PhieuThuChi.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
