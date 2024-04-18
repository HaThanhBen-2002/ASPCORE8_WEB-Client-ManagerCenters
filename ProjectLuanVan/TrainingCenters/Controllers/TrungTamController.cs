using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class TrungTamController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.TrungTam.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.TrungTam.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.TrungTam.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable =new { 
                maTrungTam= data1.Data.MaTrungTam, 
                tenTrungTam = data1.Data.TenTrungTam, 
                email = data1.Data.Email, 
                soDienThoai = data1.Data.SoDienThoai, 
                dienTich = data1.Data.DienTich, 
                diaChi = data1.Data.DiaChi
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }

        public async Task<IActionResult> Create(TrungTam item)
        {
            var data = await _unit.TrungTam.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(TrungTam item)
        {
            var data = await _unit.TrungTam.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    data = await _unit.TrungTam.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.TrungTam.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(TrungTam item)
        {
            var data = await _unit.TrungTam.Search(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> SearchName(TrungTam item)
        {
            var data = await _unit.TrungTam.SearchName(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> SearchCount(TrungTam item)
        {
            var data = await _unit.TrungTam.SearchCount(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> LoadingDataTableView(TrungTam item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.TrungTam.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }
        #endregion
    }
}
