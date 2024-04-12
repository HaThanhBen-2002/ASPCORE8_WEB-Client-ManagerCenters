function isValidSuDungDichVu(item) {
    if (CheckIsNull(item.TenSuDungDichVu)) {
        displayMessages(2, "Vui lòng nhập (Tên sử dụng dịch vụ)");
        return false;
    } else if (CheckIsNull(item.MaDichVu)) {
        displayMessages(2, "Vui lòng nhập (Mã dịch vụ)");
        return false;
    } else if (CheckIsNull(item.MaHocSinh)) {
        displayMessages(2, "Vui lòng nhập (Mã học sinh)");
        return false;
    } else if (CheckIsNull($('#suDungDichVu_TenHocSinh').val())) {
        displayMessages(2, "Học sinh không hợp lệ");
        return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Mã trung tâm)");
        return false;
    } else if (CheckIsNull(item.TrangThai)) {
        displayMessages(2, "Vui lòng nhập (Trạng thái)");
        return false;
    } else if (CheckIsNull(item.NgayBatDau)) {
        displayMessages(2, "Vui lòng nhập (Ngày bắt đầu)");
        return false;
    } else if (CheckIsNull(item.NgayKetThuc)) {
        displayMessages(2, "Vui lòng nhập (Ngày kết thúc)");
        return false;
    }
    return true;
}

function GetSuDungDichVuData() {
    return {
        MaSuDungDichVu: $('#suDungDichVu_MaSuDungDichVu').val(),
        TenSuDungDichVu: $('#suDungDichVu_TenSuDungDichVu').val(),
        MaDichVu: $('#suDungDichVu_MaDichVu').val(),
        MaHocSinh: $('#suDungDichVu_MaHocSinh').val(),
        MaTrungTam: $('#suDungDichVu_MaTrungTam').val(),
        TrangThai: $('#suDungDichVu_TrangThai').val(),
        NgayBatDau: $('#suDungDichVu_NgayBatDau').val(),
        NgayKetThuc: $('#suDungDichVu_NgayKetThuc').val(),
    };
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
            $('#suDungDichVu_MaTrungTam').empty();
            $('#suDungDichVu_MaTrungTam').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#suDungDichVu_MaTrungTam').append($('<option>', {
                    value: item.maTrungTam,
                    text: item.tenTrungTam
                }));
            });
        }
    });
}

function CbbDichVu() {
    var dichVu = {
        MaDichVu: null,
        TenDichVu: null,
        ThongTin: null,
        Gia: null,
    };
    $.ajax({
        type: "POST",
        url: "/Admin/DichVu/SearchName",
        data: { item: dichVu },
        success: function (data) {
            $('#suDungDichVu_MaDichVu').empty();
            $('#suDungDichVu_MaDichVu').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#suDungDichVu_MaDichVu').append($('<option>', {
                    value: item.maDichVu,
                    text: item.tenDichVu
                }));
            });
        }
    });
}

