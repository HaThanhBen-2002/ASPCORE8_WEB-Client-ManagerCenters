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
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.HocSinh.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.HocSinh.GetById(Convert.ToInt32(id));
            return Ok(data);
        }
        public async Task<IActionResult> GetHocSinhView(string id)
        {
            var data = await _unit.HocSinh.GetHocSinhView(Convert.ToInt32(id));
            return Ok(data);
        }
        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.HocSinh.GetById(Convert.ToInt32(id));
            Lop item1 = await _unit.Lop.GetById(Convert.ToInt32(data.MaLop));
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
            var status = await _unit.HocSinh.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(HocSinh item)
        {
            var status = await _unit.HocSinh.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.HocSinh.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.HocSinh.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(HocSinh item)
        {
            var data = await _unit.HocSinh.Search(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(HocSinh item)
        {
            var data = await _unit.HocSinh.SearchName(item);
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(HocSinh item)
        {
            var data = await _unit.HocSinh.SearchCount(item);
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(HocSinh item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.HocSinh.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
