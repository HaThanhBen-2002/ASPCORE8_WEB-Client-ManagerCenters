

function isValidLoSanPham(item) {
    // Kiểm tra tính hợp lệ
    if (CheckIsNull(item.TenLoSanPham)) {
        displayMessages(2, "Vui lòng nhập (Tên lô sản phẩm)"); return false;
    } else if (CheckIsNull(item.MaSanPham)) {
        displayMessages(2, "Vui lòng chọn (Mã sản phẩm)");; return false;
    } else if (CheckIsNull(item.SoLuong)) {
        displayMessages(2, "Vui lòng nhập (Số lượng)");; return false;
    } else if (CheckIsNull(item.DonVi)) {
        displayMessages(2, "Vui lòng nhập (Đơn vị)");; return false;
    } else if (CheckIsNull(item.NgayNhap)) {
        displayMessages(2, "Vui lòng nhập (Ngày nhập)");; return false;
    } else if (CheckIsNull(item.TrangThai)) {
        displayMessages(2, "Vui lòng chọn (Trạng thái)");; return false;
    } else if (CheckIsNull(item.MaNhanVien)) {
        displayMessages(2, "Vui lòng chọn (Nhân viên)");; return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Trung Tâm)");; return false;
    } else if (CheckIsNull(item.NgayHetHan)) {
        displayMessages(2, "Vui lòng nhập (Ngày hết hạn)");; return false;
    } else {
        return true
    }
}

function GetLoSanPhamById() {
    let item = {
        MaLoSanPham: $('#loSanPham_MaLoSanPham').val(),
        TenLoSanPham: $('#loSanPham_TenLoSanPham').val(),
        MaSanPham: $('#loSanPham_MaSanPham').val(),
        SoLuong: $('#loSanPham_SoLuong').val(),
        DonVi: $('#loSanPham_DonVi').val(),
        NgayNhap: $('#loSanPham_NgayNhap').val(),
        NgayHetHan: $('#loSanPham_NgayHetHan').val(),
        GhiChu: $('#loSanPham_GhiChu').val(),
        TrangThai: $('#loSanPham_TrangThai').val(),
        MaNhanVien: $('#loSanPham_MaNhanVien').val(),
        MaTrungTam: $('#loSanPham_MaTrungTam').val()
    };
    return item;
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
            $('#loSanPham_MaTrungTam').empty();
            $('#loSanPham_MaTrungTam').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#loSanPham_MaTrungTam').append($('<option>', {
                    value: item.maTrungTam,
                    text: item.tenTrungTam
                }));
            });
        }
    });

}

function CbbNhanVienByMaTrungTam() {
    let trungTam = $('#loSanPham_MaTrungTam').val();
    if (trungTam != 0 && trungTam != null) {

        let nhanVien = {
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
            MaTrungTam: trungTam,
            MaTaiKhoan: null,
            LoaiNhanVien: "Quản lý kho",
            PhongBan: null,
            Luong: null,
            NganHang: null,
            SoTaiKhoan: null,
            DanToc: null,
            TonGiao: null
        };
        $.ajax({
            type: "POST",
            url: "/Admin/NhanVien/SearchName",
            async: false,
            data: { item: nhanVien },
            success: function (data) {
                $('#loSanPham_MaNhanVien').empty();
                $('#loSanPham_MaNhanVien').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
                $.each(data.$values, function (index, item) {
                    $('#loSanPham_MaNhanVien').append($('<option>', {
                        value: item.maNhanVien,
                        text: item.tenNhanVien
                    }));
                });
            }
        });
    }
    else {
        $('#loSanPham_MaNhanVien').empty();
        $('#loSanPham_MaNhanVien').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
    }
}

function CbbSanPhamByMaTrungTamByLoaiSanPham() {
    let trungTam = $('#loSanPham_MaTrungTam').val();
    let loaiSanPham = $('#sanPham_LoaiSanPham').val();
    if (loaiSanPham == "Tất cả") {
        loaiSanPham = null;
    }
    if (trungTam != 0 && trungTam != null) {

        let sanPham = {
            MaSanPham: null,
            TenSanPham: null,
            ThongTin: null,
            LoaiSanPham: loaiSanPham,
            HanSuDung: null,
            MaNhaCungCap: null,
            MaTrungTam: trungTam,
            Gia: null
        };

        $.ajax({
            type: "POST",
            url: "/Admin/SanPham/SearchName",
            async: false,
            data: { item: sanPham },
            success: function (data) {
                $('#loSanPham_MaSanPham').empty();
                $('#loSanPham_MaSanPham').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
                $.each(data.$values, function (index, item) {
                    $('#loSanPham_MaSanPham').append($('<option>', {
                        value: item.maSanPham,
                        text: item.tenSanPham
                    }));
                });
            }
        });
    }
    else {
        $('#loSanPham_MaSanPham').empty();
        $('#loSanPham_MaSanPham').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
    }
}

