function isValidMonHoc(item) {
    if (CheckIsNull(item.TenMonHoc)) {
        displayMessages(2, "Vui lòng nhập (Tên môn học)");
        return false;
    } else if (CheckIsNull(item.Gia)) {
        displayMessages(2, "Vui lòng nhập (Giá)");
        return false;
    } else {
        return true;
    }
}

function GetMonHocData() {
    return {
        MaMonHoc: $('#monHoc_MaMonHoc').val(),
        TenMonHoc: $('#monHoc_TenMonHoc').val(),
        ThongTin: $('#monHoc_ThongTin').val(),
        Gia: $('#monHoc_Gia').val(),
    };
}

function CreateMonHoc() {
    let item = GetMonHocData();
    // Kiểm tra tính hợp lệ
    if (isValidMonHoc(item)) {
        let status = false;
        item.MaMonHoc = null;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/MonHoc/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateMonHoc() {
    let item = GetMonHocData();
    // Kiểm tra tính hợp lệ
    if (isValidMonHoc(item) && CheckIsNull(item.MaMonHoc)!=true) {
        let status = false;
        // Gửi dữ liệu thông qua AJAX để cập nhật vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/MonHoc/Update",
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
    let monHoc = {
        MaMonHoc: null,
        TenMonHoc: null,
        Gia: null,
        ThongTin: null
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
            url: "/Admin/MonHoc/LoadingDataTableView",
            dataType: "json",
            data: { item: monHoc },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maMonHoc',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
            }
            },
            { data: "tenMonHoc" },
            {
                data: 'gia',
                render: function (data, type, row) {
                    return formatToVND(data);
                }
            },
            { data: "thongTin" }
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
            const rowId = table.row(this).data().maMonHoc;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/MonHoc/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#monHoc_MaMonHoc').val(data.maMonHoc);
                    $('#monHoc_TenMonHoc').val(data.tenMonHoc);
                    $('#monHoc_ThongTin').val(data.thongTin);
                    $('#monHoc_Gia').val(data.gia);
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
    $('#btnCreateMonHoc').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateMonHoc() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/MonHoc/GetByIdTable",
                async: false,
                data: { id: $('#monHoc_MaMonHoc').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maMonHoc = '<input data-checkbox-id="' + itemView.maMonHoc + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateMonHoc').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateMonHoc() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/MonHoc/GetByIdTable",
                async: false,
                data: { id: $('#monHoc_MaMonHoc').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maMonHoc = '<input data-checkbox-id="' + itemView.maMonHoc + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteMonHoc').click(function () {
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
                url: "/Admin/MonHoc/Delete",
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
                    if (rowData && rowData.maMonHoc) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maMonHoc + '"]');
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

    $('#btnResetMonHoc').click(function () {
        $('#monHoc_MaMonHoc').val(null);
        $('#monHoc_TenMonHoc').val(null);
        $('#monHoc_ThongTin').val(null);
        $('#monHoc_Gia').val(null);
    });

    $('#btnSearchMonHoc').click(function () {
        monHoc = GetMonHocData();
        
        table.settings()[0].ajax.data = { item: monHoc };
        table.ajax.reload();
    });
});