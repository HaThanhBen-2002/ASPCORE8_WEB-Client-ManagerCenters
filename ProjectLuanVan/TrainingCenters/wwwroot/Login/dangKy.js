let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));
let Crole = JSON.parse(Cookies.get('role'));
function isValidPassword(password) {
    // Kiểm tra độ dài của mật khẩu
    if (password.length < 6) {
        return false;
    }

    // Kiểm tra xem mật khẩu có chứa ít nhất một số không
    if (!/\d/.test(password)) {
        return false;
    }

    // Kiểm tra xem mật khẩu có chứa ít nhất một chữ cái in hoa không
    if (!/[A-Z]/.test(password)) {
        return false;
    }

    // Kiểm tra xem mật khẩu có chứa ít nhất một chữ cái in thường không
    if (!/[a-z]/.test(password)) {
        return false;
    }

    // Kiểm tra xem mật khẩu có chứa ít nhất một ký tự đặc biệt không
    //if (!/[!@#$%^&*()_+{}[\]:;<>,.?\\~=-|]/.test(password)) {
    //    return false;
    //}

    // Nếu mật khẩu qua tất cả các điều kiện kiểm tra, trả về true
    return true;
}
// Hiển thị màn hình loading
function showLoading1() {
    $("#loadingScreen2").show();
    $("#loadingScreen1").show();
    $("#loadingScreen0").show();
    $("#showContent").hide();
}
function hideOption() {
    $('#dangKy_PhanQuyen option[value="Quản lý trung tâm"]').hide();
}
function showOption() {
    $('#dangKy_PhanQuyen option[value="Quản lý trung tâm"]').show();
}

