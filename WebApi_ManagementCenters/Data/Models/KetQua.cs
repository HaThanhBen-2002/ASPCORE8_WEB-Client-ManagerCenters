using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class KetQua
{
    public int? MaKetQua { get; set; }

    [Required]
    public string? TenKetQua { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaHocSinh { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaMonHoc { get; set; }

    [Required]
    [Range(0, 10)]
    public string? Diem { get; set; }

    [Required]
    public string? XepLoai { get; set; }

    [Required]
    public string? NgayKiemTra { get; set; }

    [Required]
    public string? TrangThai { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaNhanVien { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaTrungTam { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual HocSinh? MaHocSinhNavigation { get; set; }

    public virtual MonHoc? MaMonHocNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }
}
