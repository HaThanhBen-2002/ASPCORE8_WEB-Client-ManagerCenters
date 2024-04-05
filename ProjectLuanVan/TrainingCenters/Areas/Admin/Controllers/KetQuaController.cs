using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KetQuaController : Controller
    {
        private readonly IUnitOfWork _unit;

        public KetQuaController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IActionResult> Index()
        {
            TempData["menu"] = "KetQua";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.KetQua.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.KetQua.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.KetQua.GetById(Convert.ToInt32(id));
            HocSinh item1 = await _unit.HocSinh.GetById((int)data.MaHocSinh);
            MonHoc item2 = await _unit.MonHoc.GetById((int)data.MaMonHoc);
            var rTable = new
            {
                maKetQua = data.MaKetQua,
                tenKetQua = data.TenKetQua,
                tenHocSinh = item1.TenHocSinh,
                tenMonHoc = item2.TenMonHoc,
                trangThai = data.TrangThai,
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(KetQua item)
        {
            var status = await _unit.KetQua.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(KetQua item)
        {
            var status = await _unit.KetQua.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.KetQua.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.KetQua.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(KetQua item)
        {
            var data = await _unit.KetQua.Search(item);
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(KetQua item)
        {
            var data = await _unit.KetQua.SearchName(item);
            return Json(data);
        }

        public async Task<IActionResult> SearchCount(KetQua item)
        {
            var data = await _unit.KetQua.SearchCount(item);
            return Ok(data);
        }

        public async Task<IActionResult> LoadingDataTableView(KetQua item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.KetQua.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
