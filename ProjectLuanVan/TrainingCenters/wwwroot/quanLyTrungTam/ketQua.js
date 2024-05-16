let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));
let Crole = JSON.parse(Cookies.get('role'));
function isValidKetQua(item) {
    if (CheckIsNull(item.TenKetQua)) {
        displayMessages(2, "Vui lòng nhập (Tên kết quả)");
        return false;
    } else if (CheckIsNull(item.MaHocSinh)) {
        displayMessages(2, "Vui lòng chọn (Mã học sinh)");
        return false;
    } else if (CheckIsNull(item.MaMonHoc)) {
        displayMessages(2, "Vui lòng chọn (Mã môn học)");
        return false;
    } else if (CheckIsNull(item.Diem)) {
        displayMessages(2, "Vui lòng nhập (Điểm)");
        return false;
    } else if (CheckIsNull(item.XepLoai)) {
        displayMessages(2, "Vui lòng nhập (Xếp loại)");
        return false;
    } else if (CheckIsNull(item.NgayKiemTra)) {
        displayMessages(2, "Vui lòng chọn (Ngày kiểm tra)");
        return false;
    } else if (CheckIsNull(item.TrangThai)) {
        displayMessages(2, "Vui lòng nhập (Trạng thái)");
        return false;
    } else if (CheckIsNull(item.MaNhanVien)) {
        displayMessages(2, "Vui lòng chọn (Mã nhân viên)");
        return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Mã trung tâm)");
        return false;
    }
    return true;
}

function GetKetQuaById() {
    return {
        MaKetQua: $('#ketQua_MaKetQua').val(),
        TenKetQua: $('#ketQua_TenKetQua').val(),
        MaHocSinh: $('#ketQua_MaHocSinh').val(),
        MaMonHoc: $('#ketQua_MaMonHoc').val(),
        Diem: $('#ketQua_Diem').val(),
        XepLoai: $('#ketQua_XepLoai').val(),
        NgayKiemTra: $('#ketQua_NgayKiemTra').val(),
        TrangThai: $('#ketQua_TrangThai').val(),
        MaNhanVien: $('#ketQua_MaNhanVien').val(),
        MaTrungTam: CtrungTam,
    };
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
    $('#ketQua_MaTrungTam').empty();
    $('#ketQua_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#ketQua_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
    $('#ketQua_MaTrungTam').val(CtrungTam);
}

async function CbbMonHoc() {
    let monHoc = {
        MaMonHoc: null,
        TenMonHoc: null,
        Gia: null,
        ThongTin: null
    };
    let monHocs = await MonHoc_SearchName(monHoc);
    $('#ketQua_MaMonHoc').empty();
    $('#ketQua_MaMonHoc').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(monHocs, function (index, item) {
        $('#ketQua_MaMonHoc').append($('<option>', {
            value: item.maMonHoc,
            text: item.tenMonHoc
        }));
    });

}

async function CbbNhanVienByMaTrungTam() {
    let trungTam = CtrungTam;
    if (CheckIsNull(trungTam) != true) {

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
        let nhanViens = await NhanVien_SearchName(nhanVien);
        $('#ketQua_MaNhanVien').empty();
        $('#ketQua_MaNhanVien').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
        $.each(nhanViens, function (index, item) {
            $('#ketQua_MaNhanVien').append($('<option>', {
                value: item.maNhanVien,
                text: item.tenNhanVien
            }));
        });
    }
    else {
        $('#ketQua_MaNhanVien').empty();
        $('#ketQua_MaNhanVien').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
    }
}

async function SearchNameHocSinh() {
    $('#ketQua_TenHocSinh').val(null);
    let trungTam = CtrungTam;
    let maHocSinh = $('#ketQua_MaHocSinh').val();
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
        let hocSinhs = await HocSinh_SearchName(hocSinh);
        $.each(hocSinhs, function (index, item) {
            $('#ketQua_TenHocSinh').val(item.tenHocSinh);
        });
    }
    if (CheckIsNull(trungTam)) {
        displayMessages(2, "Vui lòng chọn (Trung tâm)");
    }
}

async function CreateKetQua() {
    let item = GetKetQuaById();
    item.MaTrungTam = CtrungTam;
    // Kiểm tra tính hợp lệ
    if (isValidKetQua(item)) {
        item.MaKetQua = null;
        let status = await KetQua_Create(item);
        return status;
    }
}

