
var hocSinh = {
    MaHocSinh: null,
    TenHocSinh: null,
    NgaySinh: null,
    GioiTinh: null,
    MaLop: null,
    MaTrungTam: null,
    ThongTin: null,
    HinhAnh: null,
    DiaChi: null,
    ChieuCao: null,
    CanNang: null,
    TinhTrangRang: null,
    TinhTrangMat: null,
    Bmi: null,
    TinhTrangTamLy: null,
    ChucNangCoThe: null,
    DanhGiaSucKhoe: null,
    Cccdcha: null,
    Cccdme: null,
    TenCha: null,
    TenMe: null,
    NgaySinhCha: null,
    NgaySinhMe: null,
    SoDienThoaiCha: null,
    SoDienThoaiMe: null,
    EmailCha: null,
    EmailMe: null,
    NgheNghiepCha: null,
    NgheNghiepMe: null
};
var emails = [];
var maHocSinhs = [];
//============================== Send Email ===============================
function UpdateTableEmail() {

    $('#quantityEmail').text("Địa Chỉ Email (" + emails.length + ")");
    // Xóa các hàng hiện tại trong bảng trừ tiêu đề
    $('#myTableEmail tbody').empty();
    if (emails != null) {
        // Lặp qua từng đối tượng trong mảng selectedItems và thêm vào bảng
        emails.forEach(function (item, index) {
            var row = '<tr>';
            row += '<td class="px-1">' + item + '</td>';
            row += '</tr>';
            $('#myTableEmail tbody').append(row);
        });
    }

    // Thêm Id cho mỗi button trong hàng, chứa chỉ mục của hàng
    $('#myTableEmail tbody tr').each(function (index) {
        var rowIndex = index; // Lấy chỉ mục của hàng
        $(this).append('<td class="px-1"><button onclick="DeleteItem(' + rowIndex + ')" class="btn btn-xs btn-danger">Xóa</button></td>');
    });

}
function DeleteItem(index) {
    // Xóa phần tử tương ứng trong danh sách selectedItems
    emails.splice(index, 1);
    // Cập nhật lại bảng
    UpdateTableEmail();
}
function AddItem(item) {
    if (isValidEmail(item)) {
        // Xóa phần tử tương ứng trong danh sách selectedItems
        emails.push(item);
        // Cập nhật lại bảng
        UpdateTableEmail();
    }
    else {
        displayMessages(2, "Email không hợp lệ");
    }
}
//============================== END Send Email ===============================
function exportToExcel() {
    var listHocSinh = [];
    var listTrungTam = [];
    var listLop = [];

    $.ajax({
        type: "POST",
        url: "/Admin/HocSinh/Search",
        async: false,
        data: { item: hocSinh },
        success: function (data) {
            listHocSinh = data.$values.map(function (item) {
                delete item.$id;
                return {
                    'Mã Học Sinh': item.maHocSinh,
                    'Tên Học Sinh': item.tenHocSinh,
                    'Ngày Sinh': item.ngaySinh,
                    'Giới Tính': item.gioiTinh,
                    'Mã Lớp': item.maLop,
                    'Mã Trung Tâm': item.maTrungTam,
                    'Thông Tin': item.thongTin,
                    'Địa Chỉ': item.diaChi,
                    'Chiều Cao': item.chieuCao,
                    'Cân Nặng': item.canNang,
                    'Tình Trạng Răng': item.tinhTrangRang,
                    'Tình Trạng Mắt': item.tinhTrangMat,
                    'BMI': item.bmi,
                    'Tình Trạng Tâm Lý': item.tinhTrangTamLy,
                    'Chức Năng Cơ Thể': item.chucNangCoThe,
                    'Đánh Giá Sức Khỏe': item.danhGiaSucKhoe,
                    'CCCD Cha': item.cccdcha,
                    'CCCD Mẹ': item.cccdme,
                    'Tên Cha': item.tenCha,
                    'Tên Mẹ': item.tenMe,
                    'Ngày Sinh Cha': item.ngaySinhCha,
                    'Ngày Sinh Mẹ': item.ngaySinhMe,
                    'Số Điện Thoại Cha': item.soDienThoaiCha,
                    'Số Điện Thoại Mẹ': item.soDienThoaiMe,
                    'Email Cha': item.emailCha,
                    'Email Mẹ': item.emailMe,
                    'Nghề Nghiệp Cha': item.ngheNghiepCha,
                    'Nghề Nghiệp Mẹ': item.ngheNghiepMe
                };
            });
        }
    });

    $.ajax({
        type: "POST",
        url: "/Admin/TrungTam/SearchName",
        async: false,
        success: function (data) {
            listTrungTam = data.$values.map(function (item) {
                delete item.$id;
                return {
                    'Mã Trung Tâm': item.maTrungTam,
                    'Tên Trung Tâm': item.tenTrungTam
                };
            });
        }
    });

    $.ajax({
        type: "POST",
        url: "/Admin/Lop/SearchName",
        async: false,
        success: function (data) {
            listLop = data.$values.map(function (item) {
                delete item.$id;
                return {
                    'Mã Lớp': item.maLop,
                    'Tên Lớp': item.tenLop
                };
            });
        }
    });

    var workbook = XLSX.utils.book_new();

    var danhSachHocSinh = XLSX.utils.json_to_sheet(listHocSinh);
    XLSX.utils.book_append_sheet(workbook, danhSachHocSinh, "Danh sách học sinh");

    var danhSachTrungTam = XLSX.utils.json_to_sheet(listTrungTam);
    XLSX.utils.book_append_sheet(workbook, danhSachTrungTam, "Thông tin trung tâm");

    var danhSachLop = XLSX.utils.json_to_sheet(listLop);
    XLSX.utils.book_append_sheet(workbook, danhSachLop, "Thông tin lớp");

    XLSX.writeFile(workbook, "DanhSachHocSinh.xlsx");
}






