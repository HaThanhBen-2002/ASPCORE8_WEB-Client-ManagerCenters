using Data.Dtos;
using Data.InterfacesData;
using Data.Models;
using ManagementApi.Models;
using ManagementService.Models.Authentication.User;
using ManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace ManagementApi.Controllers
{
    //[Authorize(Roles = "Giáo viên,Admin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrungTamController : ControllerBase
    {
        private readonly IAppServices _appServices;

        public TrungTamController(IAppServices appServices)
        {
            _appServices = appServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<TrungTamDto>>> GetAll()
        {
            var itemAll = await _appServices.TrungTam.GetAll();
            return itemAll.ToList();
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create(TrungTamDto item)
        {
            if(item != null)
            {
                if (await _appServices.TrungTam.Create(item))
                {
                    return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Status = "Success", Message = $"Thêm dữ liệu thành công" });
                }

            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Thêm dữ liệu thất bại" });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(TrungTamDto item)
        {
            if (item != null)
            {
                if (await _appServices.TrungTam.Update(item))
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
                if (await _appServices.TrungTam.Delete(id, nguoiXoa))
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
                if (await _appServices.TrungTam.CheckId(id))
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
                return Ok(await _appServices.TrungTam.GetById(id));
            }
            return StatusCode(StatusCodes.Status200OK,
                          new Response { IsSuccess = false, Status = "Error", Message = $"Dữ liệu không tồn tại trong hệ thống" });
        }


        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<TrungTamDto>>> Search(TrungTamDto item)
        {
            var itemAll = await _appServices.TrungTam.Search(item);
            return itemAll.ToList();
        }

        [HttpPost("SearchName")]
        public async Task<IActionResult> SearchName(TrungTamDto item)
        {
            var itemAll = await _appServices.TrungTam.SearchName(item);
            return Ok(itemAll);
        }

        [HttpPost("SearchCount")]
        public async Task<IActionResult> SearchCount(TrungTamDto item)
        {
            var itemAll = await _appServices.TrungTam.SearchCount(item);
            return Ok(itemAll);
        }

        [HttpPost("LoadingDataTableView")]
        public async Task<ActionResult<IEnumerable<TrungTamDto>>> LoadingDataTableView(TrungTamDto item, int skip, int take)
        {
            return Ok(_appServices.TrungTam.LoadingDataTableView(item, skip, take));
        }

    }
}
