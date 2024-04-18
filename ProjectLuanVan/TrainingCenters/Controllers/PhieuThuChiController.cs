using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using System.Linq;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrainingCenters.Controllers
{
    public class PhieuThuChiController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;

        public string GenerateInvoiceCode(string loaiHoaDon)
        {
            string textCode = "";
            if(loaiHoaDon == "Hóa đơn thu")
            {
                textCode = "HDT";
            }
            else if(loaiHoaDon == "Hóa đơn chi")
            {
                textCode = "HDC";
            }
            else if (loaiHoaDon == "Hóa đơn tạm ứng")
            {
                textCode = "HDU";
            }
            else if (loaiHoaDon == "Hóa đơn khác")
            {
                textCode = "HDK";
            }
            else 
            {
                textCode = "HD";
            }
            // Lấy thời gian hiện tại
            DateTime currentTime = DateTime.Now;

            // Tạo mã hóa đơn từ thông tin thời gian
            string invoiceCode = string.Format(textCode + "-{0}{1}{2}-{3}{4}{5}-{6}",
                                                currentTime.Year,
                                                currentTime.Month.ToString("00"),
                                                currentTime.Day.ToString("00"),
                                                currentTime.Hour.ToString("00"),
                                                currentTime.Minute.ToString("00"),
                                                currentTime.Second.ToString("00"),
                                                currentTime.Millisecond.ToString("000"));

            return invoiceCode;
        }
        #region Api Data
        private string GetXacThuc()
        {
            return HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.PhieuThuChi.GetAll(GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.PhieuThuChi.GetById(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data1 = await _unit.PhieuThuChi.GetById(Convert.ToInt32(id), GetXacThuc());
            var rTable = new
            {
                maPhieu = data1.Data.MaPhieu,
                loaiPhieu = data1.Data.LoaiPhieu,
                tongTien = data1.Data.TongTien,
                ngayTao = data1.Data.NgayTao,
                hinhThucThanhToan = data1.Data.HinhThucThanhToan,
                trangThai = data1.Data.TrangThai
            };
            var data = new ResponseDI<object>();
            data.Data = rTable;
            data.IsSuccess = data1.IsSuccess;
            data.Message = data1.Message;
            return Ok(data);

        }
        private string GetDateNow()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        public async Task<IActionResult> Create(PhieuThuChi item, List<ChiTietThuChi> chiTietThuChis, bool thanhToan)
        {
            var statusCreate = new ResponseDI<bool>();
            var data = new ResponseDI<PhieuThuChi>();
            if(item!= null)
            {
                if(item.LoaiPhieu != null)
                {
                    item.NgayTao = GetDateNow();
                    
                    item.CodeHoaDon = GenerateInvoiceCode(item.LoaiPhieu);
                    if (thanhToan == true)
                    {
                        item.TrangThai = "Đã thanh toán";
                        item.NgayThanhToan = item.NgayTao;
                    }
                    else if(item.HinhThucThanhToan == "Trả góp")
                    {
                        item.TrangThai = "Đang trả góp";
                        item.NgayThanhToan = null;
                    }
                    else
                    {
                        item.TrangThai = "Chưa thanh toán";
                        item.NgayThanhToan = null;
                    }

                    var status = await _unit.PhieuThuChi.Create(item, GetXacThuc());
                    if (status.Data)
                    {
                        var phieuThuChiNew =await _unit.PhieuThuChi.Search(item, GetXacThuc());
                        if (phieuThuChiNew.IsSuccess)
                        {
                            int idPhieu = 0;
                            foreach (var n in phieuThuChiNew.Data)
                            {
                                if (n != null)
                                {
                                    idPhieu = (int)n.MaPhieu;
                                    break;
                                }
                            }
                            foreach (var ct in chiTietThuChis)
                            {
                                
                                ct.MaPhieu = idPhieu;
                                statusCreate = await _unit.ChiTietThuChi.Create(ct, GetXacThuc());
                            }
                        }
                    }
                }
            }
            if (statusCreate.Data == true)
            {
                data.IsSuccess = true;
                data.Message = "Thành Công";
                data.Data = item;
            }
            else
            {
                data.IsSuccess = false;
                data.Message = "Thất bại";
            }
            return Ok(data);
        }

        public async Task<IActionResult> Update(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.Update(item, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> UpdateThanhToan(string id)
        {
            var data1 = await _unit.PhieuThuChi.GetById(Convert.ToInt32(id), GetXacThuc());
            data1.Data.TrangThai = "Đã thanh toán";
            data1.Data.NgayThanhToan = GetDateNow();
            var data = await _unit.PhieuThuChi.Update(data1.Data, GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            var data = new ResponseDI<bool>();
            if (ids != null)
            {
                foreach (int id in ids)
                {

                    data = await _unit.PhieuThuChi.Delete(Convert.ToInt32(id), nguoiXoa, GetXacThuc());
                }
                return Ok(data);
            }
            return Ok(data);
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var data = await _unit.PhieuThuChi.CheckId(Convert.ToInt32(id), GetXacThuc());
            return Ok(data);
        }

        public async Task<IActionResult> Search(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.Search(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchTongTien(PhieuThuChi item)
        {
            item.TrangThai = "Đã thanh toán";
            var data = await _unit.PhieuThuChi.SearchTongTien(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.SearchCount(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(PhieuThuChi item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.PhieuThuChi.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length), GetXacThuc());
            return Ok(data.Data);
        }

        public async Task<IActionResult> HoaDonThuThang(PhieuThuChi item)
        {
            item.LoaiPhieu = "Hóa đơn thu";
            item.TrangThai = "Đã thanh toán";
            var data = await _unit.PhieuThuChi.SearchTongTien(item, GetXacThuc());
            return Ok(data);
        }
        public async Task<IActionResult> HoaDonChiThang(PhieuThuChi item)
        {
            item.TrangThai = "Đã thanh toán";
            item.LoaiPhieu = "Hóa đơn chi";
            var hoaDonChi = await _unit.PhieuThuChi.SearchTongTien(item, GetXacThuc());

            item.LoaiPhieu = "Hóa đơn khác";
            var hoaDonKhac = await _unit.PhieuThuChi.SearchTongTien(item, GetXacThuc());

            item.LoaiPhieu = "Hóa đơn tạm ứng";
            var hoaDonTamUng = await _unit.PhieuThuChi.SearchTongTien(item, GetXacThuc());

            var tongChi = hoaDonChi.Data + hoaDonKhac.Data + hoaDonTamUng.Data;
            var data = new ResponseDI<double>();
            data.IsSuccess = hoaDonChi.IsSuccess;
            data.Message = hoaDonChi.Message;
            data.Data = tongChi;

            return Ok(data);
        }
        #endregion
    }
}
