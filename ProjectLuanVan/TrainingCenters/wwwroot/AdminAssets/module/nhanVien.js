function isValidNhanVien(item) {
    // Kiểm tra tính hợp lệ
    if (CheckIsNull(item.TenNhanVien)) {
        displayMessages(2, "Vui lòng nhập (Tên nhân viên)"); return false;
    } else if (CheckIsNull(item.Cccd)) {
        displayMessages(2, "Vui lòng nhập (CCCD)"); return false;
    } else if (CheckIsNull(item.NgaySinh)) {
        displayMessages(2, "Vui lòng nhập (Ngày sinh)"); return false;
    } else if (CheckIsNull(item.SoDienThoai)) {
        displayMessages(2, "Vui lòng nhập (Số điện thoại)"); return false;
    } else if (CheckIsNull(item.Email)) {
        displayMessages(2, "Vui lòng nhập (Email)"); return false;
    } else if (CheckIsNull(item.Luong)) {
        displayMessages(2, "Vui lòng nhập (Lương)"); return false;
    } else if (CheckIsNull(item.NganHang)) {
        displayMessages(2, "Vui lòng nhập (Mã tài khoản)"); return false;
    } else if (CheckIsNull(item.SoTaiKhoan)) {
        displayMessages(2, "Vui lòng nhập (Số tài khoản)"); return false;
    } else if (CheckIsNull(item.GioiTinh)) {
        displayMessages(2, "Vui lòng chọn (Giới tính)"); return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Trung tâm)"); return false;
    } else if (CheckIsNull(item.LoaiNhanVien)) {
        displayMessages(2, "Vui lòng chọn (Loại nhân viên)"); return false;
    } else if (CheckIsNull(item.PhongBan)) {
        displayMessages(2, "Vui lòng chọn (Phòng ban)"); return false;
    } else if (CheckIsNull(item.DanToc)) {
        displayMessages(2, "Vui lòng chọn (Dân tộc)"); return false;
    } else if (CheckIsNull(item.TonGiao)) {
        displayMessages(2, "Vui lòng chọn (Tôn giáo)"); return false;
    } else {
        return true;
    }
}

function GetNhanVienById() {
    let item = {
        MaNhanVien: $('#nhanVien_MaNhanVien').val(),
        TenNhanVien: $('#nhanVien_TenNhanVien').val(),
        Cccd: $('#nhanVien_Cccd').val(),
        NgaySinh: $('#nhanVien_NgaySinh').val(),
        DiaChi: $('#nhanVien_DiaChi').val(),
        SoDienThoai: $('#nhanVien_SoDienThoai').val(),
        Email: $('#nhanVien_Email').val(),
        ThongTin: $('#nhanVien_ThongTin').val(),
        Luong: $('#nhanVien_Luong').val(),
        MaTaiKhoan: $('#nhanVien_MaTaiKhoan').val(),
        NganHang: $('#nhanVien_NganHang').val(),
        SoTaiKhoan: $('#nhanVien_SoTaiKhoan').val(),
        GioiTinh: $('#nhanVien_GioiTinh').val(),
        MaTrungTam: $('#nhanVien_MaTrungTam').val(),
        LoaiNhanVien: $('#nhanVien_LoaiNhanVien').val(),
        PhongBan: $('#nhanVien_PhongBan').val(),
        DanToc: $('#nhanVien_DanToc').val(),
        TonGiao: $('#nhanVien_TonGiao').val(),
        HinhAnh: $('#imageShow').attr('src')
    };

    return item;
}

