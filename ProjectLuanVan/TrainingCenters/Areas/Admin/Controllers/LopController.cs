using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LopController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;


        public IActionResult Index()
        {
            TempData["menu"] = "Lop";
            return View();
        }

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.Lop.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.Lop.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.Lop.GetById(Convert.ToInt32(id), GetXacThuc());
            NhanVien item1 = await _unit.NhanVien.GetById(Convert.ToInt32(data.MaNhanVien), GetXacThuc());
            var rTable = new
            {
                maLop = data.MaLop,
                tenLop = data.TenLop,
                tenGiaoVien = item1.TenNhanVien,
                hocPhi = data.HocPhi,
                namHoc = data.NamHoc,
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(Lop item)
        {
            var status = await _unit.Lop.Create(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(Lop item)
        {
            var status = await _unit.Lop.Update(item, GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.Lop.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.Lop.CheckId(Convert.ToInt32(id), GetXacThuc());
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(Lop item)
        {
            var data = await _unit.Lop.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(Lop item)
        {
            var data = await _unit.Lop.SearchName(item, GetXacThuc());
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(Lop item)
        {
            var data = await _unit.Lop.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(Lop item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.Lop.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
