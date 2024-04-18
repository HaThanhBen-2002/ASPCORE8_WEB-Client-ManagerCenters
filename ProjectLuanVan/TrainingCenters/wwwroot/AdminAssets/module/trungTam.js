
function GetTrungTamById() {
    let item = {
        MaTrungTam: $('#trungTam_MaTrungTam').val(),
        TenTrungTam: $('#trungTam_TenTrungTam').val(),
        DiaChi: $('#trungTam_DiaChi').val(),
        Email: $('#trungTam_Email').val(),
        MaSoThue: $('#trungTam_MaSoThue').val(),
        SoDienThoai: $('#trungTam_SoDienThoai').val(),
        DienTich: $('#trungTam_DienTich').val(),
        NganHang: $('#trungTam_NganHang').val(),
        SoTaiKhoan: $('#trungTam_SoTaiKhoan').val(),
    };
    return item;
}

function isValidTrungTam(item) {
    //Check Valid
    if (CheckIsNull(item.TenTrungTam)) {
        displayMessages(2, "Vui lòng nhập (Tên trung tâm)");
        return false;
    }
    else if (CheckIsNull(item.DiaChi)) {
        displayMessages(2, "Vui lòng nhập (Địa chỉ)");
        return false;
    }
    else if (CheckIsNull(item.Email)) {
        displayMessages(2, "Vui lòng nhập (Email)");
        return false;
    }
    else if (CheckIsNull(item.SoDienThoai)) {
        displayMessages(2, "Vui lòng nhập (Số điện thoại)");
        return false;
    }
    else if (CheckIsNull(item.NganHang)) {
        item.NganHang = null;
    }
    else {
        return true;
    }
}

async function CreateTrungTam() {
    let item = GetTrungTamById();
    //Check Valid
    if (isValidTrungTam(item)){
        item.MaTrungTam = null;
        let status = await TrungTam_Create(item);
        return status;
    }
}

async function UpdateTrungTam() {
    let item = GetTrungTamById();
    //Check Valid
    if (isValidTrungTam(item)&& CheckIsNull(item.MaTrungTam)!=true){
        let status = await TrungTam_Update(item);
        return status;
    }
}

$(document).ready(async function () {
    await CapNhatToken();
   // ============================================== TABLE ===============================================
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
    // Loading Data Table
    $('#myTable').DataTable({
        serverSide: true,
        scrollY: 400,
        searching: false,
        lengthChange: true,
        ordering: false,
        ajax: {
            type: "POST",
            url: "/TrungTam/LoadingDataTableView",
            dataType: "json",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            data: { item: trungTam },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
        },
        columns: [
            {
                data: 'maTrungTam',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
            }
            },
            { data: "tenTrungTam" },
            {
                data: 'email',
                render: function (data, type, row) {
                    return '<a href="mailto:' + data + '" target="_blank" rel="noopener noreferrer" >' + data + '</a>';
                }
            },
            { data: "soDienThoai" },
            { data: "dienTich" },
            { data: "diaChi" },
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
            const rowId = table.row(this).data().maTrungTam;
            let data = await TrungTam_GetById(rowId);
            $('#trungTam_MaTrungTam').val(data.maTrungTam);
            $('#trungTam_TenTrungTam').val(data.tenTrungTam);
            $('#trungTam_Email').val(data.email);
            $('#trungTam_SoDienThoai').val(data.soDienThoai);
            $('#trungTam_DienTich').val(data.dienTich);
            $('#trungTam_MaSoThue').val(data.maSoThue);
            $('#trungTam_NganHang').val(data.nganHang);
            $('#trungTam_SoTaiKhoan').val(data.soTaiKhoan);
            $('#trungTam_DiaChi').val(data.diaChi);
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
    $('#btnCreateTrungTam').click(async function () {
        //If Status Create = True => Update Row Table
        if (await CreateTrungTam() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView = await TrungTam_GetByIdTable($('#trungTam_MaTrungTam').val());
            itemView.maTrungTam = '<input data-checkbox-id="' + itemView.maTrungTam + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateTrungTam').click(async function () {
        //If Status Create = True => Update Row Table
        if (await UpdateTrungTam() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView = await TrungTam_GetByIdTable($('#trungTam_MaTrungTam').val());
            itemView.maTrungTam = '<input data-checkbox-id="' + itemView.maTrungTam + '" type="checkbox"/>';
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

    $('#btnDeleteTrungTam').click(function () {
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
            let statusDelete = await TrungTam_Delete(selectedIds, "Nhân viên Test");
            if (statusDelete == true) {
                displayMessages(1, "Xóa thành công");
                $("#DeleteModal").modal("hide");
                // Lặp qua từng hàng
                table.rows().every(function () {
                    var rowData = this.data();
                    // Kiểm tra xem rowData có tồn tại không trước khi truy cập thuộc tính
                    if (rowData && rowData.maTrungTam) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maTrungTam + '"]');
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

    $('#btnResetTrungTam').click( function () {
        $('#trungTam_MaTrungTam').val(null);
        $('#trungTam_TenTrungTam').val(null);
        $('#trungTam_Email').val(null);
        $('#trungTam_SoDienThoai').val(null);
        $('#trungTam_DienTich').val(null);
        $('#trungTam_MaSoThue').val(null);
        $('#trungTam_NganHang').val("Tất cả");
        $('#trungTam_SoTaiKhoan').val(null);
        $('#trungTam_DiaChi').val(null); 
    });

    $('#btnSearchTrungTam').click(async function () {
        await CapNhatToken();
        trungTam.MaTrungTam = $('#trungTam_MaTrungTam').val() || null;
        trungTam.TenTrungTam = $('#trungTam_TenTrungTam').val() || null;
        trungTam.DiaChi = $('#trungTam_DiaChi').val() || null;
        trungTam.Email = $('#trungTam_Email').val() || null;
        trungTam.MaSoThue = $('#trungTam_MaSoThue').val() || null;
        trungTam.SoDienThoai = $('#trungTam_SoDienThoai').val() || null;
        trungTam.DienTich = $('#trungTam_DienTich').val() || null;
        trungTam.NganHang = $('#trungTam_NganHang').val() || null;
        trungTam.SoTaiKhoan = $('#trungTam_SoTaiKhoan').val() || null;
        if (trungTam.NganHang == "Tất cả") {
            trungTam.NganHang = null;
        }
        table.settings()[0].ajax.data = { item: trungTam };
        table.ajax.reload();
    });
});