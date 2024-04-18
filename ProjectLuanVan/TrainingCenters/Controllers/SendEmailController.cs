using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Newtonsoft.Json;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using TrainingCenters.Models.Email;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class SendEmailController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }

        public async Task<IActionResult> SendEmailText(Message message)
        {
            var data = await _unit.SendEmail.SendEmailText(message, GetXacThuc());
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailKyThuat(Message message)
        {
            message.To = new List<string> {"english4688@gmail.com"};
            var data = await _unit.SendEmail.SendEmailText(message, GetXacThuc());
            return Ok(data);
        }

        #endregion
    }
}
