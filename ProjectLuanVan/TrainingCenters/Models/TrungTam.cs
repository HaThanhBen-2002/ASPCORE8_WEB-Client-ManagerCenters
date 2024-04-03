using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenters.Models
{
    public class TrungTam
    {
        public int? MaTrungTam { get; set; }

        public string? TenTrungTam { get; set; }
        public string? DiaChi { get; set; }

        public string? Email { get; set; }

        public string? MaSoThue { get; set; }
        public string? SoDienThoai { get; set; }

        public string? DienTich { get; set; }

        public string? NganHang { get; set; }

        public string? SoTaiKhoan { get; set; }

    }
}
