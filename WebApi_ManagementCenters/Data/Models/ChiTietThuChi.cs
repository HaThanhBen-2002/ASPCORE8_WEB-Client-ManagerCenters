using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class ChiTietThuChi
{
    public int? MaChiTiet { get; set; }

    public string? TenChiTiet { get; set; }

    public string? DonVi { get; set; }

    public string? SoLuong { get; set; }

    public string? TongTien { get; set; }

    public int? MaPhieu { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual PhieuThuChi? MaPhieuNavigation { get; set; }
}
