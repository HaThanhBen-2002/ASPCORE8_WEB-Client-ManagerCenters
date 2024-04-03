using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class SanPhamDto
    {
        public int? MaSanPham { get; set; }

        public string? TenSanPham { get; set; }

        public string? ThongTin { get; set; }

        public string? LoaiSanPham { get; set; }

        public string? HanSuDung { get; set; }

        public int? MaNhaCungCap { get; set; }

        public int? MaTrungTam { get; set; }

        public string? Gia { get; set; }
    }
}
