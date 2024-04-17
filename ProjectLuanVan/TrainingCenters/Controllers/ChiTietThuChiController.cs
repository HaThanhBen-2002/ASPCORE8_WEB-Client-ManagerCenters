using Microsoft.AspNetCore.Mvc;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class ChiTietThuChiController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> Create(ChiTietThuChi item)
        {
            var data = await _unit.ChiTietThuChi.Create(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Update(ChiTietThuChi item)
        {
            var data = await _unit.ChiTietThuChi.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {

                    data = await _unit.ChiTietThuChi.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.ChiTietThuChi.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(ChiTietThuChi item)
        {
            var data = await _unit.ChiTietThuChi.Search(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> SearchByPhieuThuChiId(string id)
        {
            var data = await _unit.ChiTietThuChi.SearchByPhieuThuChiId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }
        #endregion
    }
}
