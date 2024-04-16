using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KetQuaController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        public IActionResult Index()
        {
            TempData["menu"] = "KetQua";
            return View();
        }
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.KetQua.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.KetQua.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.KetQua.GetById(Convert.ToInt32(id), GetXacThuc());
            if (data != null)
            {
                HocSinh item1 = await _unit.HocSinh.GetById(Convert.ToInt32(data.MaHocSinh), GetXacThuc());
                MonHoc item2 = await _unit.MonHoc.GetById(Convert.ToInt32(data.MaMonHoc), GetXacThuc());
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

            return Ok(false);

        }

        public async Task<IActionResult> Create(KetQua item)
        {
            var status = await _unit.KetQua.Create(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(KetQua item)
        {
            var status = await _unit.KetQua.Update(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.KetQua.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.KetQua.CheckId(Convert.ToInt32(id), GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(KetQua item)
        {
            var data = await _unit.KetQua.Search(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(KetQua item)
        {
            var data = await _unit.KetQua.SearchName(item, GetXacThuc());
            return Json(data);
        }

        public async Task<IActionResult> SearchCount(KetQua item)
        {
            var data = await _unit.KetQua.SearchCount(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> LoadingDataTableView(KetQua item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.KetQua.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
