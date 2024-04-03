using Data.Models;
using Microsoft.Build.Framework;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ManagementService.Models.Authentication.SignUp
{
    public class RegisterUser
    {
        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public int MaTrungTam { get; set; }

        public List<string>? Roles { get; set; }
    }
}
