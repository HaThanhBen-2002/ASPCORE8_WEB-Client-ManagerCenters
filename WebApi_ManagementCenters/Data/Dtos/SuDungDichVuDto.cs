using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class SuDungDichVuDto
    {
        public int? MaSuDungDichVu { get; set; }

        public string? TenSuDungDichVu { get; set; }

        public int? MaDichVu { get; set; }

        public int? MaHocSinh { get; set; }

        public int? MaTrungTam { get; set; }

        public string? TrangThai { get; set; }

        public string? NgayBatDau { get; set; }

        public string? NgayKetThuc { get; set; }
    }
}
