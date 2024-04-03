using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SuDungDichVuController : Controller
    {
        private readonly IUnitOfWork _unit;

        public SuDungDichVuController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IActionResult> Index()
        {
            TempData["menu"] = "SuDungDichVu";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.SuDungDichVu.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.SuDungDichVu.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.SuDungDichVu.GetById(Convert.ToInt32(id));
            DichVu item1 = await _unit.DichVu.GetById(((int)data.MaDichVu));
            HocSinh item2 = await _unit.HocSinh.GetById(((int)data.MaHocSinh));
            var rTable = new
            {
                maSuDungDichVu = data.MaSuDungDichVu,
                tenSuDungDichVu = data.TenSuDungDichVu,
                tenDichVu = item1.TenDichVu,
                trangThai = data.TrangThai,
                ngayKetThuc = data.NgayKetThuc,
                tenHocSinh = item2.TenHocSinh
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(SuDungDichVu item)
        {
            var status = await _unit.SuDungDichVu.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(SuDungDichVu item)
        {
            var status = await _unit.SuDungDichVu.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.SuDungDichVu.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.SuDungDichVu.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(SuDungDichVu item)
        {
            var data = await _unit.SuDungDichVu.Search(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(SuDungDichVu item)
        {
            var data = await _unit.SuDungDichVu.SearchName(item);
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(SuDungDichVu item)
        {
            var data = await _unit.SuDungDichVu.SearchCount(item);
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(SuDungDichVu item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.SuDungDichVu.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
