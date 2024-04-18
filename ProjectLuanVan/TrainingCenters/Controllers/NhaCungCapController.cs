using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class NhaCungCapController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.NhaCungCap.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.NhaCungCap.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.NhaCungCap.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable = new
            {
                maNhaCungCap = data1.Data.MaNhaCungCap,
                tenNhaCungCap = data1.Data.TenNhaCungCap,
                email = data1.Data.Email,
                soDienThoai = data1.Data.SoDienThoai,
                maSoThue = data1.Data.MaSoThue
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(NhaCungCap item)
        {
            var data = await _unit.NhaCungCap.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(NhaCungCap item)
        {
            var data = await _unit.NhaCungCap.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    data = await _unit.NhaCungCap.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.NhaCungCap.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(NhaCungCap item)
        {
            var data = await _unit.NhaCungCap.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(NhaCungCap item)
        {
            var data = await _unit.NhaCungCap.SearchName(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(NhaCungCap item)
        {
            var data = await _unit.NhaCungCap.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(NhaCungCap item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.NhaCungCap.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
