


function isValidDichVu(item) {
    // Kiểm tra tính hợp lệ
    if (CheckIsNull(item.TenDichVu )) {
        displayMessages(2, "Vui lòng nhập (Tên dịch vụ)"); return false;
    } else if (CheckIsNull(item.Gia)) {
        displayMessages(2, "Vui lòng nhập (Giá)"); return false;
    } else {
        return true;
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
async function CreateDichVu() {
    let item = GetDichVuById();
    if (isValidDichVu(item)) {
        item.MaDichVu = null;
        let status = await DichVu_Create(item)
        return status;
    }
}
async function UpdateDichVu() {
    let item = GetDichVuById();
    if (isValidDichVu(item) && CheckIsNull(item.MaDichVu) != true) {
        let status = await DichVu_Update(item)
        return status;
    }
}

$(document).ready(async function () {
    await CapNhatToken();
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
            url: "/DichVu/LoadingDataTableView",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            dataType: "json",
            data: { item: dichVu },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
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
    $('#myTable tbody').on('click', 'tr',async function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected')
        } else {
            table.$('tr.selected').removeClass('selected')
            $(this).addClass('selected')
            const rowId = table.row(this).data().maDichVu;
            let data = await DichVu_GetById(rowId);
            $('#dichVu_MaDichVu').val(data.maDichVu);
            $('#dichVu_TenDichVu').val(data.tenDichVu);
            $('#dichVu_ThongTin').val(data.thongTin);
            $('#dichVu_Gia').val(data.gia);
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
    $('#btnCreateDichVu').click(async function () {
        //If Status Create = True => Update Row Table
        if (await CreateDichVu() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView = await DichVu_GetByIdTable($('#dichVu_MaDichVu').val());
            itemView.maDichVu = '<input data-checkbox-id="' + itemView.maDichVu + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateDichVu').click(async function () {
        //If Status Create = True => Update Row Table
        if (await UpdateDichVu() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView =await DichVu_GetByIdTable($('#dichVu_MaDichVu').val());
            itemView.maDichVu = '<input data-checkbox-id="' + itemView.maDichVu + '" type="checkbox"/>';
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

    $('#btnDelete').click(async function () {
        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });

        if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
            let statusDelete = await DichVu_Delete(selectedIds,"Nhân viên Test");
            if (statusDelete == true) {
                displayMessages(1, "Xóa thành công");
                $("#DeleteModal").modal("hide");
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
            else {
                displayMessages(3, "Xóa thất bại");
            }
        }
    });

    $('#btnResetDichVu').click(function () {
        $('#dichVu_MaDichVu').val(null);
        $('#dichVu_TenDichVu').val(null);
        $('#dichVu_ThongTin').val(null);
        $('#dichVu_Gia').val(null);
    });

    $('#btnSearchDichVu').click(async function () {
        await CapNhatToken();
        dichVu = GetDichVuById();
        table.settings()[0].ajax.data = { item: dichVu };
        table.ajax.reload();
    });
});