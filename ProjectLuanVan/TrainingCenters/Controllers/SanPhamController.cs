using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class SanPhamController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.SanPham.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.SanPham.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById2(string id)
        {
            var data = await _unit.SanPham.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.SanPham.GetById(Convert.ToInt32(id), GetXacThuc());
            var item1 = await _unit.NhaCungCap.GetById(Convert.ToInt32(data1.Data.MaNhaCungCap), GetXacThuc());
            var rTable = new
            {
                maSanPham = data1.Data.MaSanPham,
                tenSanPham = data1.Data.TenSanPham,
                loaiSanPham = data1.Data.LoaiSanPham,
                hanSuDung = data1.Data.HanSuDung,
                gia = data1.Data.Gia,
                tenNhaCungCap = item1.Data.TenNhaCungCap
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(SanPham item)
        {
            var data = await _unit.SanPham.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(SanPham item)
        {
            var data = await _unit.SanPham.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                     data = await _unit.SanPham.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.SanPham.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(SanPham item)
        {
            var data = await _unit.SanPham.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(SanPham item)
        {
            var data = await _unit.SanPham.SearchName(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(SanPham item)
        {
            var data = await _unit.SanPham.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(SanPham item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.SanPham.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
