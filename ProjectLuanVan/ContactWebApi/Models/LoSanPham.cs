using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebApi.Models
{
    public class LoSanPham
    {
        public int? MaLoSanPham { get; set; }

        public string? TenLoSanPham { get; set; }

        public string? TrangThai { get; set; }

        public int? MaSanPham { get; set; }

        public string? SoLuong { get; set; }

        public string? DonVi { get; set; }

        public string? NgayNhap { get; set; }

        public string? NgayHetHan { get; set; }

        public int? MaNhanVien { get; set; }

        public int? MaTrungTam { get; set; }

        public string? GhiChu { get; set; }

    }
}
