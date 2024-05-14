using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class NhanVienController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.NhanVien.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.NhanVien.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.NhanVien.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable = new
            {
                maNhanVien = data1.Data.MaNhanVien,
                tenNhanVien = data1.Data.TenNhanVien,
                ngaySinh = data1.Data.NgaySinh,
                gioiTinh = data1.Data.GioiTinh,
                loaiNhanVien = data1.Data.LoaiNhanVien,
                phongBan = data1.Data.PhongBan
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(NhanVien item)
        {
   //        var checkEmail = await _unit.NhanVien
            var data = await _unit.NhanVien.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(NhanVien item)
        {
            var data = await _unit.NhanVien.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {

                    data = await _unit.NhanVien.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.NhanVien.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(NhanVien item)
        {
            var data = await _unit.NhanVien.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(NhanVien item)
        {
            var data = await _unit.NhanVien.SearchName(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(NhanVien item)
        {
            var data = await _unit.NhanVien.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(NhanVien item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.NhanVien.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