function CreateNhanVien() {
    let item = GetNhanVienById();
    if (isValidNhanVien(item)) {
        item.MaNhanVien = null;
        let status = false;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/NhanVien/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateNhanVien() {

    let item = GetNhanVienById();

    if (isValidNhanVien(item) && CheckIsNull(item.MaNhanVien)!=true){
        let status = false;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/NhanVien/Update",
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
            $('#nhanVien_MaTrungTam').empty();
            $('#nhanVien_MaTrungTam').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#nhanVien_MaTrungTam').append($('<option>', {
                    value: item.maTrungTam,
                    text: item.tenTrungTam
                }));
            });
        }
    });

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
    var nhanVien = {
        MaNhanVien: null,
        TenNhanVien: null,
        Cccd: null,
        NgaySinh: null,
        GioiTinh: null,
        DiaChi: null,
        SoDienThoai: null,
        Email: null,
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
    // Loading Data Table
    $('#myTable').DataTable({
        serverSide: true,
        scrollY: 400,
        searching: false,
        lengthChange: true,
        ordering: false,
        ajax: {
            type: "POST",
            url: "/Admin/NhanVien/LoadingDataTableView",
            dataType: "json",
            data: { item: nhanVien },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maNhanVien',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                }
            },
            { data: "tenNhanVien" },
            { data: "loaiNhanVien" },
            { data: "ngaySinh" },
            { data: "gioiTinh" },
            { data: "phongBan" }
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
            const rowId = table.row(this).data().maNhanVien;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/NhanVien/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#nhanVien_MaNhanVien').val(data.maNhanVien);
                    $('#nhanVien_TenNhanVien').val(data.tenNhanVien);
                    $('#nhanVien_Cccd').val(data.cccd);
                    $('#nhanVien_NgaySinh').val(data.ngaySinh);
                    $('#nhanVien_DiaChi').val(data.diaChi);
                    $('#nhanVien_SoDienThoai').val(data.soDienThoai);
                    $('#nhanVien_Email').val(data.email);
                    $('#nhanVien_ThongTin').val(data.thongTin);
                    $('#nhanVien_Luong').val(data.luong);
                    $('#nhanVien_MaTaiKhoan').val(data.maTaiKhoan);
                    $('#nhanVien_NganHang').val(data.nganHang);
                    $('#nhanVien_SoTaiKhoan').val(data.soTaiKhoan);
                    $('#nhanVien_GioiTinh').val(data.gioiTinh);
                    $('#nhanVien_MaTrungTam').val(data.maTrungTam);
                    $('#nhanVien_LoaiNhanVien').val(data.loaiNhanVien);
                    $('#nhanVien_PhongBan').val(data.phongBan);
                    $('#nhanVien_DanToc').val(data.danToc);
                    $('#nhanVien_TonGiao').val(data.tonGiao);
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
    
    // ============================================== BUTTON ===============================================
    $('#btnCreateNhanVien').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateNhanVien() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/NhanVien/GetByIdTable",
                async: false,
                data: { id: $('#nhanVien_MaNhanVien').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maNhanVien = '<input data-checkbox-id="' + itemView.maNhanVien + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateNhanVien').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateNhanVien() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/NhanVien/GetByIdTable",
                async: false,
                data: { id: $('#nhanVien_MaNhanVien').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maNhanVien = '<input data-checkbox-id="' + itemView.maNhanVien + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteNhanVien').click(function () {
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
                url: "/Admin/NhanVien/Delete",
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
                    if (rowData && rowData.maNhanVien) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maNhanVien + '"]');
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

    $('#btnResetNhanVien').click(function () {
        $('#nhanVien_MaNhanVien').val(null);
        $('#nhanVien_TenNhanVien').val(null);
        $('#nhanVien_Cccd').val(null);
        $('#nhanVien_NgaySinh').val(null);
        $('#nhanVien_DiaChi').val(null);
        $('#nhanVien_SoDienThoai').val(null);
        $('#nhanVien_Email').val(null);
        $('#nhanVien_ThongTin').val(null);
        $('#nhanVien_Luong').val(null);
        $('#nhanVien_MaTaiKhoan').val(null);
        $('#nhanVien_NganHang').val("Tất cả");
        $('#nhanVien_SoTaiKhoan').val(null);
        $('#nhanVien_GioiTinh').val("Tất cả");
        $('#nhanVien_MaTrungTam').val(0);
        $('#nhanVien_LoaiNhanVien').val("Tất cả");
        $('#nhanVien_PhongBan').val("Tất cả");
        $('#nhanVien_DanToc').val("Tất cả");
        $('#nhanVien_TonGiao').val("Tất cả");
        $('#imageShow').attr('src', null);
    });

    $('#btnSearchNhanVien').click(function () {

        nhanVien = GetNhanVienById();
        nhanVien.HinhAnh = null;
        // Bạn có thể thêm các xử lý bổ sung ở đây nếu cần
        if (nhanVien.DanToc == "Tất cả") {
            nhanVien.DanToc = null;
        }
        if (nhanVien.TonGiao == "Tất cả") {
            nhanVien.TonGiao = null;
        }
        if (nhanVien.NganHang == "Tất cả") {
            nhanVien.NganHang = null;
        }
        if (nhanVien.PhongBan == "Tất cả") {
            nhanVien.PhongBan = null;
        }
        if (nhanVien.LoaiNhanVien == "Tất cả") {
            nhanVien.LoaiNhanVien = null;
        }
        if (nhanVien.GioiTinh == "Tất cả") {
            nhanVien.GioiTinh = null;
        }
        if (nhanVien.MaTrungTam == 0) {
            nhanVien.MaTrungTam = null;
        }

        table.settings()[0].ajax.data = { item: nhanVien };
        table.ajax.reload();
       
    });
});