async function UpdateKetQua() {
    let item = GetKetQuaById();
    item.MaTrungTam = CtrungTam;
    // Kiểm tra tính hợp lệ
    if (isValidKetQua(item) && CheckIsNull(item.MaKetQua) != true) {
        let status = await KetQua_Update(item);
        return status;
    }
}

$(document).ready(async function () {
    await CapNhatToken();
   // ============================================== TABLE ===============================================
    let ketQua = {
        MaKetQua: null,
        TenKetQua: null,
        MaHocSinh: null,
        MaMonHoc: null,
        Diem: null,
        XepLoai: null,
        NgayKiemTra: null,
        TrangThai: null,
        MaNhanVien: null,
        MaTrungTam: CtrungTam
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
            url: "/KetQua/LoadingDataTableView",
            dataType: "json",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            data: { item: ketQua },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
        },
        columns: [
            {
                data: 'maKetQua',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
            }
            },
            { data: "tenKetQua" },
            { data: "tenHocSinh" },
            { data: "tenMonHoc" },
            { data: "trangThai" }
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
            const rowId = table.row(this).data().maKetQua;
            let data = await KetQua_GetById(rowId);
            $('#ketQua_MaKetQua').val(data.maKetQua);
            $('#ketQua_TenKetQua').val(data.tenKetQua);
            $('#ketQua_MaHocSinh').val(data.maHocSinh);
            $('#ketQua_Diem').val(data.diem);
            $('#ketQua_XepLoai').val(data.xepLoai);
            $('#ketQua_NgayKiemTra').val(data.ngayKiemTra);
            $('#ketQua_TrangThai').val(data.trangThai);
            $('#ketQua_MaMonHoc').val(data.maMonHoc);
            await SearchNameHocSinh();
            await CbbNhanVienByMaTrungTam();
            $('#ketQua_MaNhanVien').val(data.maNhanVien);

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
    CbbMonHoc();
    CbbNhanVienByMaTrungTam();
    // ============================================== TEXT CHANGE ===============================================
    $('#ketQua_MaHocSinh').on('input', function () {
        SearchNameHocSinh();
    });
    // ============================================== BUTTON ===============================================
    $('#btnCreateKetQua').click(async function () {
        //If Status Create = True => Update Row Table
        if (await CreateKetQua() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView = await KetQua_GetByIdTable($('#ketQua_MaKetQua').val());
            itemView.maKetQua = '<input data-checkbox-id="' + itemView.maKetQua + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(3, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateKetQua').click(async function () {
        //If Status Create = True => Update Row Table
        if (await UpdateKetQua() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView = await KetQua_GetByIdTable($('#ketQua_MaKetQua').val());
            itemView.maKetQua = '<input data-checkbox-id="' + itemView.maKetQua + '" type="checkbox"/>';
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

    $('#btnDeleteKetQua').click(function () {
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
            let statusDelete = await KetQua_Delete(selectedIds, "Nhân viên Test");
            if (statusDelete) {
                displayMessages(1, "Xóa thành công");
                $("#DeleteModal").modal("hide");
                table.rows().every(function () {
                    var rowData = this.data();
                    // Kiểm tra xem rowData có tồn tại không trước khi truy cập thuộc tính
                    if (rowData && rowData.maKetQua) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maKetQua + '"]');
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

    $('#btnResetKetQua').click(function () {

        $('#ketQua_MaKetQua').val(null);
        $('#ketQua_TenKetQua').val(null);
        $('#ketQua_MaHocSinh').val(null);
        $('#ketQua_TenHocSinh').val(null);
        $('#ketQua_Diem').val(null);
        $('#ketQua_XepLoai').val(null);
        $('#ketQua_NgayKiemTra').val(null);
        $('#ketQua_TrangThai').val("Tất cả");
        $('#ketQua_MaMonHoc').val(0);
        $('#ketQua_MaNhanVien').val(0);
    });

    $('#btnSearchKetQua').click(async function () {
        await CapNhatToken();
        ketQua = GetKetQuaById();

        if (ketQua.TrangThai== "Tất cả") {
            ketQua.TrangThai = null;
        }
        if (ketQua.MaNhanVien == 0) {
            ketQua.MaNhanVien = null;
        }
        if (ketQua.MaTrungTam == 0) {
            ketQua.MaTrungTam = null;
        }
        if (ketQua.MaMonHoc == 0) {
            ketQua.MaMonHoc = null;
        }
        table.settings()[0].ajax.data = { item: ketQua };
        table.ajax.reload();
    });
});