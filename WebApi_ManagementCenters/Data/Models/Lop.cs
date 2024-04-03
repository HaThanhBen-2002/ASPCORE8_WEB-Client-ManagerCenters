using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class Lop
{
    public int? MaLop { get; set; }

    [Required]
    public string? TenLop { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaNhanVien { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? MaTrungTam { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? NamHoc { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]+$")]
    public string? HocPhi { get; set; }

    [Required]
    public string? LichHoc { get; set; }

    public string? ThongTin { get; set; }

    [Required]
    public string? NgayBatDau { get; set; }

    [Required]
    public string? NgayKetThuc { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual ICollection<HocSinh> HocSinhs { get; set; } = new List<HocSinh>();

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }
}
