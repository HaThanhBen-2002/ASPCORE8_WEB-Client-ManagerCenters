using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using TrainingCenters.InterfacesApi;
using TrainingCenters.Models;

namespace TrainingCenters.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhieuThuChiController(IUnitOfWork unit) : Controller
    {
        private readonly IUnitOfWork _unit = unit;


        public IActionResult Index()
        {
            TempData["menu"] = "PhieuThuChi";
            return View();
        }

        public IActionResult ChiTietHoaDon()
        {
            TempData["menu"] = "PhieuThuChi";
            return View();
        }
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
        public async Task<IActionResult> GetAll()
        {
            var data = await _unit.PhieuThuChi.GetAll();
            return Ok(data);
        }

        public async Task<IActionResult> GetById(string id)
        {
            var data = await _unit.PhieuThuChi.GetById(Convert.ToInt32(id));
            return Ok(data);
        }

        public async Task<IActionResult> GetByIdTable(string id)
        {
            var data = await _unit.PhieuThuChi.GetById(Convert.ToInt32(id));
            var rTable = new
            {
                maPhieu = data.MaPhieu,
                loaiPhieu = data.LoaiPhieu,
                tongTien = data.TongTien,
                ngayTao = data.NgayTao,
                hinhThucThanhToan = data.HinhThucThanhToan,
                trangThai = data.TrangThai
            };
            return Ok(rTable);

        }
        private string GetDateNow()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        public async Task<IActionResult> Create(PhieuThuChi item, List<ChiTietThuChi> chiTietThuChis)
        {
            bool statusCreate = false;
            if(item!= null)
            {
                if(item.LoaiPhieu != null)
                {
                    item.CodeHoaDon = GenerateInvoiceCode(item.LoaiPhieu);
                    item.TrangThai = "Thành công";
                    item.NgayTao = GetDateNow();
                    item.NgayThanhToan = item.NgayTao;
                    var status = await _unit.PhieuThuChi.Create(item);
                    if (status)
                    {
                        var phieuThuChiNew = await _unit.PhieuThuChi.Search(item) as List<PhieuThuChi>;
                        if(phieuThuChiNew != null)
                        {
                            foreach (var ct in chiTietThuChis)
                            {
                                ct.MaPhieu = phieuThuChiNew[0].MaPhieu;
                                statusCreate = await _unit.ChiTietThuChi.Create(ct);
                            }
                        }
                    }
                }
            }
            if (statusCreate == true)
            {
                return Ok(item);
            }
            return Ok(null);
        }

        public async Task<IActionResult> Update(PhieuThuChi item)
        {
            var status = await _unit.PhieuThuChi.Update(item);
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Delete(int[]? ids, string nguoiXoa)
        {
            if (ids != null)
            {
                bool dl = false;
                foreach (int id in ids)
                {
                    dl = await _unit.PhieuThuChi.Delete(Convert.ToInt32(id), nguoiXoa);
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = dl });
            }
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = false });
        }

        public async Task<IActionResult> CheckId(string id)
        {
            var status = await _unit.PhieuThuChi.CheckId(Convert.ToInt32(id));
            return StatusCode(StatusCodes.Status200OK, new ApiResponse { IsSuccess = status });
        }

        public async Task<IActionResult> Search(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.Search(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchTongTien(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.SearchTongTien(item);
            return Ok(data);
        }
        public async Task<IActionResult> SearchCount(PhieuThuChi item)
        {
            var data = await _unit.PhieuThuChi.SearchCount(item);
            return Ok(data);
        }
        public async Task<IActionResult> LoadingDataTableView(PhieuThuChi item)
        {
            var skip = Request.Form["start"];
            var length = Request.Form["length"];
            var data = await _unit.PhieuThuChi.LoadingDataTableView(item, Convert.ToInt32(skip), Convert.ToInt32(length));
            return Ok(data);
        }
        #endregion
    }
}
