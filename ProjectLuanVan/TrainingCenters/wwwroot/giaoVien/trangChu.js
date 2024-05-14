let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));

async function CbbTrungTam() {
    var trungTam = {
        MaTrungTam: null,
        TenTrungTam: null,
        DiaChi: null,
        Email: null,
        MaSoThue: null,
        SoDienThoai: null,
        DienTich: null,
        NganHang: null,
        SoTaiKhoan: null,
    };
    let trungTams = await TrungTam_SearchName(trungTam);
    $('#nhanVien_MaTrungTam').empty();
    $('#nhanVien_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#nhanVien_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });

    $('#nhanVien_MaTrungTam').val(CtrungTam);
}
$(document).ready(async function () {
    await CapNhatToken();
    CbbTrungTam();
    let data = await NhanVien_GetById(CnhanVien);
    $('#nhanVien_MaNhanVien').text(data.maNhanVien);
    $('#nhanVien_TenNhanVien').text(data.tenNhanVien);
    $('#nhanVien_Cccd').text(data.cccd);
    $('#nhanVien_NgaySinh').text(data.ngaySinh);
    $('#nhanVien_DiaChi').text(data.diaChi);
    $('#nhanVien_SoDienThoai').text(data.soDienThoai);
    $('#nhanVien_Email').text(data.email);
    $('#nhanVien_ThongTin').text(data.thongTin);
    $('#nhanVien_Luong').text(data.luong);
    $('#nhanVien_MaTaiKhoan').text(data.maTaiKhoan);
    $('#nhanVien_NganHang').text(data.nganHang);
    $('#nhanVien_SoTaiKhoan').text(data.soTaiKhoan);
    $('#nhanVien_GioiTinh').text(data.gioiTinh);
    $('#nhanVien_MaTrungTam').val(data.maTrungTam);
    $('#nhanVien_LoaiNhanVien').text(data.loaiNhanVien);
    $('#nhanVien_PhongBan').text(data.phongBan);
    $('#nhanVien_DanToc').text(data.danToc);
    $('#nhanVien_TonGiao').text(data.tonGiao);
    $('#imageShow').attr('src', data.hinhAnh);
});