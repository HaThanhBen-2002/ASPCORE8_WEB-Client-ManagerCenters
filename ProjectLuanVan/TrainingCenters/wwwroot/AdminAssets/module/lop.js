
function isValidLop(item) {
    if (CheckIsNull(item.TenLop)) {
        displayMessages(2, "Vui lòng nhập (Tên lớp)");
        return false;
    } else if (CheckIsNull(item.MaNhanVien)) {
        displayMessages(2, "Vui lòng chọn (Mã nhân viên)");
        return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Mã trung tâm)");
        return false;
    } else if (CheckIsNull(item.NamHoc)) {
        displayMessages(2, "Vui lòng nhập (Năm học)");
        return false;
    } else if (CheckIsNull(item.HocPhi)) {
        displayMessages(2, "Vui lòng nhập (Học phí)");
        return false;
    } else if (CheckIsNull(item.LichHoc)) {
        displayMessages(2, "Vui lòng nhập (Lịch học)");
        return false;
    } else if (CheckIsNull(item.ThongTin)) {
        displayMessages(2, "Vui lòng nhập (Thông tin)");
        return false;
    } else if (CheckIsNull(item.NgayBatDau)) {
        displayMessages(2, "Vui lòng chọn (Ngày bắt đầu)");
        return false;
    } else if (CheckIsNull(item.NgayKetThuc)) {
        displayMessages(2, "Vui lòng chọn (Ngày kết thúc)");
        return false;
    } else {
        return true;
    }
}

function GetLopData() {
    return {
        MaLop: $('#lop_MaLop').val(),
        TenLop: $('#lop_TenLop').val(),
        MaNhanVien: $('#lop_MaNhanVien').val(),
        MaTrungTam: $('#lop_MaTrungTam').val(),
        NamHoc: $('#lop_NamHoc').val(),
        HocPhi: $('#lop_HocPhi').val(),
        LichHoc: $('#lop_LichHoc').val(),
        ThongTin: $('#lop_ThongTin').val(),
        NgayBatDau: $('#lop_NgayBatDau').val(),
        NgayKetThuc: $('#lop_NgayKetThuc').val(),
    };
}

function CreateLop() {
    let item = GetLopData();
    // Kiểm tra tính hợp lệ
    if (isValidLop(item)) {
        let status = false;
        item.MaLop = null;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/Lop/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateLop() {
    let item = GetLopData();
    // Kiểm tra tính hợp lệ
    if (isValidLop(item) && CheckIsNull(item.MaLop)!=true) {
        let status = false;
        // Gửi dữ liệu thông qua AJAX để cập nhật vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/Lop/Update",
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
            $('#lop_MaTrungTam').empty();
            $('#lop_MaTrungTam').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#lop_MaTrungTam').append($('<option>', {
                    value: item.maTrungTam,
                    text: item.tenTrungTam
                }));
            });
        }
    });

}

function CbbNhanVienByMaTrungTam() {
    let trungTam = $('#lop_MaTrungTam').val();
    if (CheckIsNull(trungTam)!=true) {

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
            LoaiNhanVien: "Giáo viên",
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
                $('#lop_MaNhanVien').empty();
                $('#lop_MaNhanVien').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
                $.each(data.$values, function (index, item) {
                    $('#lop_MaNhanVien').append($('<option>', {
                        value: item.maNhanVien,
                        text: item.tenNhanVien
                    }));
                });
            }
        });
    }
    else {
        $('#lop_MaNhanVien').empty();
        $('#lop_MaNhanVien').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
    }
}

$(document).ready(function () {
    // ============================================== TABLE ===============================================
    var lop = {
        MaLop: null,
        TenLop: null,
        MaNhanVien: null,
        MaTrungTam: null,
        NamHoc: null,
        HocPhi: null,
        LichHoc: null,
        ThongTin: null,
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
            url: "/Admin/Lop/LoadingDataTableView",
            dataType: "json",
            data: { item: lop },
            dataSrc: 'data'
        },
        columns: [
            {
                data: 'maLop',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                }
            },
            { data: "tenLop" },
            { data: "tenGiaoVien" },
            {
                data: 'hocPhi',
                render: function (data, type, row) {
                    return formatToVND(data);
                }
            },
            { data: "namHoc" },

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
            const rowId = table.row(this).data().maLop;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/Lop/GetById",
                //contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#lop_MaLop').val(data.maLop);
                    $('#lop_TenLop').val(data.tenLop);
                    $('#lop_NamHoc').val(data.namHoc);
                    $('#lop_HocPhi').val(data.hocPhi);
                    $('#lop_LichHoc').val(data.lichHoc);
                    $('#lop_ThongTin').val(data.thongTin);
                    $('#lop_NgayBatDau').val(data.ngayBatDau);
                    $('#lop_NgayKetThuc').val(data.ngayKetThuc);
                    $('#lop_MaTrungTam').val(data.maTrungTam);
                    CbbNhanVienByMaTrungTam();
                    $('#lop_MaNhanVien').val(data.maNhanVien);
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
    $('#lop_MaTrungTam').change(function () {
        CbbNhanVienByMaTrungTam();
    });
    // ============================================== BUTTON ===============================================
    $('#btnCreateLop').click(function () {
        //If Status Create = True => Update Row Table
        if (CreateLop() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/Lop/GetByIdTable",
                async: false,
                data: { id: $('#lop_MaLop').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maLop = '<input data-checkbox-id="' + itemView.maLop + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateLop').click(function () {
        //If Status Create = True => Update Row Table
        if (UpdateLop() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView;
            $.ajax({
                type: "POST",
                url: "/Admin/Lop/GetByIdTable",
                async: false,
                data: { id: $('#lop_MaLop').val() },
                success: function (data) {
                    itemView = data;
                }
            });
            itemView.maLop = '<input data-checkbox-id="' + itemView.maLop + '" type="checkbox"/>';
            if (itemView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(2, "Cập nhật thông tin thất bại")
        }
    });

    $('#btnDeleteLop').click(function () {
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
                url: "/Admin/Lop/Delete",
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
                    if (rowData && rowData.maLop) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maLop + '"]');
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

    $('#btnResetLop').click(function () {
        $('#lop_MaLop').val(null);
        $('#lop_TenLop').val(null);
        $('#lop_NamHoc').val(null);
        $('#lop_HocPhi').val(null);
        $('#lop_LichHoc').val(null);
        $('#lop_ThongTin').val(null);
        $('#lop_NgayBatDau').val(null);
        $('#lop_NgayKetThuc').val(null);
        $('#lop_MaTrungTam').val(0);
        CbbNhanVienByMaTrungTam();
        $('#lop_MaNhanVien').val(0);
    });

    $('#btnSearchLop').click(function () {

        lop = GetLopById();
        if (lop.MaNhanVien == 0) {
            lop.MaNhanVien = null;
        }
        if (lop.MaTrungTam == 0) {
            lop.MaTrungTam = null;
        }

        table.settings()[0].ajax.data = { item: lop };
        table.ajax.reload();
    });
});