function SearchNameHocSinh() {
    $('#suDungDichVu_TenHocSinh').val(null);
    let trungTam = $('#suDungDichVu_MaTrungTam').val();
    let maHocSinh = $('#suDungDichVu_MaHocSinh').val();
    if (!CheckIsNull(trungTam) && !CheckIsNull(maHocSinh)) {
        let hocSinh = {
            MaHocSinh: maHocSinh,
            TenHocSinh: null,
            NgaySinh: null,
            GioiTinh: null,
            MaLop: null,
            MaTrungTam: trungTam,
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
        $.ajax({
            type: "POST",
            url: "/Admin/HocSinh/SearchName",
            data: { item: hocSinh },
            success: function (data) {
                $.each(data.$values, function (index, item) {
                    $('#suDungDichVu_TenHocSinh').val(item.tenHocSinh);
                });
            }
        });

    }
    if (CheckIsNull(trungTam)) {
        displayMessages(2, "Vui lòng chọn (Trung tâm)");
    }
}

function CreateSuDungDichVu() {
    let item = GetSuDungDichVuData();
    // Kiểm tra tính hợp lệ
    if (isValidSuDungDichVu(item)) {
        item.MaSuDungDichVu = null;
        let status = false;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/SuDungDichVu/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateSuDungDichVu() {
    let item = GetSuDungDichVuData();
    // Kiểm tra tính hợp lệ
    if (isValidSuDungDichVu(item) && CheckIsNull(item.MaSuDungDichVu)!=true){
        let status = false;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/SuDungDichVu/Update",
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
    var suDungDichVu = {
        MaSuDungDichVu: null,
        TenSuDungDichVu: null,
        MaDichVu: null,
        MaHocSinh: null,
        MaTrungTam: null,
        TrangThai: null,
        NgayBatDau: null,
        NgayKetThuc: null
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
            url: "/Admin/SuDungDichVu/LoadingDataTableView",
            dataType: "json",
            data: { item: suDungDichVu },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maSuDungDichVu',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
            }
            },
            { data: "tenSuDungDichVu" },
            { data: "tenDichVu" },
            { data: "trangThai" },
            { data: "ngayKetThuc" },
            { data: "tenHocSinh" },
           
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
            const rowId = table.row(this).data().maSuDungDichVu;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/SuDungDichVu/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#suDungDichVu_MaTrungTam').val(data.maTrungTam);
                    $('#suDungDichVu_MaSuDungDichVu').val(data.maSuDungDichVu);
                    $('#suDungDichVu_TenSuDungDichVu').val(data.tenSuDungDichVu);
                    $('#suDungDichVu_MaHocSinh').val(data.maHocSinh);
                    $('#suDungDichVu_NgayBatDau').val(data.ngayBatDau);
                    $('#suDungDichVu_NgayKetThuc').val(data.ngayKetThuc);
                    $('#suDungDichVu_MaDichVu').val(data.maDichVu);
                    $('#suDungDichVu_TrangThai').val(data.trangThai);
                    SearchNameHocSinh();
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
    CbbDichVu();
    // ============================================== TEXT CHANGE ===============================================
    $('#suDungDichVu_MaHocSinh').on('input', function () {
        SearchNameHocSinh();
     });
    // ============================================== BUTTON ===============================================
    $('#btnCreateSuDungDichVu').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateSuDungDichVu() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/SuDungDichVu/GetByIdTable",
                async: false,
                data: { id: $('#suDungDichVu_MaSuDungDichVu').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maSuDungDichVu = '<input data-checkbox-id="' + itemView.maSuDungDichVu + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateSuDungDichVu').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateSuDungDichVu() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/SuDungDichVu/GetByIdTable",
                async: false,
                data: { id: $('#suDungDichVu_MaSuDungDichVu').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maSuDungDichVu = '<input data-checkbox-id="' + itemView.maSuDungDichVu + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteSuDungDichVu').click(function () {
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
                url: "/Admin/SuDungDichVu/Delete",
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
                    if (rowData && rowData.maSuDungDichVu) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maSuDungDichVu + '"]');
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

    $('#btnResetSuDungDichVu').click(function () {

        $('#suDungDichVu_MaSuDungDichVu').val(null);
        $('#suDungDichVu_TenSuDungDichVu').val(null);
        $('#suDungDichVu_MaHocSinh').val(null);
        $('#suDungDichVu_TenHocSinh').val(null);
        $('#suDungDichVu_NgayBatDau').val(null);
        $('#suDungDichVu_NgayKetThuc').val(null);
        $('#suDungDichVu_MaDichVu').val(0);
        $('#suDungDichVu_MaTrungTam').val(0);
        $('#suDungDichVu_TrangThai').val("Tất cả");
    });

    $('#btnSearchSuDungDichVu').click(function () {
        suDungDichVu = GetSuDungDichVuData();

        if (suDungDichVu.TrangThai == "Tất cả") {
            suDungDichVu.TrangThai = null;
        }
        if (suDungDichVu.MaDichVu == 0) {
            suDungDichVu.MaDichVu = null;
        }
        if (suDungDichVu.MaTrungTam == 0) {
            suDungDichVu.MaTrungTam = null;
        }
        table.settings()[0].ajax.data = { item: suDungDichVu };
        table.ajax.reload();
    });
});