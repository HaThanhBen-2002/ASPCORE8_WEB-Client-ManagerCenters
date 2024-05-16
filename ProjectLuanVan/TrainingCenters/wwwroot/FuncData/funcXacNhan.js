function XacDinhRole(role) {
    switch (role) {
        case "Admin":
            window.location.href = "/Admin/TrangChu/TrangChu";  
            break;
        case "Giáo viên":
            window.location.href = "/GiaoVien/TrangChu/TrangChu";
            break;
        case "Kho":
            window.location.href = "/ThuKho/TrangChu/TrangChu"; 
            break;
        case "Thu ngân":
            window.location.href = "/ThuNgan/TrangChu/TrangChu";
            break;
        case "Quản lý trung tâm":
            window.location.href = "/QuanLyTrungTam/TrangChu/TrangChu";
            break;
        // Thêm các điều hướng khác tùy theo role
        default:
            window.location.href = "/Login";  // Điều hướng về trang chủ mặc định
            break;
    }
}

function getToken() {
    let tk = Cookies.get('accessToken');
    if (tk == undefined) {
        XacDinhRole();
    }
    else {
        return JSON.parse(tk);
    }
}

function CapNhatToken() {
    return new Promise((resolve, reject) => {
        try {

            let accessToken = JSON.parse(Cookies.get('accessToken'));
            let refreshToken = JSON.parse(Cookies.get('refreshToken'));
            let accessToken_expiryTokenDate = JSON.parse(Cookies.get('accessToken_expiryTokenDate'));
            let refreshToken_expiryTokenDate = JSON.parse(Cookies.get('refreshToken_expiryTokenDate'));
            let loginResponse = {
                AccessToken: {
                    Token: accessToken,
                    ExpiryTokenDate: accessToken_expiryTokenDate,
                },
                RefreshToken: {
                    Token: refreshToken,
                    ExpiryTokenDate: refreshToken_expiryTokenDate,
                },
                Role: null,
            };

            $.ajax({
                type: "POST",
                url: "/Login/CapNhatToken",
                data: { item: loginResponse },
                success: function (data) {
                    let cleanedResponse = removeIdFields(data);
                    if (data.isSuccess == true) {
                        // Đăng nhập thành công
                        Cookies.set('accessToken', JSON.stringify(cleanedResponse.response.accessToken.token));
                        Cookies.set('refreshToken', JSON.stringify(cleanedResponse.response.refreshToken.token));
                        Cookies.set('accessToken_expiryTokenDate', JSON.stringify(cleanedResponse.response.accessToken.expiryTokenDate));
                        Cookies.set('refreshToken_expiryTokenDate', JSON.stringify(cleanedResponse.response.refreshToken.expiryTokenDate));
                        resolve(cleanedResponse); // Trả về dữ liệu khi cập nhật thành công
                    }
                    else {
                        reject("Cập nhật token không thành công");
                    }
                },
                error: function (error) {
                    reject(error);
                }
            });
        }
        catch (error) {
            console.log("Bạn chưa đăng nhập lần nào");
            reject(error);
        }
    });
}

function removeIdFields(data) {
    let cleanedData = JSON.parse(JSON.stringify(data), (key, value) => {
        if (key === '$id') {
            return undefined;
        }
        return value;
    });

    return cleanedData;
}

