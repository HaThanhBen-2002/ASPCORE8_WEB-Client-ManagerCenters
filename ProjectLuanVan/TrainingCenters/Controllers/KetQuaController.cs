using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class KetQuaController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

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
            var data1 = await _unit.KetQua.GetById(Convert.ToInt32(id), GetXacThuc());
            if (data1.IsSuccess)
            {
                var item1 = await _unit.HocSinh.GetById(Convert.ToInt32(data1.Data.MaHocSinh), GetXacThuc());
                var item2 = await _unit.MonHoc.GetById(Convert.ToInt32(data1.Data.MaMonHoc), GetXacThuc());
                var rTable = new
                {
                    maKetQua = data1.Data.MaKetQua,
                    tenKetQua = data1.Data.TenKetQua,
                    tenHocSinh = item1.Data.TenHocSinh,
                    tenMonHoc = item2.Data.TenMonHoc,
                    trangThai = data1.Data.TrangThai,
                };
                var data = new ResponseDI<object>();
                data.Data = rTable;
                data.IsSuccess = data1.IsSuccess;
                data.Message = data1.Message;
                return Ok(data);
            }

            return Ok(false);

        }

        public async Task<IActionResult> Create(KetQua item)
        {
            var data = await _unit.KetQua.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(KetQua item)
        {
            var data = await _unit.KetQua.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    data = await _unit.KetQua.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.KetQua.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(KetQua item)
        {
            var data = await _unit.KetQua.Search(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(KetQua item)
        {
            var data = await _unit.KetQua.SearchName(item, GetXacThuc());
            return Ok(data);
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
            return Ok(data.Data);
        }
        #endregion
    }
}
