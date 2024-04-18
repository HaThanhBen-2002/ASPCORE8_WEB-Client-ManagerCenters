using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class LopController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
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
            var data1 = await _unit.Lop.GetById(Convert.ToInt32(id), GetXacThuc());
            var item1 = await _unit.NhanVien.GetById(Convert.ToInt32(data1.Data.MaNhanVien), GetXacThuc());
            var rTable = new
            {
                maLop = data1.Data.MaLop,
                tenLop = data1.Data.TenLop,
                tenGiaoVien = item1.Data.TenNhanVien,
                hocPhi = data1.Data.HocPhi,
                namHoc = data1.Data.NamHoc,
            };

            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(Lop item)
        {
            var data = await _unit.Lop.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(Lop item)
        {
            var data = await _unit.Lop.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    data = await _unit.Lop.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.Lop.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(Lop item)
        {
            var data = await _unit.Lop.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(Lop item)
        {
            var data = await _unit.Lop.SearchName(item, GetXacThuc());
            return Ok(data);
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
            return Ok(data.Data);
        }
        #endregion
    }
}
