using System.ComponentModel.DataAnnotations;

namespace ManagementService.Models.Authentication.Login
{
    public class LoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
