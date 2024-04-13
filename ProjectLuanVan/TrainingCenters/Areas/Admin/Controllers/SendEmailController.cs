using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using TrainingCenters.Models.Email;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SendEmailController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;


        #region Api Data
        public async Task<IActionResult> SendEmailText(Message message)
        {
            var status = await _unit.SendEmail.SendEmailText(message);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }


        [HttpPost]
        public async Task<IActionResult> SendEmailKyThuat(Message message)
        {
            message.To = new List<string> {"english4688@gmail.com"};
            var status = await _unit.SendEmail.SendEmailText(message);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }
        public async Task<IActionResult> SendEmailTextDemo()
        {
            var message = new Message(new List<string> { "mavuongkiki2002@gmail.com","english4688@gmail.com" }, "Email Demo BENBEN lần 2", "Đây là nội dung demo"!);
            var status = await _unit.SendEmail.SendEmailText(message);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }
        #endregion
    }
}
