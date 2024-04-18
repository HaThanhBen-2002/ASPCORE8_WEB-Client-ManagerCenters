using Data.Models;
using ManagementApi.Models;
using ManagementService.Models;
using ManagementService.Models.Authentication.SignUp;
using ManagementService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ManagementApi.Controllers
{
    [Authorize(Roles = "Giáo viên,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : Controller
    {
        private readonly IEmailService _emailService;

        public SendEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        [Route("SendEmailText")]
        public async Task<IActionResult> SendEmailText([FromBody] MessageText message)
        {

            if (message!=null)
            {
                var message1 = new ManagementService.Models.Message(message.To, message.Subject, message.Content);
                var responseMsg = _emailService.SendEmail(message1);
                return StatusCode(StatusCodes.Status200OK,
                        new Response { IsSuccess = true, Message = "Gửi email thành công" });
            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                  new Response { Message = "Gửi email thất bại", IsSuccess = false });
        }

        //[HttpPost]
        //[Route("SendEmailDemo")]
        //public async Task<IActionResult> SendEmailDemo()
        //{

        //        var message = new ManagementService.Models.Message(new string[] { "mavuongkiki2002@gmail.com","english4688@gmail.com" }, "Email Demo BENBEN", "Đây là nội dung demo"!);
        //        var responseMsg = _emailService.SendEmail(message);
        //        return StatusCode(StatusCodes.Status200OK,
        //                new Response { IsSuccess = true, Message = "Gửi email thành công" });
        //}
    }
}
