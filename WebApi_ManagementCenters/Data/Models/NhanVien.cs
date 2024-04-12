using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class NhanVien
{
    public int? MaNhanVien { get; set; }

    [Required]
    public string? TenNhanVien { get; set; }

    [Required]
    public string? Cccd { get; set; }

    [Required]
    public string? NgaySinh { get; set; }

    [Required]
    public string? GioiTinh { get; set; }

    [Required]
    public string? DiaChi { get; set; }
    [Required]
    [RegularExpression(@"^(0|\+84)\d{9,10}$")]
    public string? SoDienThoai { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    public string? ThongTin { get; set; }

    public string? HinhAnh { get; set; }

    [Required]
    public int? MaTrungTam { get; set; }

    public string? MaTaiKhoan { get; set; }

    [Required]
    public string? LoaiNhanVien { get; set; }

    [Required]
    public string? PhongBan { get; set; }

    [RegularExpression(@"^[0-9]+$")]
    public string? Luong { get; set; }

    public string? NganHang { get; set; }

    [RegularExpression(@"^[0-9]+$")]
    public string? SoTaiKhoan { get; set; }

    public string? DanToc { get; set; }

    public string? TonGiao { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual ICollection<KetQua> KetQuas { get; set; } = new List<KetQua>();

    public virtual ICollection<LoSanPham> LoSanPhams { get; set; } = new List<LoSanPham>();

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();

    public virtual ApplicationUser? MaTaiKhoanNavigation { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }

    public virtual ICollection<PhieuThuChi> PhieuThuChis { get; set; } = new List<PhieuThuChi>();
}
