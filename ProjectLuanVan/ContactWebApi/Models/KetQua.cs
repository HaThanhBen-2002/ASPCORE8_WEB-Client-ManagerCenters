using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebApi.Models
{
    public class KetQua
    {
        public int? MaKetQua { get; set; }

        public string? TenKetQua { get; set; }

        public int? MaHocSinh { get; set; }

        public int? MaMonHoc { get; set; }

        public string? Diem { get; set; }

        public string? XepLoai { get; set; }

        public string? NgayKiemTra { get; set; }

        public string? TrangThai { get; set; }

        public int? MaNhanVien { get; set; }

        public int? MaTrungTam { get; set; }
    }
}
