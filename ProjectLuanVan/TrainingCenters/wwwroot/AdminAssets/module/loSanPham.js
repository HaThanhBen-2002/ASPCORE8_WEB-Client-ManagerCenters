

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

async function CbbTrungTam() {
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

    let trungTams = await TrungTam_SearchName(trungTam);
    $('#loSanPham_MaTrungTam').empty();
    $('#loSanPham_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#loSanPham_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
}

async function CreateLoSanPham() {
    let item = GetLoSanPhamById();
    // Kiểm tra tính hợp lệ
    if (isValidLoSanPham(item)) {
        item.MaLoSanPham = null;
        let status = await LoSanPham_Create(item);
        return status;
    }
}

async function UpdateLoSanPham() {

    let item = GetLoSanPhamById();
    // Kiểm tra tính hợp lệ
    if (isValidLoSanPham(item) && CheckIsNull(item.MaLoSanPham) != true) {
        let status = await LoSanPham_Update(item);
        return status;
    }
}

async function CbbNhanVienByMaTrungTam() {
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
        let nhanViens = await NhanVien_SearchName(nhanVien);
        $('#loSanPham_MaNhanVien').empty();
        $('#loSanPham_MaNhanVien').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
        // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
        $.each(nhanViens, function (index, item) {
            $('#loSanPham_MaNhanVien').append($('<option>', {
                value: item.maNhanVien,
                text: item.tenNhanVien
            }));
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

async function CbbSanPhamByMaTrungTamByLoaiSanPham() {
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
        let sanPhams = await SanPham_SearchName(sanPham);
        $('#loSanPham_MaSanPham').empty();
        $('#loSanPham_MaSanPham').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
        $.each(sanPhams, function (index, item) {
            $('#loSanPham_MaSanPham').append($('<option>', {
                value: item.maSanPham,
                text: item.tenSanPham
            }));
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



$(document).ready(async function () {
    await CapNhatToken();
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
            url: "/LoSanPham/LoadingDataTableView",
            dataType: "json",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            data: { item: loSanPham },
            dataSrc: 'data',
            beforeSend: function(xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
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
            const rowId = table.row(this).data().maLoSanPham;
            let data = await LoSanPham_GetById(rowId);
            $('#sanPham_LoaiSanPham').val("Tất cả");
            $('#loSanPham_MaLoSanPham').val(data.maLoSanPham);
            $('#loSanPham_TenLoSanPham').val(data.tenLoSanPham);
            $('#loSanPham_SoLuong').val(data.soLuong);
            $('#loSanPham_DonVi').val(data.donVi);
            $('#loSanPham_NgayNhap').val(data.ngayNhap);
            $('#loSanPham_NgayHetHan').val(data.ngayHetHan);
            $('#loSanPham_GhiChu').val(data.ghiChu);
            $('#loSanPham_MaTrungTam').val(data.maTrungTam);
            await CbbNhanVienByMaTrungTam();
            await CbbSanPhamByMaTrungTamByLoaiSanPham();
            $('#loSanPham_MaSanPham').val(data.maSanPham);
            $('#loSanPham_TrangThai').val(data.trangThai);
            $('#loSanPham_MaNhanVien').val(data.maNhanVien);

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
    $('#loSanPham_MaTrungTam').change(async function () {
        CbbNhanVienByMaTrungTam();
        CbbSanPhamByMaTrungTamByLoaiSanPham();
    });
    $('#sanPham_LoaiSanPham').change(async function () {
        CbbSanPhamByMaTrungTamByLoaiSanPham();
    });
    // ============================================== BUTTON ===============================================
    $('#btnCreateLoSanPham').click(async function () {
        //If Status Create = True => Update Row Table
        if (await CreateLoSanPham() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView = await LoSanPham_GetByIdTable($('#loSanPham_MaLoSanPham').val());
            itemView.maLoSanPham = '<input data-checkbox-id="' + itemView.maLoSanPham + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(3, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateLoSanPham').click(async function () {
        //If Status Create = True => Update Row Table
        if (await UpdateLoSanPham() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView = await LoSanPham_GetByIdTable($('#loSanPham_MaLoSanPham').val());
            itemView.maLoSanPham = '<input data-checkbox-id="' + itemView.maLoSanPham + '" type="checkbox"/>';
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
            displayMessages(3, "Cập nhật thông tin thất bại")
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

    $('#btnDelete').click(async function () {
        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });

        if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
            let statusDelete = await LoSanPham_Delete(selectedIds, "Nhân viên Test");
            if (statusDelete) {
                displayMessages(1, "Xóa thành công");
                $("#DeleteModal").modal("hide");
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
            else {
                displayMessages(3, "Xóa thất bại");
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

    $('#btnSearchLoSanPham').click(async function () {

        await CapNhatToken();
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