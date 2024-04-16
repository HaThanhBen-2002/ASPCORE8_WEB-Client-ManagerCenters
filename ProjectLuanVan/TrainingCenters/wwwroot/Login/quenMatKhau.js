
$(document).ready(function () {
    
    $('#btn_quenMatKhau').click(function () {
        let email = $('#quenMatKhau_TaiKhoan').val();
        if (isValidEmail(email)) {
            $.ajax({
                type: "POST",
                url: "/Login/QuenMatKhauApi",
                async: false,
                data: { email: email },
                success: function (data) {
                    if (data) {
                        alert("Kiểm tra email của bạn");
                    }
                    else {
                        alert("Không thể gửi thông tin qua email");
                    }
                }
            });
        }
        else {
            alert("Email không hợp lệ");
        }
    });
});