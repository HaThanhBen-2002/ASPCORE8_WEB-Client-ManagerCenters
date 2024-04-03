using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public partial class DichVu
{
    public int? MaDichVu { get; set; }

    [Required(ErrorMessage = "Tên dịch vụ không được để trống")]
    public string? TenDichVu { get; set; }

    public string? ThongTin { get; set; }

    [Required(ErrorMessage = "Giá dịch vụ không được để trống")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Vui lòng chỉ nhập các ký tự từ 0 đến 9")]
    public string? Gia { get; set; }

    public string? NgayXoa { get; set; }

    public string? NguoiXoa { get; set; }

    public string? Post { get; set; }

    public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; } = new List<SuDungDichVu>();
}
