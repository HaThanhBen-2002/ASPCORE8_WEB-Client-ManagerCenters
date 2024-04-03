using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class MonHoc
{
    public int? MaMonHoc { get; set; }

    [Required]
    public string? TenMonHoc { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]+$")]
    public string? Gia { get; set; }

    public string? ThongTin { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual ICollection<KetQua> KetQuas { get; set; } = new List<KetQua>();
}