function isValidHocSinh(item) {
    if (CheckIsNull(item.TenHocSinh)) {
        displayMessages(2, "Vui lòng nhập (Tên học sinh)");
        return false;
    } else if (CheckIsNull(item.NgaySinh)) {
        displayMessages(2, "Vui lòng chọn (Ngày sinh)");
        return false;
    } else if (CheckIsNull(item.GioiTinh)) {
        displayMessages(2, "Vui lòng chọn (Giới tính)");
        return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Mã trung tâm)");
        return false;
    } else if (CheckIsNull(item.MaLop)) {
        item.MaLop = null;
        return false;
    }
    return true;
}

function GetHocSinhData() {
    return {
        MaHocSinh: $('#hocSinh_MaHocSinh').val(),
        TenHocSinh: $('#hocSinh_TenHocSinh').val(),
        NgaySinh: $('#hocSinh_NgaySinh').val(),
        GioiTinh: $('#hocSinh_GioiTinh').val(),
        MaLop: $('#hocSinh_MaLop').val(),
        MaTrungTam: $('#hocSinh_MaTrungTam').val(),
        ThongTin: $('#hocSinh_ThongTin').val(),
        HinhAnh: $('#imageShow').attr('src'),
        DiaChi: $('#hocSinh_DiaChi').val(),
        ChieuCao: $('#hocSinh_ChieuCao').val(),
        CanNang: $('#hocSinh_CanNang').val(),
        TinhTrangRang: $('#hocSinh_TinhTrangRang').val(),
        TinhTrangMat: $('#hocSinh_TinhTrangMat').val(),
        Bmi: $('#hocSinh_Bmi').val(),
        TinhTrangTamLy: $('#hocSinh_TinhTrangTamLy').val(),
        ChucNangCoThe: $('#hocSinh_ChucNangCoThe').val(),
        DanhGiaSucKhoe: $('#hocSinh_DanhGiaSucKhoe').val(),
        Cccdcha: $('#hocSinh_Cccdcha').val(),
        Cccdme: $('#hocSinh_Cccdme').val(),
        TenCha: $('#hocSinh_TenCha').val(),
        TenMe: $('#hocSinh_TenMe').val(),
        NgaySinhCha: $('#hocSinh_NgaySinhCha').val(),
        NgaySinhMe: $('#hocSinh_NgaySinhMe').val(),
        SoDienThoaiCha: $('#hocSinh_SoDienThoaiCha').val(),
        SoDienThoaiMe: $('#hocSinh_SoDienThoaiMe').val(),
        EmailCha: $('#hocSinh_EmailCha').val(),
        EmailMe: $('#hocSinh_EmailMe').val(),
        NgheNghiepCha: $('#hocSinh_NgheNghiepCha').val(),
        NgheNghiepMe: $('#hocSinh_NgheNghiepMe').val(),
    };
}


