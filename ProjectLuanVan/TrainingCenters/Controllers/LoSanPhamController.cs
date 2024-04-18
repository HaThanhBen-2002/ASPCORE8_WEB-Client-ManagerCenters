using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class LoSanPhamController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.LoSanPham.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.LoSanPham.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.LoSanPham.GetById(Convert.ToInt32(id), GetXacThuc());
            var item1 = await _unit.SanPham.GetById(Convert.ToInt32(data1.Data.MaSanPham), GetXacThuc());
            var rTable = new
            {
                maLoSanPham = data1.Data.MaLoSanPham,
                tenLoSanPham = data1.Data.TenLoSanPham,
                tenSanPham = item1.Data.TenSanPham,
                trangThai = data1.Data.TrangThai,
                ngayNhap = data1.Data.NgayNhap,
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(LoSanPham item)
        {
            var data = await _unit.LoSanPham.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(LoSanPham item)
        {
            var data = await _unit.LoSanPham.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    data = await _unit.LoSanPham.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.LoSanPham.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(LoSanPham item)
        {
            var data = await _unit.LoSanPham.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(LoSanPham item)
        {
            var data = await _unit.LoSanPham.SearchName(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(LoSanPham item)
        {
            var data = await _unit.LoSanPham.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(LoSanPham item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.LoSanPham.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
