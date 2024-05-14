
// Hiển thị màn hình loading
function showLoading1() {
    $("#loadingScreen2").show();
    $("#loadingScreen1").show();
    $("#loadingScreen0").show();
    $("#showContent").hide();
}

// Ẩn màn hình loading
function hideLoading1() {
    $("#loadingScreen2").hide();
    $("#loadingScreen1").hide();
    $("#loadingScreen0").hide();
    $("#showContent").show();
}

$(document).ready(function () {
    hideLoading1();

    $('#btn_Login').click(async function () {
        showLoading1();
        let taiKhoan = $('#login_TaiKhoan').val();
        let matKhau = $('#login_MatKhau').val();
        let ghiNho = $('#login_GhiNhoTaiKhoan').prop('checked');

        if (isValidEmail(taiKhoan)) {
            let loginModel = {
                Username: taiKhoan,
                Password: matKhau
            };

            try {
                let response = await $.ajax({
                    type: "POST",
                    url: "/Login/DangNhapApi",
                    data: { item: loginModel}
                });

                // Loại bỏ các trường "$id" từ dữ liệu trả về
                let cleanedResponse = removeIdFields(response);

                if (cleanedResponse.isSuccess) {
                    displayMessages(1, cleanedResponse.message);
                    // Đăng nhập thành công
                    // Sử dụng thư viện js-cookie
                    Cookies.set('accessToken', JSON.stringify(cleanedResponse.response.accessToken.token));
                    Cookies.set('refreshToken', JSON.stringify(cleanedResponse.response.refreshToken.token));
                    Cookies.set('accessToken_expiryTokenDate', JSON.stringify(cleanedResponse.response.accessToken.expiryTokenDate));
                    Cookies.set('refreshToken_expiryTokenDate', JSON.stringify(cleanedResponse.response.refreshToken.expiryTokenDate));
                    let role = cleanedResponse.response.role;
                    Cookies.set('role', JSON.stringify(role));

                    if (role != "Admin") {
                        let response1 = await $.ajax({
                            type: "POST",
                            url: "/Login/GetByEmail",
                            data: { email: taiKhoan }
                        });

                        var nhanVien = {
                            MaNhanVien: null,
                            TenNhanVien: null,
                            Cccd: null,
                            NgaySinh: null,
                            GioiTinh: null,
                            DiaChi: null,
                            SoDienThoai: null,
                            Email: taiKhoan,
                            ThongTin: null,
                            HinhAnh: null,
                            MaTrungTam: null,
                            MaTaiKhoan: null,
                            LoaiNhanVien: null,
                            PhongBan: null,
                            Luong: null,
                            NganHang: null,
                            SoTaiKhoan: null,
                            DanToc: null,
                            TonGiao: null
                        };
                        let thongTinNhanVien = await NhanVien_Search(nhanVien);

                        Cookies.set('trungTam', JSON.stringify(response1.response.maTrungTam));
                        Cookies.set('nhanVien', JSON.stringify(thongTinNhanVien[0].maNhanVien));
                        console.log(thongTinNhanVien[0].maNhanVien);
                    }
                    else {
                        Cookies.set('trungTam', JSON.stringify("Admin"));
                        Cookies.set('nhanVien', JSON.stringify("Admin"));
                    }
                   XacDinhRole(cleanedResponse.response.role);
                   
                }
                else {
                    // Đăng nhập thất bại
                    displayMessages(2, cleanedResponse.message);
                }



            } catch (error) {
                // Xử lý lỗi AJAX
                console.error("Lỗi AJAX:", error);
                displayMessages(2, "Đã có lỗi xảy ra");
            }
        }
        else {
            displayMessages(2, "Email không hợp lệ");
        }

        hideLoading1();
    });

    $('#btn_Token').click(async function () {
        showLoading1();
        CapNhatToken();
        hideLoading1();
    });

    $('#btn_XacThuc').click(async function () {
        showLoading1();
        let data = await DichVu_GetAll();
        console.log(data); // Dữ liệu đã được giải quyết từ Promise
        hideLoading1();
    });

    $('#btn_XacThuc1').click(async function () {
        showLoading1();
        let response = await $.ajax({
            type: "POST",
            url: "/Login/GetByEmail",
            data: { email: "mavuongkiki2002@gmail.com" }
        });
        hideLoading1();
    });

});