function CreateHocSinh() {
    let item = GetHocSinhData();
    // Kiểm tra tính hợp lệ
    if (isValidHocSinh(item)) {
        let status = false;
        item.MaHocSinh = null;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/HocSinh/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateHocSinh() {
    let item = GetHocSinhData();
    // Kiểm tra tính hợp lệ
    if (isValidHocSinh(item) && !CheckIsNull(item.MaHocSinh)) {
        let status = false;
        // Gửi dữ liệu thông qua AJAX để cập nhật vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/HocSinh/Update",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}


function CbbTrungTam() {
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
    $.ajax({
        type: "POST",
        url: "/Admin/TrungTam/SearchName",
        data: { item: trungTam },
        success: function (data) {
            $('#hocSinh_MaTrungTam').empty();
            $('#hocSinh_MaTrungTam').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#hocSinh_MaTrungTam').append($('<option>', {
                    value: item.maTrungTam,
                    text: item.tenTrungTam
                }));
            });
        }
    });

}


function CbbLopByMaTrungTam() {
    let trungTam = $('#hocSinh_MaTrungTam').val();
    if (!CheckIsNull(trungTam)) {
        var lop = {
            MaLop: null,
            TenLop: null,
            MaNhanVien: null,
            MaTrungTam: trungTam,
            NamHoc: null,
            HocPhi: null,
            LichHoc: null,
            ThongTin: null,
            NgayBatDau: null,
            NgayKetThuc: null
        };

        $.ajax({
            type: "POST",
            url: "/Admin/Lop/SearchName",
            async: false,
            data: { item: lop },
            success: function (data) {
                $('#hocSinh_MaLop').empty();
                $('#hocSinh_MaLop').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
                $.each(data.$values, function (index, item) {
                    $('#hocSinh_MaLop').append($('<option>', {
                        value: item.maLop,
                        text: item.tenLop
                    }));
                });
            }
        });
    }
    else {
        $('#hocSinh_MaLop').empty();
        $('#hocSinh_MaLop').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
    }
}

//===== Func xữ lí ảnh
function openFileInput() {
    $("#fileInput").click();
}
// Xử lý file ảnh mà người dùng chọn
function handleFileSelect(input) {
    var file = input.files[0];
    if (file) {
        // Kiểm tra kích thước của file
        if (file.size > 500 * 1024) { // Kích thước lớn hơn 500KB
            alert("Vui lòng chọn một file ảnh có kích thước nhỏ hơn 500KB.");
            return;
        }

        var reader = new FileReader();
        reader.onload = function (e) {
            image = e.target.result;
            updateCarousel();
        };
        reader.readAsDataURL(file);
    }
}
// Hàm cập nhật carousel-inner
function updateCarousel() {
    var carouselInner = $("#carouselExample .carousel-inner");
    carouselInner.empty(); // Xóa tất cả các ảnh hiện tại
    var carouselItem =
        '<div class="carousel-item active">' +
        '<img id="imageShow" class="d-block img-fluid" style="border-radius: 0.5rem" alt="Không tìm thấy ảnh" src="' + image + '">' +
        '</div>';
    carouselInner.append(carouselItem);
}
// Hàm xóa ảnh
function deleteImage() {
    image = ""; // Xóa ảnh cuối cùng trong mảng
    updateCarousel();
}

