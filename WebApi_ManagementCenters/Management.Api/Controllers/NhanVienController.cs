using Data.Dtos;
using ManagementApi.Models;
using ManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : Controller
    {
        private readonly IAppServices _appServices;

        public NhanVienController(IAppServices appServices)
        {
            _appServices = appServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<NhanVienDto>>> GetAll()
        {
            var itemAll = await _appServices.NhanVien.GetAll();
            return itemAll.ToList();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(NhanVienDto item)
        {
            if (item != null)
            {
                if (await _appServices.NhanVien.Create(item))
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Status = "Success", Message = $"Thêm dữ liệu thành công" });
                }

            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Thêm dữ liệu thất bại" });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(NhanVienDto item)
        {
            if (item != null)
            {
                if (await _appServices.NhanVien.Update(item))
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
                if (await _appServices.NhanVien.Delete(id, nguoiXoa))
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
                if (await _appServices.NhanVien.CheckId(id))
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Status = "Success", Message = $"Dữ liệu có trong hệ thống" });
                }

            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Dữ liệu không tồn tại trong hệ thống" });
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id != 0)
            {
                return Ok(await _appServices.NhanVien.GetById(id));
            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Dữ liệu không tồn tại trong hệ thống" });
        }

        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<NhanVienDto>>> Search(NhanVienDto item)
        {
            var itemAll = await _appServices.NhanVien.Search(item);
            return itemAll.ToList();
        }
        [HttpPost("SearchName")]
        public async Task<IActionResult> SearchName(NhanVienDto item)
        {
            var itemAll = await _appServices.NhanVien.SearchName(item);
            return Ok(itemAll);
        }

        [HttpPost("SearchCount")]
        public async Task<IActionResult> SearchCount(NhanVienDto item)
        {
            var itemAll = await _appServices.NhanVien.SearchCount(item);
            return Ok(itemAll);
        }
        [HttpPost("LoadingDataTableView")]
        public async Task<ActionResult<IEnumerable<NhanVienDto>>> LoadingDataTableView(NhanVienDto item, int skip, int take)
        {
            return Ok(_appServices.NhanVien.LoadingDataTableView(item, skip, take));
        }
    }
}
