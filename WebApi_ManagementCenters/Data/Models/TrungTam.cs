using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class TrungTam
{
    public int? MaTrungTam { get; set; }
        
    [Required]
    public string? TenTrungTam { get; set; }
    [Required]
    public string? DiaChi { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(20, MinimumLength = 10)]
    public string? MaSoThue { get; set; }
    [Required]
    [RegularExpression(@"^(0|\+84)\d{9,10}$")]
    public string? SoDienThoai { get; set; }

    public string? DienTich { get; set; }

    public string? NganHang { get; set; }

    [RegularExpression(@"^[0-9]+$")]
    public string? SoTaiKhoan { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual ICollection<HocSinh> HocSinhs { get; set; } = new List<HocSinh>();

    public virtual ICollection<KetQua> KetQuas { get; set; } = new List<KetQua>();

    public virtual ICollection<LoSanPham> LoSanPhams { get; set; } = new List<LoSanPham>();

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();

    public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; } = new List<NhaCungCap>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<PhieuThuChi> PhieuThuChis { get; set; } = new List<PhieuThuChi>();

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();

    public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; } = new List<SuDungDichVu>();
}
