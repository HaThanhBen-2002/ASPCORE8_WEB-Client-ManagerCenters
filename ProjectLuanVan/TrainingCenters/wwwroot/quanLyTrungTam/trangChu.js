let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));
let Crole = JSON.parse(Cookies.get('role'));
// ============= Thống kê số lượng =============

async function ThongKeSoLuong() {
    $('#thongKe_DichVu').text(await TKSL_DichVu());
    $('#thongKe_SanPham').text(await TKSL_SanPham(CtrungTam));
    $('#thongKe_HoaDon').text(await TKSL_HoaDon(CtrungTam));
    $('#thongKe_NhanVien').text(await TKSL_NhanVien(CtrungTam));
    $('#thongKe_NhaCungCap').text(await TKSL_NhaCungCap(CtrungTam));
    $('#thongKe_MonHoc').text(await TKSL_MonHoc());
    $('#thongKe_Lop').text(await TKSL_Lop(CtrungTam));
    $('#thongKe_KetQua').text(await TKSL_KetQua(CtrungTam));
    $('#thongKe_HocSinh').text(await TKSL_HocSinh(CtrungTam));
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
    chartSoSanhDoanhThuChuoiTrungTam = new ApexCharts($("#chartSoSanhDoanhThuChuoiTrungTam")[0], await GetOptions_DoanhThuTrungTam(nam, CtrungTam));
    chartSoSanhDoanhThuChuoiTrungTam.render();
}

$(document).ready(function () {
    $('#tyLeHoaDon_Nam').val(getCurrentYear());
    $('#soSanhDoanhThuChuoiTrungTam_Nam').val(getCurrentYear());
    $('#hinhThucThanhToan_Nam').val(getCurrentYear());
    $('#doanhThuHoaDon_Nam').val(getCurrentYear());

    ThongKeSoLuong();
    TyLeHoaDon(CtrungTam);
    SoSanhDoanhThuChuoiTrungTam($('#soSanhDoanhThuChuoiTrungTam_Nam').val());
    DoanhThuHoaDon(CtrungTam);
    HinhThucThanhToan(CtrungTam);

    //Tỷ Lệ Hóa Đơn
    $('#tyLeHoaDon_btnOk').click(function () {
        TyLeHoaDon(CtrungTam);
    });

    // Hình Thức Thanh Toán
    $('#hinhThucThanhToan_btnOk').click(function () {
        HinhThucThanhToan(CtrungTam);
    });
    $('#hinhThucThanhToan_Luot, #hinhThucThanhToan_SoTien').on('change', function () {
        $('#hinhThucThanhToan_Luot, #hinhThucThanhToan_SoTien').not(this).prop('checked', false);
    });

    // Doanh Thu
    $('#doanhThuHoaDon_btnOk').click(function () {
        DoanhThuHoaDon(CtrungTam);
    });

    // So Sánh Doanh Thu
    $('#SoSanhDoanhThuChuoiTrungTam_btnOk').click(function () {
        SoSanhDoanhThuChuoiTrungTam($('#soSanhDoanhThuChuoiTrungTam_Nam').val());
    });
});