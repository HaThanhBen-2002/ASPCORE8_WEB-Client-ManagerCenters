using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class LoSanPham
{
    public int? MaLoSanPham { get; set; }

    [Required]
    public string? TenLoSanPham { get; set; }

    [Required]
    public string? TrangThai { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaSanPham { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]+$")]
    public string? SoLuong { get; set; }

    [Required]
    public string? DonVi { get; set; }

    [Required]
    public string? NgayNhap { get; set; }

    [Required]
    public string? NgayHetHan { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaNhanVien { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaTrungTam { get; set; }

    public string? GhiChu { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }
}
