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

async function CreateMonHoc() {
    let item = GetMonHocData();
    if (isValidMonHoc(item)) {
        item.MaMonHoc = null;
        let status = await MonHoc_Create(item)
        return status;
    }
}
async function UpdateMonHoc() {
    let item = GetMonHocData();
    if (isValidMonHoc(item) && CheckIsNull(item.MaMonHoc) != true) {
        let status = await MonHoc_Update(item)
        return status;
    }
}

$(document).ready(async function () {
    await CapNhatToken();
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
            url: "/MonHoc/LoadingDataTableView",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            dataType: "json",
            data: { item: monHoc },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
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
            // Thêm sự kiện cho việc thay đổi số lượng row trên trang
            $('#myTable').on('length.dt', function (e, settings, len) {
                // Gọi hàm CapNhatToken() khi có sự thay đổi
                CapNhatToken().then(() => {
                }).catch(error => {
                    console.error("Cập nhật token thất bại:", error);
                });
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
    $('#myTable tbody').on('click', 'tr', async function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected')
        } else {
            table.$('tr.selected').removeClass('selected')
            $(this).addClass('selected')
            // xử lý ở đây
            const rowId = table.row(this).data().maMonHoc;
            let data = await MonHoc_GetById(rowId);
            $('#monHoc_MaMonHoc').val(data.maMonHoc);
            $('#monHoc_TenMonHoc').val(data.tenMonHoc);
            $('#monHoc_ThongTin').val(data.thongTin);
            $('#monHoc_Gia').val(data.gia);
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
    $('#btnCreateMonHoc').click(async function () {
        //If Status Create = True => Update Row Table
        if (await CreateMonHoc() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView = await MonHoc_GetByIdTable($('#monHoc_MaMonHoc').val());
            itemView.maMonHoc = '<input data-checkbox-id="' + itemView.maMonHoc + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateMonHoc').click(async function () {
        //If Status Create = True => Update Row Table
        if (await UpdateMonHoc() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView = await MonHoc_GetByIdTable($('#monHoc_MaMonHoc').val());
            itemView.maMonHoc = '<input data-checkbox-id="' + itemView.maMonHoc + '" type="checkbox"/>';
            if (itemView != null) {
                // Xóa các hàng được chọn
                table.rows('.selected').remove();
                // Thêm hàng mới vào table
                table.row.add(itemView);
                // Vẽ lại table một lần
                table.draw(false);
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

    $('#btnDelete').click(async function () {
        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });

        if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
            let statusDelete = await MonHoc_Delete(selectedIds, "Nhân viên Test");
            if (statusDelete == true) {
                displayMessages(1, "Xóa thành công");
                $("#DeleteModal").modal("hide");
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
            else {
                displayMessages(3, "Xóa thất bại");
            }
        }
    });

    $('#btnResetMonHoc').click(function () {
        $('#monHoc_MaMonHoc').val(null);
        $('#monHoc_TenMonHoc').val(null);
        $('#monHoc_ThongTin').val(null);
        $('#monHoc_Gia').val(null);
    });

    $('#btnSearchMonHoc').click(async function () {
        await CapNhatToken();
        monHoc = GetMonHocData();
        table.settings()[0].ajax.data = { item: monHoc };
        table.ajax.reload();
    });
});