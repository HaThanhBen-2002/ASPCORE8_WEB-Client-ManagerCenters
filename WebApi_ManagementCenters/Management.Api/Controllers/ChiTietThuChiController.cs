using Data.Dtos;
using ManagementApi.Models;
using ManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApi.Controllers
{
    //[Authorize(Roles = "Giáo viên,Admin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietThuChiController : Controller
    {
        private readonly IAppServices _appServices;

        public ChiTietThuChiController(IAppServices appServices)
        {
            _appServices = appServices;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ChiTietThuChiDto item)
        {
            if (item != null)
            {
                if (await _appServices.ChiTietThuChi.Create(item))
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Status = "Success", Message = $"Thêm dữ liệu thành công" });
                }

            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Thêm dữ liệu thất bại" });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ChiTietThuChiDto item)
        {
            if (item != null)
            {
                if (await _appServices.ChiTietThuChi.Update(item))
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Status = "Success", Message = $"Cập nhật dữ liệu thành công" });
                }

            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Cập nhật dữ liệu thất bại" });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, string nguoiXoa)
        {
            if (id != 0)
            {
                if (await _appServices.ChiTietThuChi.Delete(id, nguoiXoa))
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Status = "Success", Message = $"Xóa dữ liệu thành công" });
                }

            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Xóa dữ liệu thất bại" });
        }

        [HttpGet("CheckId")]
        public async Task<IActionResult> CheckId(int id)
        {
            if (id != 0)
            {
                if (await _appServices.ChiTietThuChi.CheckId(id))
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Status = "Success", Message = $"Dữ liệu có trong hệ thống" });
                }

            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Dữ liệu không tồn tại trong hệ thống" });
        }

     
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<ChiTietThuChiDto>>> Search(ChiTietThuChiDto item)
        {
            var itemAll = await _appServices.ChiTietThuChi.Search(item);
            return itemAll.ToList();
        }

        [HttpPost("SearchByPhieuThuChiId")]
        public async Task<ActionResult<IEnumerable<ChiTietThuChiDto>>> SearchByPhieuThuChiId(int id)
        {
            var itemAll = await _appServices.ChiTietThuChi.SearchByPhieuThuChiId(id);
            return itemAll.ToList();
        }
    }
}
