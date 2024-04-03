using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace IndentityDemo.Controllers
{
    [Authorize(Roles = "Đầu bếp")]
    public class AdminDemoController : Controller
    {
        [HttpGet("/AdminDemo/Get")]
        public IEnumerable<string> Get()
        {
            return new List<string> { "Thanh Bền", "Thanh Thiệt", "Ae một nhà" };
        }
    }
}