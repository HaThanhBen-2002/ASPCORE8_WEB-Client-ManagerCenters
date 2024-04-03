using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebApi.Models
{
    public class PhieuThuChi
    {
        public int? MaPhieu { get; set; }

        public string? NgayTao { get; set; }

        public string? NgayThanhToan { get; set; }

        public string? LoaiPhieu { get; set; }

        public string? TongTien { get; set; }

        public string? GhiChu { get; set; }

        public int? MaTrungTam { get; set; }

        public string? TrangThai { get; set; }

        public string? HinhThucThanhToan { get; set; }

        public int? MaNhanVien { get; set; }
    }
}
