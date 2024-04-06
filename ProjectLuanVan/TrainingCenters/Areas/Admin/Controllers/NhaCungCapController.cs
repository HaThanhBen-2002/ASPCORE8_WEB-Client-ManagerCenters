using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhaCungCapController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;


        public IActionResult Index()
        {
            TempData["menu"] = "NhaCungCap";
            return View();
        }

        #region Api Data
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.NhaCungCap.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.NhaCungCap.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.NhaCungCap.GetById(Convert.ToInt32(id));
            var rTable = new
            {
                maNhaCungCap = data.MaNhaCungCap,
                tenNhaCungCap = data.TenNhaCungCap,
                email = data.Email,
                soDienThoai = data.SoDienThoai,
                maSoThue = data.MaSoThue
            };
            return Ok(rTable);

        }

        public async Task<IActionResult> Create(NhaCungCap item)
        {
            var status = await _unit.NhaCungCap.Create(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Update(NhaCungCap item)
        {
            var status = await _unit.NhaCungCap.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.NhaCungCap.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.NhaCungCap.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(NhaCungCap item)
        {
            var data = await _unit.NhaCungCap.Search(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(NhaCungCap item)
        {
            var data = await _unit.NhaCungCap.SearchName(item);
            return Json(data);
        }
        public async Task<IActionResult> SearchCount(NhaCungCap item)
        {
            var data = await _unit.NhaCungCap.SearchCount(item);
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(NhaCungCap item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.NhaCungCap.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
