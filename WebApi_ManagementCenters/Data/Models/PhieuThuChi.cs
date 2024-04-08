using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class PhieuThuChi
{
    public int? MaPhieu { get; set; }

    [Required]
    public string? NgayTao { get; set; }

    [Required]
    public string? CodeHoaDon { get; set; }

    public string? NgayThanhToan { get; set; }

    [Required]
    public string? LoaiPhieu { get; set; }

    [Required]
    public string? TongTien { get; set; }

    public string? GhiChu { get; set; }

    [Range(1, int.MaxValue)]
    [Required]
    public int? MaTrungTam { get; set; }

    [Required]
    public string? TrangThai { get; set; }

    [Required]
    public string? HinhThucThanhToan { get; set; }

    public int? MaNhanVien { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual ICollection<ChiTietThuChi> ChiTietThuChis { get; set; } = new List<ChiTietThuChi>();

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }
}