function CreateLoSanPham() {
    let item = GetLoSanPhamById();
    // Kiểm tra tính hợp lệ
    if (isValidLoSanPham(item)){
        let status = false;
        item.MaLoSanPham = null;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/LoSanPham/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateLoSanPham() {
    
    let item = GetLoSanPhamById();
    // Kiểm tra tính hợp lệ
    if (isValidLoSanPham(item) && CheckIsNull(item.MaLoSanPham)!=true) {
        let status = false;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/LoSanPham/Update",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

$(document).ready(function () {
   // ============================================== TABLE ===============================================
    var loSanPham = {
        MaLoSanPham: null,
        TenLoSanPham: null,
        TrangThai: null,
        MaSanPham: null,
        SoLuong: null,
        DonVi: null,
        NgayNhap: null,
        NgayHetHan: null,
        MaNhanVien: null,
        MaTrungTam: null,
        GhiChu: null
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
            url: "/Admin/LoSanPham/LoadingDataTableView",
            dataType: "json",
            data: { item: loSanPham },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maLoSanPham',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
            }
            },
            { data: "tenLoSanPham" },
            { data: "tenSanPham" },
            { data: "trangThai" },
            { data: "ngayNhap" },
            
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
            const rowId = table.row(this).data().maLoSanPham;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/LoSanPham/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#sanPham_LoaiSanPham').val("Tất cả");
                    $('#loSanPham_MaLoSanPham').val(data.maLoSanPham);
                    $('#loSanPham_TenLoSanPham').val(data.tenLoSanPham);
                    $('#loSanPham_SoLuong').val(data.soLuong);
                    $('#loSanPham_DonVi').val(data.donVi);
                    $('#loSanPham_NgayNhap').val(data.ngayNhap);
                    $('#loSanPham_NgayHetHan').val(data.ngayHetHan);
                    $('#loSanPham_GhiChu').val(data.ghiChu);
                    $('#loSanPham_MaTrungTam').val(data.maTrungTam);
                    CbbNhanVienByMaTrungTam();
                    CbbSanPhamByMaTrungTamByLoaiSanPham();
                    $('#loSanPham_MaSanPham').val(data.maSanPham);
                    $('#loSanPham_TrangThai').val(data.trangThai);
                    $('#loSanPham_MaNhanVien').val(data.maNhanVien);
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

    // ============================================== CBB ===============================================
    CbbTrungTam();
    CbbNhanVienByMaTrungTam();
    CbbSanPhamByMaTrungTamByLoaiSanPham();
    $('#loSanPham_MaTrungTam').change(function () {
        CbbNhanVienByMaTrungTam();
        CbbSanPhamByMaTrungTamByLoaiSanPham();
    });
    $('#sanPham_LoaiSanPham').change(function () {
        CbbSanPhamByMaTrungTamByLoaiSanPham();
    });
    // ============================================== BUTTON ===============================================
    $('#btnCreateLoSanPham').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateLoSanPham() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/LoSanPham/GetByIdTable",
                async: false,
                data: { id: $('#loSanPham_MaLoSanPham').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maLoSanPham = '<input data-checkbox-id="' + itemView.maLoSanPham + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateLoSanPham').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateLoSanPham() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/LoSanPham/GetByIdTable",
                async: false,
                data: { id: $('#loSanPham_MaLoSanPham').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maLoSanPham = '<input data-checkbox-id="' + itemView.maLoSanPham + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteLoSanPham').click(function () {
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
                url: "/Admin/LoSanPham/Delete",
                async: false,
                data: { ids: selectedIds, nguoiXoa:"Nhân viên TEST" }, // Truyền danh sách ID đến action
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
                    if (rowData && rowData.maLoSanPham) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maLoSanPham + '"]');
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

    $('#btnResetLoSanPham').click(function () {
        $('#sanPham_LoaiSanPham').val("Tất cả");
        $('#loSanPham_MaLoSanPham').val(null);
        $('#loSanPham_TenLoSanPham').val(null);
        $('#loSanPham_SoLuong').val(null);
        $('#loSanPham_DonVi').val(null);
        $('#loSanPham_NgayNhap').val(null);
        $('#loSanPham_NgayHetHan').val(null);
        $('#loSanPham_GhiChu').val(null);
        $('#loSanPham_MaTrungTam').val(0);
        CbbNhanVienByMaTrungTam(); // Giả sử hàm này làm một số thao tác liên quan đến DOM hoặc dữ liệu, bạn có thể cần kiểm tra xem nó cần được gọi như thế nào khi gán giá trị null cho các phần tử.
        CbbSanPhamByMaTrungTamByLoaiSanPham(); // Tương tự như trên, hàm này cũng cần được xem xét khi gán giá trị null cho các phần tử.
        $('#loSanPham_MaSanPham').val(0);
        $('#loSanPham_TrangThai').val("Tất cả");
        $('#loSanPham_MaNhanVien').val(0);

    });

    $('#btnSearchLoSanPham').click(function () {
        loSanPham = GetLoSanPhamById();
        // Bạn có thể thêm các xử lý bổ sung ở đây nếu cần
        if (loSanPham.MaTrungTam == 0) {
            loSanPham.MaTrungTam = null;
        }
        if (loSanPham.MaNhanVien == 0) {
            loSanPham.MaNhanVien = null;
        }
        if (loSanPham.MaSanPham == 0) {
            loSanPham.MaSanPham = null;
        }
        if (loSanPham.TrangThai == "Tất cả") {
            loSanPham.TrangThai = null;
        }
        table.settings()[0].ajax.data = { item: loSanPham };
        table.ajax.reload();

    });
});