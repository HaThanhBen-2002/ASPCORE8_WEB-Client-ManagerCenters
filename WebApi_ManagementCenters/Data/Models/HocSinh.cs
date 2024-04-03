using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class HocSinh
{
    public int? MaHocSinh { get; set; }

    [Required]
    public string? TenHocSinh { get; set; }

    [Required]
    public string? NgaySinh { get; set; }

    [Required]
    public string? GioiTinh { get; set; }

    [Range(1, int.MaxValue)]
    public int? MaLop { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaTrungTam { get; set; }

    public string? ThongTin { get; set; }

    public string? HinhAnh { get; set; }

    public string? DiaChi { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public string? ChieuCao { get; set; }

    public string? CanNang { get; set; }

    public string? TinhTrangRang { get; set; }

    public string? TinhTrangMat { get; set; }

    public string? Bmi { get; set; }

    public string? TinhTrangTamLy { get; set; }

    public string? ChucNangCoThe { get; set; }

    public string? DanhGiaSucKhoe { get; set; }

    [RegularExpression(@"^[0-9]+$")]
    public string? Cccdcha { get; set; }

    [RegularExpression(@"^[0-9]+$")]
    public string? Cccdme { get; set; }

    public string? TenCha { get; set; }

    public string? TenMe { get; set; }

    public string? NgaySinhCha { get; set; }

    public string? NgaySinhMe { get; set; }

    [RegularExpression(@"^(0|\+84)\d{9,10}$")]
    public string? SoDienThoaiCha { get; set; }

    [RegularExpression(@"^(0|\+84)\d{9,10}$")]
    public string? SoDienThoaiMe { get; set; }

    [EmailAddress]
    public string? EmailCha { get; set; }

    [EmailAddress]
    public string? EmailMe { get; set; }

    public string? NgheNghiepCha { get; set; }

    public string? NgheNghiepMe { get; set; }

    public virtual ICollection<KetQua> KetQuas { get; set; } = new List<KetQua>();

    public virtual Lop? MaLopNavigation { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }

    public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; } = new List<SuDungDichVu>();
}
