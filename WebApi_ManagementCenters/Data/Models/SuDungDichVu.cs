using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class SuDungDichVu
{
    public int? MaSuDungDichVu { get; set; }
    [Required]
    public string? TenSuDungDichVu { get; set; }

    [Range(1, int.MaxValue)]
    [Required]
    public int? MaDichVu { get; set; }

    [Range(1, int.MaxValue)]
    [Required]
    public int? MaHocSinh { get; set; }

    [Range(1, int.MaxValue)]
    [Required]
    public int? MaTrungTam { get; set; }

    [Required]
    public string? TrangThai { get; set; }

    [Required]
    public string? NgayBatDau { get; set; }

    [Required]
    public string? NgayKetThuc { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public virtual DichVu? MaDichVuNavigation { get; set; }

    public virtual HocSinh? MaHocSinhNavigation { get; set; }

    public virtual TrungTam? MaTrungTamNavigation { get; set; }
}
