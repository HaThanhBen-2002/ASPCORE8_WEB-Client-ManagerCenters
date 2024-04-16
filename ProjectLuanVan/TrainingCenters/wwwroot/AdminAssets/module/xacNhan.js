function XacDinhRole(role) {
    switch (role) {
        case "Giáo viên":
            window.location.href = "/Admin/TrangChu/TrangChu";  // Điều hướng đến trang chủ của Admin
            break;
        case "Giáo viên":
            window.location.href = "/User/Home";   // Điều hướng đến trang chủ của User
            break;
        // Thêm các điều hướng khác tùy theo role
        default:
            window.location.href = "/Home/Index";  // Điều hướng về trang chủ mặc định
            break;
    }
}

async function CapNhatToken() {
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
    }
    let response = await $.ajax({
        type: "POST",
        url: "/Login/CapNhatToken",
        data: { item: loginResponse }
    });
    // Loại bỏ các trường "$id" từ dữ liệu trả về
    let cleanedResponse = removeIdFields(response);

    if (cleanedResponse.isSuccess) {
        displayMessages(1, cleanedResponse.message);
        // Đăng nhập thành công
        Cookies.set('accessToken', JSON.stringify(cleanedResponse.response.accessToken.token));
        Cookies.set('refreshToken', JSON.stringify(cleanedResponse.response.refreshToken.token));
        Cookies.set('accessToken_expiryTokenDate', JSON.stringify(cleanedResponse.response.accessToken.expiryTokenDate));
        Cookies.set('refreshToken_expiryTokenDate', JSON.stringify(cleanedResponse.response.refreshToken.expiryTokenDate));
        //XacDinhRole(cleanedResponse.response.role);

    }
    else {
        // Đăng nhập thất bại
        displayMessages(2, "Cập nhật Token thất bại");
    }
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