function CheckIsNullDichVu(item) {
    // Kiểm tra tính hợp lệ
    if (CheckIsNull(item.TenDichVu )) {
        displayMessages(2, "Vui lòng nhập (Tên dịch vụ)"); return true;
    } else if (CheckIsNull(item.ThongTin)) {
        displayMessages(2, "Vui lòng nhập (Thông tin)"); return true;
    } else if (CheckIsNull(item.Gia)) {
        displayMessages(2, "Vui lòng nhập (Giá)"); return true;
    } else {
        return false;
    }
}
function GetDichVuById() {
    let item = {
        MaDichVu: $('#dichVu_MaDichVu').val(),
        TenDichVu: $('#dichVu_TenDichVu').val(),
        ThongTin: $('#dichVu_ThongTin').val(),
        Gia: $('#dichVu_Gia').val(),
    };
    return item;
}
function CreateDichVu() {
    let item = GetDichVuById();
    // Kiểm tra tính hợp lệ
    if (CheckIsNullDichVu(item)!=true) {
        let status = false;
        item.MaDichVu = null;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/DichVu/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateDichVu() {
    let item = GetDichVuById();

    // Kiểm tra tính hợp lệ
    if (CheckIsNullDichVu(item) != true && CheckIsNull(item.MaDichVu)!=true) {
        let status = false;
        // Gửi dữ liệu thông qua AJAX để cập nhật vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/DichVu/Update",
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
    var dichVu = {
        MaDichVu: null,
        TenDichVu: null,
        ThongTin: null,
        Gia: null,
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
            url: "/Admin/DichVu/LoadingDataTableView",
            dataType: "json",
            data: { item: dichVu },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maDichVu',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
            }
            },
            { data: "tenDichVu" },
            {
                data: 'gia',
                render: function (data, type, row) {
                    return formatToVND(data);
                }
            }
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
            const rowId = table.row(this).data().maDichVu;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/DichVu/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#dichVu_MaDichVu').val(data.maDichVu);
                    $('#dichVu_TenDichVu').val(data.tenDichVu);
                    $('#dichVu_ThongTin').val(data.thongTin);
                    $('#dichVu_Gia').val(data.gia);
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
    // ============================================== BUTTON ===============================================
    $('#btnCreateDichVu').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateDichVu() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/DichVu/GetByIdTable",
                async: false,
                data: { id: $('#dichVu_MaDichVu').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maDichVu = '<input data-checkbox-id="' + itemView.maDichVu + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateDichVu').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateDichVu() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/DichVu/GetByIdTable",
                async: false,
                data: { id: $('#dichVu_MaDichVu').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maDichVu = '<input data-checkbox-id="' + itemView.maDichVu + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteDichVu').click(function () {
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
                url: "/Admin/DichVu/Delete",
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
                    if (rowData && rowData.maDichVu) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maDichVu + '"]');
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

    $('#btnResetDichVu').click(function () {
        $('#dichVu_MaDichVu').val(null);
        $('#dichVu_TenDichVu').val(null);
        $('#dichVu_ThongTin').val(null);
        $('#dichVu_Gia').val(null);

    });

    $('#btnSearchDichVu').click(function () {
        dichVu = GetDichVuById();
        table.settings()[0].ajax.data = { item: dichVu };
        table.ajax.reload();
    });
});