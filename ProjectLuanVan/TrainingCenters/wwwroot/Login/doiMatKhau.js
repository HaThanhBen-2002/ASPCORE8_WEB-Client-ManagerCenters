
function kiemTraMatKhau(matkhau1, matkhau2) {
    // Kiểm tra điều kiện 1: Không được null
    if (matkhau1 === null || matkhau2 === null) {
        return false;
    }

    // Kiểm tra điều kiện 2: Hai mật khẩu phải giống nhau
    if (matkhau1 !== matkhau2) {
        return false;
    }

    // Kiểm tra điều kiện 3: Mật khẩu phải có ít nhất 8 ký tự
    if (matkhau1.length < 8) {
        return false;
    }

    // Kiểm tra điều kiện 4: Mật khẩu phải chứa ít nhất một ký tự IN HOA
    if (!/[A-Z]/.test(matkhau1)) {
        return false;
    }

    // Kiểm tra điều kiện 5: Mật khẩu phải chứa ít nhất một ký tự in thường
    if (!/[a-z]/.test(matkhau1)) {
        return false;
    }

    // Kiểm tra điều kiện 6: Mật khẩu phải chứa ít nhất một số
    if (!/\d/.test(matkhau1)) {
        return false;
    }

    // Kiểm tra điều kiện 7: Mật khẩu phải chứa ít nhất một ký tự đặc biệt
    if (!/[^a-zA-Z0-9]/.test(matkhau1)) {
        return false;
    }

    // Nếu tất cả các điều kiện đều được thỏa mãn, trả về true
    return true;
}

$(document).ready(function () {

    $('#btn_doiMatKhau').click(function () {
        let token = $('#token').val();
        let email = $('#email').val();
        let matkhau = $('#doiMatKhau_MatKhau').val();
        let matkhau1 = $('#doiMatKhau_MatKhau1').val();

        if (kiemTraMatKhau(matkhau, matkhau1)){
            let resetPassword = {
                Password: matkhau,
                ConfirmPassword: matkhau1,
                Email: email,
                Token: token
            };
            $.ajax({
                type: "POST",
                url: "/Login/DoiMatKhauApi",
                async: false,
                data: { item: resetPassword },
                success: function (data) {
                    if (data) {
                        alert("Đổi mật khẩu thành công");
                    }
                    else {
                        alert("Đổi mật khẩu thất bại");
                    }
                }
            });
        }
        else {
            alert("Mật khẩu không trùng khớp");
        }
    });
});