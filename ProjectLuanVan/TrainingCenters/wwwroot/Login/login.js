
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
function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}
let token = "";
let token1 = "";


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
                    //XacDinhRole(cleanedResponse.response.role);
                   
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
        try {
            showLoading1();

            let response = await $.ajax({
                type: "POST",
                url: "Admin/DichVu/GetAll",
                headers: {
                    "Authorization": `Bearer ${JSON.parse(Cookies.get('accessToken')) }`
                },
            });

            let response1 = await $.ajax({
                type: "POST",
                url: "Admin/DichVu/GetById",
                data: {id:1},
                headers: {
                    "Authorization": `Bearer ${JSON.parse(Cookies.get('accessToken'))}`
                },
            });
            hideLoading1();
        } catch (error) {
            // Xử lý lỗi AJAX
            console.error("Lỗi AJAX:", error);
            hideLoading1(); // Ẩn loading sau khi xử lý lỗi
        }
    });

});