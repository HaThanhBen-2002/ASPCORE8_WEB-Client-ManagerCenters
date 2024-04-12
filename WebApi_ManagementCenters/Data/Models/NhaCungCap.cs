using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class NhaCungCap
{
    public int? MaNhaCungCap { get; set; }

    [Required]
    public string? TenNhaCungCap { get; set; }

    public string? GioiThieu { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [RegularExpression(@"^(0|\+84)\d{9,10}$")]
    public string? SoDienThoai { get; set; }

    public string? NganHang { get; set; }

    [RegularExpression(@"^[0-9]+$")]
    public string? SoTaiKhoan { get; set; }

    [RegularExpression(@"^[0-9]+$")]
    public string? MaSoThue { get; set; }

    [Required]
    public int? MaTrungTam { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
