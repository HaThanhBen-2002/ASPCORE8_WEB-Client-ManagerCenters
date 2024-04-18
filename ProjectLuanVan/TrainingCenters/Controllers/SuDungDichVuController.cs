using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class SuDungDichVuController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.SuDungDichVu.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.SuDungDichVu.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.SuDungDichVu.GetById(Convert.ToInt32(id), GetXacThuc());
            var item1 = await _unit.DichVu.GetById(Convert.ToInt32(data1.Data.MaDichVu), GetXacThuc());
            var item2 = await _unit.HocSinh.GetById(Convert.ToInt32(data1.Data.MaHocSinh), GetXacThuc());
            var rTable = new
            {
                maSuDungDichVu = data1.Data.MaSuDungDichVu,
                tenSuDungDichVu = data1.Data.TenSuDungDichVu,
                tenDichVu = item1.Data.TenDichVu,
                trangThai = data1.Data.TrangThai,
                ngayKetThuc = data1.Data.NgayKetThuc,
                tenHocSinh = item2.Data.TenHocSinh
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);
        }

        public async Task<IActionResult> Create(SuDungDichVu item)
        {
            var data = await _unit.SuDungDichVu.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(SuDungDichVu item)
        {
            var data = await _unit.SuDungDichVu.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    data = await _unit.SuDungDichVu.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.SuDungDichVu.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(SuDungDichVu item)
        {
            var data = await _unit.SuDungDichVu.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(SuDungDichVu item)
        {
            var data = await _unit.SuDungDichVu.SearchName(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(SuDungDichVu item)
        {
            var data = await _unit.SuDungDichVu.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(SuDungDichVu item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.SuDungDichVu.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
