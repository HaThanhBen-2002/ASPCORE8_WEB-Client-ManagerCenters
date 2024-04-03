using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace ManagementService.Models.Authentication.ResetPassword
{
    public class ResetPassword
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; set; } = null!;
        [Compare("Password", ErrorMessage="Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
