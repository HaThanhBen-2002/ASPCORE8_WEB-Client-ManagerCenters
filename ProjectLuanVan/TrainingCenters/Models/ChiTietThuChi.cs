using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenters.Models
{
    public class ChiTietThuChi
    {
        public int? MaChiTiet { get; set; }

        public string? TenChiTiet { get; set; }

        public string? DonVi { get; set; }

        public string? SoLuong { get; set; }

        public string? TongTien { get; set; }

        public int? MaPhieu { get; set; }

    }
}