$(document).ready(function () {
    //=============================== IMAGE ===================================
    // đối tượng ảnh
    var image = "";
    $("#addImage").click(function () {
        openFileInput();
    });
    // ============================================== TABLE ===============================================

    // Loading Data Table
    $('#myTable').DataTable({
        serverSide: true,
        scrollY: 400,
        searching: false,
        lengthChange: true,
        ordering: false,
        ajax: {
            type: "POST",
            url: "/Admin/HocSinh/LoadingDataTableView",
            dataType: "json",
            data: { item: hocSinh },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maHocSinh',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                }
            },
            { data: "tenHocSinh" },
            { data: "ngaySinh" },
            { data: "gioiTinh" },
            { data: "tenLop" }
        ],
        layout: {
            topEnd: {
                buttons: ['copy', 'csv', 'excel', 'pdf', 'print']
            }
        },
        initComplete: function () {
            // Thêm CSS vào các nút
            var buttons = $('.dt-buttons').find('button');
            buttons.css({
                'height': '25px',
                'line-height': '25px',
                'padding': '0 15px'
            });
        }

    });

    // Table Object
    var table = $('#myTable').DataTable();

    // Event pageChange"myTable"
    table.on('page.dt', function () {
        // Thực hiện các hành động khi trang của DataTable thay đổi
        $('#checkAll').prop('checked', false);
    });

    // Event selectItem "myTable"
    $('#myTable tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected')
        } else {
            table.$('tr.selected').removeClass('selected')
            $(this).addClass('selected')
            // xử lý ở đây
            const rowId = table.row(this).data().maHocSinh;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/HocSinh/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {


                    $('#hocSinh_MaHocSinh').val(data.maHocSinh);
                    $('#hocSinh_TenHocSinh').val(data.tenHocSinh);
                    $('#hocSinh_NgaySinh').val(data.ngaySinh);
                    $('#hocSinh_GioiTinh').val(data.gioiTinh);
                    $('#hocSinh_MaTrungTam').val(data.maTrungTam);
                    CbbLopByMaTrungTam();
                    $('#hocSinh_MaLop').val(data.maLop);
                    $('#hocSinh_ThongTin').val(data.thongTin);
                    $('#hocSinh_DiaChi').val(data.diaChi);
                    $('#hocSinh_ChieuCao').val(data.chieuCao);
                    $('#hocSinh_CanNang').val(data.canNang);
                    $('#hocSinh_TinhTrangRang').val(data.tinhTrangRang);
                    $('#hocSinh_TinhTrangMat').val(data.tinhTrangMat);
                    $('#hocSinh_Bmi').val(data.bmi);
                    $('#hocSinh_TinhTrangTamLy').val(data.tinhTrangTamLy);
                    $('#hocSinh_ChucNangCoThe').val(data.chucNangCoThe);
                    $('#hocSinh_DanhGiaSucKhoe').val(data.danhGiaSucKhoe);
                    $('#hocSinh_Cccdcha').val(data.cccdCha);
                    $('#hocSinh_Cccdme').val(data.cccdMe);
                    $('#hocSinh_TenCha').val(data.tenCha);
                    $('#hocSinh_TenMe').val(data.tenMe);
                    $('#hocSinh_NgaySinhCha').val(data.ngaySinhCha);
                    $('#hocSinh_NgaySinhMe').val(data.ngaySinhMe);
                    $('#hocSinh_SoDienThoaiCha').val(data.soDienThoaiCha);
                    $('#hocSinh_SoDienThoaiMe').val(data.soDienThoaiMe);
                    $('#hocSinh_EmailCha').val(data.emailCha);
                    $('#hocSinh_EmailMe').val(data.emailMe);
                    $('#hocSinh_NgheNghiepCha').val(data.ngheNghiepCha);
                    $('#hocSinh_NgheNghiepMe').val(data.ngheNghiepMe);
                    $('#imageShow').attr('src', data.hinhAnh);
                }
            });
        }
    });

    // Event checkbox "Check All"
    $('#checkAll').change(function () {
        var isChecked = $(this).prop('checked');
        if (isChecked) {
            $('input[type="checkbox"]').each(function () {
                if ($(this).hasClass('form-check-input') != true) {
                    // Thực hiện hành động cho checkbox có class "form-check-input" ở đây
                    $(this).prop('checked', true);
                }
            });
        } else {
            $('input[type="checkbox"]').each(function () {
                if ($(this).hasClass('form-check-input') != true) {
                    // Thực hiện hành động cho checkbox có class "form-check-input" ở đây
                    $(this).prop('checked', false);
                }
            });
        }
    });
    //=============================== CBB ===================================
    CbbTrungTam();
    $('#hocSinh_MaTrungTam').change(function () {
        CbbLopByMaTrungTam();
    });
    // ============================================== BUTTON ===============================================
    $('#btnCreateHocSinh').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateHocSinh() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/HocSinh/GetByIdTable",
                async: false,
                data: { id: $('#hocSinh_MaHocSinh').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maHocSinh = '<input data-checkbox-id="' + itemView.maHocSinh + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateHocSinh').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateHocSinh() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/HocSinh/GetByIdTable",
                async: false,
                data: { id: $('#hocSinh_MaHocSinh').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maHocSinh = '<input data-checkbox-id="' + itemView.maHocSinh + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteHocSinh').click(function () {
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });
        if (selectedIds.length >= 1 && selectedIds != null) {
            $("#DeleteModal").modal("show");
        }
    });

    $('#btnDelete').click(function () {
        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });

        if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
            let statusDelete = false;
            // Gửi danh sách ID được chọn đến action bằng Ajax
            $.ajax({
                type: "POST",
                url: "/Admin/HocSinh/Delete",
                async: false,
                data: { ids: selectedIds, nguoiXoa: "Nhân viên TEST" }, // Truyền danh sách ID đến action
                success: function (data) {
                    if (data.isSuccess == true) {
                        displayMessages(1, "Xóa thành công");
                        $("#DeleteModal").modal("hide");
                        statusDelete = true;
                    }
                    else {
                        statusDelete = false;
                        displayMessages(2, "Xóa thất bại");
                    }
                }
            });
            if (statusDelete) {
                // Lặp qua từng hàng
                table.rows().every(function () {
                    var rowData = this.data();
                    // Kiểm tra xem rowData có tồn tại không trước khi truy cập thuộc tính
                    if (rowData && rowData.maHocSinh) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maHocSinh + '"]');
                        if (checkbox.prop('checked')) {
                            // Xóa hàng nếu checkbox được kiểm tra
                            this.remove();
                        }
                    }
                });
                // Vẽ lại DataTables sau khi xóa các hàng
                table.draw();
            }
        }
    });

    $('#btnResetHocSinh').click(function () {

        $('#hocSinh_MaHocSinh').val(null);
        $('#hocSinh_TenHocSinh').val(null);
        $('#hocSinh_NgaySinh').val(null);
        $('#hocSinh_GioiTinh').val(null);
        $('#hocSinh_MaTrungTam').val(null);
        CbbLopByMaTrungTam();
        $('#hocSinh_MaLop').val(null);
        $('#hocSinh_ThongTin').val(null);
        $('#hocSinh_DiaChi').val(null);
        $('#hocSinh_ChieuCao').val(null);
        $('#hocSinh_CanNang').val(null);
        $('#hocSinh_TinhTrangRang').val(null);
        $('#hocSinh_TinhTrangMat').val(null);
        $('#hocSinh_Bmi').val(null);
        $('#hocSinh_TinhTrangTamLy').val(null);
        $('#hocSinh_ChucNangCoThe').val(null);
        $('#hocSinh_DanhGiaSucKhoe').val(null);
        $('#hocSinh_Cccdcha').val(null);
        $('#hocSinh_Cccdme').val(null);
        $('#hocSinh_TenCha').val(null);
        $('#hocSinh_TenMe').val(null);
        $('#hocSinh_NgaySinhCha').val(null);
        $('#hocSinh_NgaySinhMe').val(null);
        $('#hocSinh_SoDienThoaiCha').val(null);
        $('#hocSinh_SoDienThoaiMe').val(null);
        $('#hocSinh_EmailCha').val(null);
        $('#hocSinh_EmailMe').val(null);
        $('#hocSinh_NgheNghiepCha').val(null);
        $('#hocSinh_NgheNghiepMe').val(null);
        $('#imageShow').attr('src', null);
    });

    $('#btnSearchHocSinh').click(function () {

        hocSinh = GetHocSinhData();
        hocSinh.HinhAnh = null;
        // Bạn có thể thêm các xử lý bổ sung ở đây nếu cần
       
        if (hocSinh.MaTrungTam == 0) {
            hocSinh.MaTrungTam = null;
        }
        if (hocSinh.MaLop == 0) {
            hocSinh.MaLop = null;
        }

        table.settings()[0].ajax.data = { item: hocSinh };
        table.ajax.reload();
       
    });


    // Khác==============================

    $('#giaiPhongDuLieu').click(function () {
        hocSinh.MaHocSinh = 0;
        table.settings()[0].ajax.data = { item: hocSinh };
        table.ajax.reload();
    });

    $('#showThongTin').click(function () {
        $("#viewShowThongTin").toggle();
    });
    $('#btnThemEmail').click(function () {
        AddItem($('#email_ThemDiaChiEmail').val());
    });
    $('#btnSendEmail').click(function () {
        showLoading();
        let contentEmail = $("#summernote").summernote('code');
        let subject = $("#email_TieuDe").val();
        if (emails == null) {
            displayMessages(2, "Không tìm thấy email để gửi");
        }
        else if (CheckIsNull(subject)) {
            displayMessages(2, "Vui lòng nhập tiêu đề Email");
        }
        else if (CheckIsNull(contentEmail)) {
            displayMessages(2, "Vui lòng soạn nội dung Email");
        }
        else {
            let message = {
                To: emails,
                Subject: subject,
                Content: contentEmail,
            };
            // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
            $.ajax({
                type: "POST",
                url: "/Admin/SendEmail/SendEmailText",
                data: { message: message },
                success: function (data) {
                    if (data.isSuccess) {
                        displayMessages(1, "Gửi Email Thành Công");
                    }
                    else {
                        displayMessages(3, "Gửi Email Thất Bại");
                    }
                    hideLoading();
                }
            });
        }
    });
    // Content Email
    $('#summernote').summernote('code', $("#CContent").val());
    $("#summernote").summernote({
        height: 400,
    });
    $('#btnViewSendEmail').click(function () {
        emails = [];
        maHocSinhs = [];
        //Get list maHocSinh có checkbox = true
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            maHocSinhs.push(parseInt(checkboxId));
        });
        //Lấy email nhân viên đang show chi tiết
        if (isValidEmail($('#hocSinh_EmailCha').val()) && maHocSinhs.length <= 2) {
            emails.push($('#hocSinh_EmailCha').val());
        }

        if (isValidEmail($('#hocSinh_EmailMe').val()) && maHocSinhs.length <= 2) {
            emails.push($('#hocSinh_EmailMe').val());
        }

        //Lấy thông tin email dựa vào tham số object HocSinh
        $.ajax({
            type: "POST",
            url: "/Admin/HocSinh/SearchName",
            async: false,
            data: { item: hocSinh },
            success: function (data) {
                $.each(data.$values, function (index, item) {
                    $.each(maHocSinhs, function (indexMa, ma) {
                        if (item.maHocSinh === ma) {
                            if (isValidEmail(item.emailCha)) {
                                emails.push(item.emailCha);
                            }
                            if (isValidEmail(item.emailMe)) {
                                emails.push(item.emailMe);
                                maHocSinhs.splice(indexMa, 1); // Xóa phần tử khớp từ mảng maHocSinhs
                            }
                        }
                    });
                });
            }
        });
        UpdateTableEmail();
    });


});