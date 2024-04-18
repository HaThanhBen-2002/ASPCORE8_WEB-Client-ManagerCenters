using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class HocSinhController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.HocSinh.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.HocSinh.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> GetHocSinhView(string id)
        {
            var data = await _unit.HocSinh.GetHocSinhView(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.HocSinh.GetById(Convert.ToInt32(id), GetXacThuc());
            var item1 = await _unit.Lop.GetById(Convert.ToInt32(data1.Data.MaLop), GetXacThuc());
            var rTable = new
            {

                maHocSinh = data1.Data.MaHocSinh,
                tenHocSinh = data1.Data.TenHocSinh,
                ngaySinh = data1.Data.NgaySinh,
                gioiTinh = data1.Data.GioiTinh,
                tenLop = item1.Data.TenLop,
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(HocSinh item)
        {
            var data = await _unit.HocSinh.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(HocSinh item)
        {
            var data = await _unit.HocSinh.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    data = await _unit.HocSinh.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.HocSinh.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(HocSinh item)
        {
            var data = await _unit.HocSinh.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(HocSinh item)
        {
            var data = await _unit.HocSinh.SearchName(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(HocSinh item)
        {
            var data = await _unit.HocSinh.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(HocSinh item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.HocSinh.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
