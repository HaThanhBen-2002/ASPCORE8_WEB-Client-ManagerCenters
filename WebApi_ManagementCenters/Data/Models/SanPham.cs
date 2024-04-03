using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class SanPham
{
    public int? MaSanPham { get; set; }

    [Required]
    public string? TenSanPham { get; set; }

    [StringLength(1000, MinimumLength = 0)]
    public string? ThongTin { get; set; }

    [Required]
    public string? LoaiSanPham { get; set; }

    [Required]
    public string? HanSuDung { get; set; }

    [Range(1, int.MaxValue)]
    [Required]
    public int? MaNhaCungCap { get; set; }

    [Range(1, int.MaxValue)]
    [Required]
    public int? MaTrungTam { get; set; }

    [Required]
    public string? Gia { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual ICollection<LoSanPham> LoSanPhams { get; set; } = new List<LoSanPham>();

    public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }
}
