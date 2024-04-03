using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? RefreshToken { get; set; } = null!;

        public DateTime? RefreshTokenExpiry { get; set; }

        public bool Khoa { get; set; }

        public int MaTrungTam { get; set; }

        public string? NgayCapNhat { get; set; } = null!;

        public string? NgayTao { get; set; } = null!;

        public string? NgayXoa { get; set; } = null!;

        public string? NguoiXoa { get; set; } = null!;

    }
}
