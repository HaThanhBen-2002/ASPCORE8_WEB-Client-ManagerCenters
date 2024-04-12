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
});