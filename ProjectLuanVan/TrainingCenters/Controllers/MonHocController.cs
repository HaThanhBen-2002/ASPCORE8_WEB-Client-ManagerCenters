using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class MonHocController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.MonHoc.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.MonHoc.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.MonHoc.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable = new
            {
                maMonHoc = data1.Data.MaMonHoc,
                tenMonHoc = data1.Data.TenMonHoc,
                gia = data1.Data.Gia,
                thongTin = data1.Data.ThongTin,
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(MonHoc item)
        {
            var data = await _unit.MonHoc.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(MonHoc item)
        {
            var data = await _unit.MonHoc.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    data = await _unit.MonHoc.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.MonHoc.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(MonHoc item)
        {
            var data = await _unit.MonHoc.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchName(MonHoc item)
        {
            var data = await _unit.MonHoc.SearchName(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(MonHoc item)
        {
            var data = await _unit.MonHoc.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(MonHoc item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.MonHoc.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
