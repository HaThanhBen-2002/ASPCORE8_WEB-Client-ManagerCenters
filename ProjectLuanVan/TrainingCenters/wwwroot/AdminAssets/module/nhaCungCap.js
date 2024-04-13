

function isValidNhaCungCap(item) {
    // Kiểm tra tính hợp lệ
    if (CheckIsNull(item.TenNhaCungCap)) {
        displayMessages(2, "Vui lòng nhập (Tên nhà cung cấp)"); return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Trung tâm)"); return false;
    } else if (CheckIsNull(item.Email)) {
        displayMessages(2, "Vui lòng nhập (Email)"); return false;
    } else if (CheckIsNull(item.SoDienThoai)) {
        displayMessages(2, "Vui lòng nhập (Số điện thoại)"); return false;
    } else {
        return true;
    }
}

function GetNhaCungCapById() {
    let item = {
        MaNhaCungCap: $('#nhaCungCap_MaNhaCungCap').val(),
        TenNhaCungCap: $('#nhaCungCap_TenNhaCungCap').val(),
        GioiThieu: $('#nhaCungCap_GioiThieu').val(),
        Email: $('#nhaCungCap_Email').val(),
        SoDienThoai: $('#nhaCungCap_SoDienThoai').val(),
        NganHang: $('#nhaCungCap_NganHang').val(),
        SoTaiKhoan: $('#nhaCungCap_SoTaiKhoan').val(),
        MaSoThue: $('#nhaCungCap_MaSoThue').val(),
        MaTrungTam: $('#nhaCungCap_MaTrungTam').val()
    };
    return item;
}

function CreateNhaCungCap() {
    let item = GetNhaCungCapById();

    // Kiểm tra tính hợp lệ
    if (isValidNhaCungCap(item)){
        let status = false;
        item.MaNhaCungCap = null;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/NhaCungCap/Create",
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
            $('#nhaCungCap_MaTrungTam').empty();
            $('#nhaCungCap_MaTrungTam').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#nhaCungCap_MaTrungTam').append($('<option>', {
                    value: item.maTrungTam,
                    text: item.tenTrungTam
                }));
            });
        }
    });

}

function UpdateNhaCungCap() {

    let item = GetNhaCungCapById();
    // Kiểm tra tính hợp lệ
    if (isValidNhaCungCap(item) && CheckIsNull(item.MaNhaCungCap)!=true){
        let status = false;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/NhaCungCap/Update",
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
    let nhaCungCap = {
        MaNhaCungCap: null,
        TenNhaCungCap: null,
        GioiThieu: null,
        Email: null,
        SoDienThoai: null,
        NganHang: null,
        SoTaiKhoan: null,
        MaSoThue: null,
        MaTrungTam: null
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
            url: "/Admin/NhaCungCap/LoadingDataTableView",
            dataType: "json",
            data: { item: nhaCungCap },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maNhaCungCap',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                }
            },
            { data: "tenNhaCungCap" },
            {
                data: 'email',
                render: function (data, type, row) {
                    return '<a href="mailto:' + data + '" target="_blank" rel="noopener noreferrer" >' + data + '</a>';
                }
            },
            { data: "soDienThoai" },
            { data: "maSoThue" },

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
            const rowId = table.row(this).data().maNhaCungCap;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/NhaCungCap/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#nhaCungCap_MaNhaCungCap').val(data.maNhaCungCap);
                    $('#nhaCungCap_TenNhaCungCap').val(data.tenNhaCungCap);
                    $('#nhaCungCap_GioiThieu').val(data.gioiThieu);
                    $('#nhaCungCap_Email').val(data.email);
                    $('#nhaCungCap_SoDienThoai').val(data.soDienThoai);
                    $('#nhaCungCap_NganHang').val(data.nganHang);
                    $('#nhaCungCap_SoTaiKhoan').val(data.soTaiKhoan);
                    $('#nhaCungCap_MaSoThue').val(data.maSoThue);
                    $('#nhaCungCap_MaTrungTam').val(data.maTrungTam)
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

    CbbTrungTam();
    // ============================================== BUTTON ===============================================
    $('#btnCreateNhaCungCap').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateNhaCungCap() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/NhaCungCap/GetByIdTable",
                async: false,
                data: { id: $('#nhaCungCap_MaNhaCungCap').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maNhaCungCap = '<input data-checkbox-id="' + itemView.maNhaCungCap + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateNhaCungCap').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateNhaCungCap() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/NhaCungCap/GetByIdTable",
                async: false,
                data: { id: $('#nhaCungCap_MaNhaCungCap').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maNhaCungCap = '<input data-checkbox-id="' + itemView.maNhaCungCap + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteNhaCungCap').click(function () {
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
                url: "/Admin/NhaCungCap/Delete",
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
                    if (rowData && rowData.maNhaCungCap) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maNhaCungCap + '"]');
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

    $('#btnResetNhaCungCap').click(function () {
        $('#nhaCungCap_MaNhaCungCap').val(null);
        $('#nhaCungCap_TenNhaCungCap').val(null);
        $('#nhaCungCap_GioiThieu').val(null);
        $('#nhaCungCap_Email').val(null);
        $('#nhaCungCap_SoDienThoai').val(null);
        $('#nhaCungCap_NganHang').val("Tất cả");
        $('#nhaCungCap_SoTaiKhoan').val(null);
        $('#nhaCungCap_MaSoThue').val(null);
        $('#nhaCungCap_MaTrungTam').val(0)

    });

    $('#btnSearchNhaCungCap').click(function () {

        nhaCungCap = GetNhaCungCapById();
        if (nhaCungCap.NganHang == "Tất cả") {
            nhaCungCap.NganHang = null;
        }
        if (nhaCungCap.MaTrungTam == 0) {
            nhaCungCap.MaTrungTam = null;
        }

        table.settings()[0].ajax.data = { item: nhaCungCap };
        table.ajax.reload();
    });
});