async function DangKyTaiKhoan(registerUser) {
    try {
        const response = await $.ajax({
            type: "POST", url: "/Login/DangKyApi", data: { user: registerUser },
            headers: { "Authorization": `Bearer ${getToken()}` }
        });
        if (response.isSuccess === false && response.message === "Authorization") {
            await CapNhatToken();
            return await DangKyTaiKhoan();
        }
        return response.isSuccess;
    } catch (error) {
        console.error("Lỗi Try_Ca:", error);
        throw error;
    }
}

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
    $('#dangKy_TrungTam').empty();
    $.each(trungTams, function (index, item) {
        $('#dangKy_TrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
}

// Ẩn màn hình loading
function hideLoading1() {
    $("#loadingScreen2").hide();
    $("#loadingScreen1").hide();
    $("#loadingScreen0").hide();
    $("#showContent").show();
}

$(document).ready(async function () {
    hideLoading1();
    CbbTrungTam();
    if (CtrungTam == "Admin" && CnhanVien == "Admin" && Crole == "Admin") {
        showOption();

    }
    else if (CtrungTam != null && CnhanVien != null && Crole == "Quản lý trung tâm") {
        $('#dangKy_TrungTam').val(CtrungTam);
        hideOption();
        $('#dangKy_PhanQuyen').val("Giáo viên");
    }
    else {
        showLoading1();
        displayMessages(3, "Cảnh báo: bạn không có quyền truy cập thông tin này");
    }
    $('#btn_Login').click(async function () {
        showLoading1();
        let taiKhoan = $('#dangKy_Email').val();
        let matKhau = $('#dangKy_MatKhau').val();
        let matKhau1 = $('#dangKy_MatKhau1').val();
        let phanQuyen = $('#dangKy_PhanQuyen').val();
        console.log(phanQuyen);
        let trungTam = $('#dangKy_TrungTam').val();
        let taoMatKhauMacDinh = $('#dangKy_MatKhauMacDinh').prop('checked');
        // Kiểm tra Email (Tài khoản) hợp lệ
        if (isValidEmail(taiKhoan)) {
            if (taoMatKhauMacDinh == true) {
                matKhau = "BenBen@123456789";
                matKhau1 = "BenBen@123456789";
                // Kiểm tra phân quyền không để trống
                if (phanQuyen.length >= 1) {
                    // Kiểm tra trung tâm không được null
                    if (trungTam.length >= 1) {
                        // Kiểm tra Email xem đã được đăng ký chưa
                        let kiemTraEmailTonTai = await $.ajax({
                            type: "POST",
                            url: "/Login/GetByEmail",
                            data: { email: taiKhoan }
                        });
                        if (kiemTraEmailTonTai.isSuccess == false) {
                            // Kiểm tra xem email đăng ký đã được tạo thông tin người dùng chưa (nhân viên)
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
                            var thongTinNhanVien = await NhanVien_Search(nhanVien);
                            console.log("Thông tin nhân viên:", thongTinNhanVien);
                            if (thongTinNhanVien.length != 0) {
                                // Tạo tài khoản 
                                var registerUser = {
                                    Email: taiKhoan,
                                    Password: matKhau,
                                    MaTrungTam: trungTam,
                                    Roles: []
                                };
                                registerUser.Roles.push(phanQuyen);
                                let dangKyTaiKhoan = await DangKyTaiKhoan(registerUser);
                                if (dangKyTaiKhoan == true) {
                                    displayMessages(1, "Kiểm tra email để kích hoạt tài khoản");
                                }
                                else {
                                    displayMessages(3, "Đăng ký tài khoản thất bại")
                                }
                            }
                            else {
                                displayMessages(2, "Email chưa được cập nhật thông tin người dùng trong hệ thống, vui lòng tạo thông tin tại mục nhân viên");
                            }
                        }
                        else {
                            displayMessages(2, "Email đã được đăng ký");
                        }
                    }
                    else {
                        displayMessages(2, "Vui lòng chọn trung tâm");
                    }
                }
                else {
                    displayMessages(2, "Vui lòng chọn phân quyền");
                }
            }
            else {
                // Kiểm tra mật khẩu hợp lệ 
                if (isValidPassword(matKhau)) {
                    // Kiểm tra 2 mật khẩu phải trùng khớp
                    if (matKhau == matKhau1) {
                        // Kiểm tra phân quyền không để trống
                        if (phanQuyen.length >= 1) {
                            // Kiểm tra trung tâm không được null
                            if (trungTam.length >= 1) {
                                // Kiểm tra Email xem đã được đăng ký chưa
                                let kiemTraEmailTonTai = await $.ajax({
                                    type: "POST",
                                    url: "/Login/GetByEmail",
                                    data: { email: taiKhoan }
                                });
                                if (kiemTraEmailTonTai.isSuccess == false) {
                                    // Kiểm tra xem email đăng ký đã được tạo thông tin người dùng chưa (nhân viên)
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
                                    var thongTinNhanVien = await NhanVien_Search(nhanVien);
                                    console.log("Thông tin nhân viên:", thongTinNhanVien);
                                    if (thongTinNhanVien.length != 0) {
                                        // Tạo tài khoản 
                                        var registerUser = {
                                            Email: taiKhoan,
                                            Password: matKhau,
                                            MaTrungTam: trungTam,
                                            Roles: []
                                        };
                                        registerUser.Roles.push(phanQuyen);
                                        let dangKyTaiKhoan = await DangKyTaiKhoan(registerUser);
                                        if (dangKyTaiKhoan == true) {
                                            displayMessages(1, "Kiểm tra email để kích hoạt tài khoản");
                                        }
                                        else {
                                            displayMessages(3, "Đăng ký tài khoản thất bại")
                                        }
                                    }
                                    else {
                                        displayMessages(2, "Email chưa được cập nhật thông tin người dùng trong hệ thống, vui lòng tạo thông tin tại mục nhân viên");
                                    }
                                }
                                else {
                                    displayMessages(2, "Email đã được đăng ký");
                                }
                            }
                            else {
                                displayMessages(2, "Vui lòng chọn trung tâm");
                            }
                        }
                        else {
                            displayMessages(2, "Vui lòng chọn phân quyền");
                        }
                    }
                    else {
                        displayMessages(2, "Mật khẩu không trùng khớp");
                    }
                } else {
                    displayMessages(2, "Mật khẩu không hợp lệ");
                }
            }
            
        }
        else {
            displayMessages(2, "Tài khoản không hợp lệ");
        }
        hideLoading1();
    });
});