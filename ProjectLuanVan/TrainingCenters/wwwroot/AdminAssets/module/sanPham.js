function isValidSanPham(item) {
    // Kiểm tra tính hợp lệ
    if (CheckIsNull(item.TenSanPham)) {
        displayMessages(2, "Vui lòng nhập (Tên sản phẩm)");
        return false;
    } else if (CheckIsNull(item.HanSuDung)) {
        displayMessages(2, "Vui lòng chọn (Hạn sử dụng)");
        return false;
    } else if (CheckIsNull(item.LoaiSanPham)) {
        displayMessages(2, "Vui lòng chọn (Loại sản phẩm)");
        return false;
    } else if (CheckIsNull(item.MaNhaCungCap)) {
        displayMessages(2, "Vui lòng chọn (Nhà cung cấp)");
        return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Trung tâm)");
        return false;
    } else if (CheckIsNull(item.Gia)) {
        displayMessages(2, "Vui lòng nhập (Giá)");
        return false;
    } else {
        return true;
    }
}

function GetSanPhamById() {
    let item = {
        MaSanPham: $('#sanPham_MaSanPham').val(),
        TenSanPham: $('#sanPham_TenSanPham').val(),
        ThongTin: $('#sanPham_ThongTin').val(),
        Gia: $('#sanPham_Gia').val(),
        HanSuDung: $('#sanPham_HanSuDung').val(),
        LoaiSanPham: $('#sanPham_LoaiSanPham').val(),
        MaNhaCungCap: $('#sanPham_MaNhaCungCap').val(),
        MaTrungTam: $('#sanPham_MaTrungTam').val()
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
            $('#sanPham_MaTrungTam').empty();
            $('#sanPham_MaTrungTam').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#sanPham_MaTrungTam').append($('<option>', {
                    value: item.maTrungTam,
                    text: item.tenTrungTam
                }));
            });
        }
    });

}

function CbbNhaCungCapByMaTrungTam() {
    let trungTam = $('#sanPham_MaTrungTam').val();
    if (trungTam != 0 && trungTam != null) {

        let nhaCungCap = {
            MaNhaCungCap: null,
            TenNhaCungCap: null,
            GioiThieu: null,
            Email: null,
            SoDienThoai: null,
            NganHang: null,
            SoTaiKhoan: null,
            MaSoThue: null,
            MaTrungTam: trungTam
        };

        $.ajax({
            type: "POST",
            url: "/Admin/NhaCungCap/SearchName",
            async: false,
            data: { item: nhaCungCap },
            success: function (data) {
                $('#sanPham_MaNhaCungCap').empty();
                $('#sanPham_MaNhaCungCap').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
                $.each(data.$values, function (index, item) {
                    $('#sanPham_MaNhaCungCap').append($('<option>', {
                        value: item.maNhaCungCap,
                        text: item.tenNhaCungCap
                    }));
                });
            }
        });
    }
    else {
        $('#sanPham_MaNhaCungCap').empty();
        $('#sanPham_MaNhaCungCap').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
    }
}

function CreateSanPham() {
    let item = GetSanPhamById();
    // Kiểm tra tính hợp lệ
    if (isValidSanPham(item)) {
        item.MaSanPham = null;
        let status = false;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/SanPham/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateSanPham() {
    let item = GetSanPhamById();
    // Kiểm tra tính hợp lệ
    if (isValidSanPham(item)&& CheckIsNull(item.MaSanPham)!=true){
        let status = false;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/SanPham/Update",
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
    var sanPham = {
        MaSanPham: null,
        TenSanPham: null,
        ThongTin: null,
        LoaiSanPham: null,
        HanSuDung: null,
        MaNhaCungCap: null,
        MaTrungTam: null,
        Gia: null
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
            url: "/Admin/SanPham/LoadingDataTableView",
            dataType: "json",
            data: { item: sanPham },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maSanPham',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
            }
            },
            { data: "tenSanPham" },
            { data: "loaiSanPham" },
            { data: "hanSuDung" },
            {
                data: 'gia',
                render: function (data, type, row) {
                    return formatToVND(data);
                }
            },
            { data: "tenNhaCungCap" },
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
            const rowId = table.row(this).data().maSanPham;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/SanPham/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#sanPham_MaSanPham').val(data.maSanPham);
                    $('#sanPham_TenSanPham').val(data.tenSanPham);
                    $('#sanPham_ThongTin').val(data.thongTin);
                    $('#sanPham_Gia').val(data.gia);
                    $('#sanPham_HanSuDung').val(data.hanSuDung);
                    $('#sanPham_LoaiSanPham').val(data.loaiSanPham);
                    $('#sanPham_MaTrungTam').val(data.maTrungTam);
                    CbbNhaCungCapByMaTrungTam();
                    $('#sanPham_MaNhaCungCap').val(data.maNhaCungCap);
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
    CbbNhaCungCapByMaTrungTam();
    $('#sanPham_MaTrungTam').change(function () {
        CbbNhaCungCapByMaTrungTam();
    });
    // ============================================== BUTTON ===============================================
    $('#btnCreateSanPham').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateSanPham() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/SanPham/GetByIdTable",
                async: false,
                data: { id: $('#sanPham_MaSanPham').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maSanPham = '<input data-checkbox-id="' + itemView.maSanPham + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateSanPham').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateSanPham() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/SanPham/GetByIdTable",
                async: false,
                data: { id: $('#sanPham_MaSanPham').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maSanPham = '<input data-checkbox-id="' + itemView.maSanPham + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteSanPham').click(function () {
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
                url: "/Admin/SanPham/Delete",
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
                    if (rowData && rowData.maSanPham) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maSanPham + '"]');
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

    $('#btnResetSanPham').click(function () {
        $('#sanPham_MaSanPham').val(null);
        $('#sanPham_TenSanPham').val(null);
        $('#sanPham_ThongTin').val(null);
        $('#sanPham_Gia').val(null);
        $('#sanPham_HanSuDung').val("Tất cả");
        $('#sanPham_LoaiSanPham').val("Tất cả");
        $('#sanPham_MaNhaCungCap').val(0);
        $('#sanPham_MaTrungTam').val(0);
    });

    $('#btnSearchSanPham').click(function () {
        sanPham = GetSanPhamById();

        if (sanPham.LoaiSanPham == "Tất cả") {
            sanPham.LoaiSanPham = null;
        }
        if (sanPham.HanSuDung == "Tất cả") {
            sanPham.HanSuDung = null;
        }
        if (sanPham.MaNhaCungCap == 0) {
            sanPham.MaNhaCungCap = null;
        }
        if (sanPham.MaTrungTam == 0) {
            sanPham.MaTrungTam = null;
        }
        table.settings()[0].ajax.data = { item: sanPham };
        table.ajax.reload();
    });
});