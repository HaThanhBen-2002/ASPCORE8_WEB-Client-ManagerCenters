
// ============= Thống kê số lượng =============

async function ThongKeSoLuong() {
    $('#thongKe_TrungTam').text(await TKSL_TrungTam_Search(null));
    $('#thongKe_DichVu').text(await TKSL_DichVu_Search(null));
    $('#thongKe_SanPham').text(await TKSL_SanPham_Search(null));
    $('#thongKe_HoaDon').text(await TKSL_HoaDon_Search(null));
    $('#thongKe_NhanVien').text(await TKSL_NhanVien_Search(null));
    $('#thongKe_NhaCungCap').text(await TKSL_NhaCungCap_Search(null));
    $('#thongKe_MonHoc').text(await TKSL_MonHoc_Search(null));
    $('#thongKe_Lop').text(await TKSL_Lop_Search(null));
    $('#thongKe_KetQua').text(await TKSL_KetQua_Search(null));
    $('#thongKe_HocSinh').text(await TKSL_HocSinh_Search(null));
}


let chartHinhThucThanhToan;
async function HinhThucThanhToan(maTrungTam) {
    // lấy tháng để thống kê
    let thang = $('#hinhThucThanhToan_Thang').val();
    // lấy năm để thống kê
    let nam = $('#hinhThucThanhToan_Nam').val();
    let theoluot = $('#hinhThucThanhToan_Luot').prop('checked');

    if (chartHinhThucThanhToan) {
        chartHinhThucThanhToan.destroy();
    }
    // Khởi tạo biểu đồ mới
    chartHinhThucThanhToan = new ApexCharts($("#chartHinhThucThanhToan")[0], await GetOptions_HinhThucThanhToan(maTrungTam, thang, nam, theoluot));
    chartHinhThucThanhToan.render();
}

let chartTyLeHoaDon;
let chartTyLeHoaDonDaThanhToan;
async function TyLeHoaDon(maTrungTam) {
    
    let thang = $('#tyLeHoaDon_Thang').val();
    // lấy năm để thống kê
    let nam = $('#tyLeHoaDon_Nam').val();
    
    if (chartTyLeHoaDon) {
        chartTyLeHoaDon.destroy();
    }
    if (chartTyLeHoaDonDaThanhToan) {
        chartTyLeHoaDonDaThanhToan.destroy();
    }
    // Khởi tạo biểu đồ mới
    chartTyLeHoaDon = new ApexCharts($("#chartTyLeHoaDon")[0],await GetOptions_TyLeHoaDon(maTrungTam, thang, nam));
    chartTyLeHoaDon.render();
    chartTyLeHoaDonDaThanhToan = new ApexCharts($("#chartTyLeHoaDonDaThanhToan")[0], await GetOptions_TyLeHoaDonDaThanhToan(maTrungTam, thang, nam));
    chartTyLeHoaDonDaThanhToan.render();
    
}

let chartDoanhThuHoaDon;
async function DoanhThuHoaDon(maTrungTam) {
    let year = $('#doanhThuHoaDon_Nam').val();
    if (chartDoanhThuHoaDon) {
        chartDoanhThuHoaDon.destroy();
    }
    // Khởi tạo biểu đồ mới
    chartDoanhThuHoaDon = new ApexCharts($("#chartDoanhThuHoaDon")[0],await GetOptions_DoanhThuHoaDon(maTrungTam, year));
    chartDoanhThuHoaDon.render();
}

let chartSoSanhDoanhThuChuoiTrungTam;
async function SoSanhDoanhThuChuoiTrungTam(nam) {
    let year = $('#chartSoSanhDoanhThuChuoiTrungTam').val();
    if (chartSoSanhDoanhThuChuoiTrungTam) {
        chartSoSanhDoanhThuChuoiTrungTam.destroy();
    }
    // Khởi tạo biểu đồ mới
    chartSoSanhDoanhThuChuoiTrungTam = new ApexCharts($("#chartSoSanhDoanhThuChuoiTrungTam")[0],await GetOptions_DoanhThuTatCaTrungTam(nam));
    chartSoSanhDoanhThuChuoiTrungTam.render();
}

$(document).ready(function () {
    $('#tyLeHoaDon_Nam').val(getCurrentYear());
    $('#soSanhDoanhThuChuoiTrungTam_Nam').val(getCurrentYear());
    $('#hinhThucThanhToan_Nam').val(getCurrentYear());
    $('#doanhThuHoaDon_Nam').val(getCurrentYear());

    ThongKeSoLuong();
    TyLeHoaDon(null);
    SoSanhDoanhThuChuoiTrungTam($('#soSanhDoanhThuChuoiTrungTam_Nam').val());
    DoanhThuHoaDon(null);
    HinhThucThanhToan(null);

    //Tỷ Lệ Hóa Đơn
    $('#tyLeHoaDon_btnOk').click(function () {
        TyLeHoaDon(null);
    });

    // Hình Thức Thanh Toán
    $('#hinhThucThanhToan_btnOk').click(function () {
        HinhThucThanhToan(null);
    });
    $('#hinhThucThanhToan_Luot, #hinhThucThanhToan_SoTien').on('change', function () {
        $('#hinhThucThanhToan_Luot, #hinhThucThanhToan_SoTien').not(this).prop('checked', false);
    });

    // Doanh Thu
    $('#doanhThuHoaDon_btnOk').click(function () {
        DoanhThuHoaDon(null);
    });

    // So Sánh Doanh Thu
    $('#SoSanhDoanhThuChuoiTrungTam_btnOk').click(function () {
        SoSanhDoanhThuChuoiTrungTam($('#soSanhDoanhThuChuoiTrungTam_Nam').val());
    });
});