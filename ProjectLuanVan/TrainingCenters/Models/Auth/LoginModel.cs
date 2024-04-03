using System.ComponentModel.DataAnnotations;

namespace ManagementService.Models.Authentication.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username không hợp lệ")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password không hợp lệ")]
        public string? Password { get; set; }
    }
}
