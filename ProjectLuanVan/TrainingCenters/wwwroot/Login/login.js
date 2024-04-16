
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

    $('#showBtnOTP').hide();
    $('#showOTP').hide();

    $('#btn_Login').click(async function () {
        showLoading1();
        let taiKhoan = $('#login_TaiKhoan').val();
        let matKhau = $('#login_MatKhau').val();
        let ghiNho = $('#login_GhiNhoTaiKhoan').val();

        if (isValidEmail(taiKhoan)) {
            let loginModel = {
                Username: taiKhoan,
                Password: matKhau
            };

            try {
                let response = await $.ajax({
                    type: "POST",
                    url: "/Login/DangNhapApi",
                    data: { item: loginModel }
                });

                if (response.isSuccess) {
                    $('#showBtnOTP').show();
                    $('#showOTP').show();

                    $('#showBtn').hide();
                    $('#showTaiKhoan').hide();
                    $('#showMatKhau').hide();
                    $('#showGhiNho').hide();
                    displayMessages(1, response.message);
                    // Đăng nhập thành công
                    // Kiểm tra OTP
                }
                else {
                    // Đăng nhập thất bại
                    displayMessages(2, response.message);
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


    $('#btn_LoginOTP').click(async function () {
        showLoading1();
        let taiKhoan = $('#login_TaiKhoan').val();
        let ghiNho = $('#login_GhiNhoTaiKhoan').val();
        let otp = $('#login_OTP').val();

        if (isValidEmail(taiKhoan)) {
            try {
                let response = await $.ajax({
                    type: "POST",
                    url: "/Login/DangNhapApiOTP",
                    data: { code: otp, email: taiKhoan }
                });

                if (response.isSuccess) {
                    alert("Đăng nhập thành công");
                    // Đăng nhập thành công
                    // Kiểm tra OTP
                }
                else {
                    // Đăng nhập thất bại
                    displayMessages(2, "OTP không đúng");
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

});