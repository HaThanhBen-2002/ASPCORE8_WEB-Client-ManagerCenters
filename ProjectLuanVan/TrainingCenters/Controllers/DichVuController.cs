using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using TrainingCenters.Models.Auth;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class DichVuController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.DichVu.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.DichVu.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            
            var data1 = await _unit.DichVu.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable = new
            {
                maDichVu = data1.Data.MaDichVu,
                tenDichVu = data1.Data.TenDichVu,
                gia = data1.Data.Gia
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(DichVu item)
        {
            
            var data = await _unit.DichVu.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(DichVu item)
        {
            
            var data = await _unit.DichVu.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    data = await _unit.DichVu.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            
            var data = await _unit.DichVu.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(DichVu item)
        {
            var data = await _unit.DichVu.Search(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(DichVu item)
        {
            
            var data = await _unit.DichVu.SearchName(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(DichVu item)
        {
            
            var data = await _unit.DichVu.SearchCount(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> LoadingDataTableView(DichVu item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            
            var data = await _unit.DichVu.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
