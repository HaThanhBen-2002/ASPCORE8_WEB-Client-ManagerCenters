let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));
let Crole = JSON.parse(Cookies.get('role'));
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
        MaTrungTam: CtrungTam,
        TrangThai: $('#suDungDichVu_TrangThai').val(),
        NgayBatDau: $('#suDungDichVu_NgayBatDau').val(),
        NgayKetThuc: $('#suDungDichVu_NgayKetThuc').val(),
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
    $('#suDungDichVu_MaTrungTam').empty();
    $('#suDungDichVu_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#suDungDichVu_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
    $('#suDungDichVu_MaTrungTam').val(CtrungTam);
}

async function CbbDichVu() {
    var dichVu = {
        MaDichVu: null,
        TenDichVu: null,
        ThongTin: null,
        Gia: null,
    };
    let dichVus = await DichVu_SearchName(dichVu);
    $('#suDungDichVu_MaDichVu').empty();
    $('#suDungDichVu_MaDichVu').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
    $.each(dichVus, function (index, item) {
        $('#suDungDichVu_MaDichVu').append($('<option>', {
            value: item.maDichVu,
            text: item.tenDichVu
        }));
    });
}

let ACN_tenHocSinh = "";
let ACN_tenDichVuSuDung = "";
let ACN_tenNgayBatDau = "";
let ACN_tenNgayKetThuc = "";
function AutoCreateName_SuDungDichVu() {
    $('#suDungDichVu_TenSuDungDichVu').val(ACN_tenHocSinh + "-" + ACN_tenDichVuSuDung + "-" + ACN_tenNgayBatDau + " đến " + ACN_tenNgayKetThuc);
}
function SoNgaySuDung(date1) {
    var ketQua = '';
    let homNay = GetToDay();
    let soNgay = getDaysDifference(homNay, date1);
    if (soNgay >= 0) {
        ketQua = '<label class="text-success" >Còn ' + soNgay + ' ngày</label>';
    }
    else {
        ketQua = '<label class="text-danger" >Đã hết hạng ' + soNgay + ' ngày</label>';

    }
    return ketQua;
}
async function SearchNameHocSinh() {
    $('#suDungDichVu_TenHocSinh').val(null);
    let trungTam = CtrungTam;
    let maHocSinh = $('#suDungDichVu_MaHocSinh').val();
    if (!CheckIsNull(maHocSinh)) {
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
            $('#suDungDichVu_TenHocSinh').val(item.tenHocSinh);
            ACN_tenHocSinh = item.tenHocSinh;
            AutoCreateName_SuDungDichVu();
        });

    }
}

async function CreateSuDungDichVu() {
    let item = GetSuDungDichVuData();
    // Kiểm tra tính hợp lệ
    if (isValidSuDungDichVu(item)) {
        item.MaTrungTam = CtrungTam;
        item.MaSuDungDichVu = null;
        let status = await SuDungDichVu_Create(item);
        return status;
    }
}

async function UpdateSuDungDichVu() {
    let item = GetSuDungDichVuData();
    item.MaTrungTam = CtrungTam;
    // Kiểm tra tính hợp lệ
    if (isValidSuDungDichVu(item) && CheckIsNull(item.MaSuDungDichVu)!=true){
        let status = await SuDungDichVu_Update(item);
        return status;
    }
}

$(document).ready(async function () {
    await CapNhatToken();
    $('#suDungDichVu_NgayBatDau').val(GetToDay());
    ACN_tenNgayBatDau = GetToDay();
    ACN_tenNgayKetThuc = addOneMonth(ACN_tenNgayBatDau);
    $('#suDungDichVu_NgayKetThuc').val(ACN_tenNgayKetThuc);
    AutoCreateName_SuDungDichVu();
   // ============================================== TABLE ===============================================
    var suDungDichVu = {
        MaSuDungDichVu: null,
        TenSuDungDichVu: null,
        MaDichVu: null,
        MaHocSinh: null,
        MaTrungTam: CtrungTam,
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
            url: "/SuDungDichVu/LoadingDataTableView",
            dataType: "json",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            data: { item: suDungDichVu },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
        },
        columns: [
            {
                data: 'maSuDungDichVu',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                },
            },
            { data: "tenSuDungDichVu" },
            { data: "tenDichVu" },
            { data: "trangThai" },
            { data: "tenHocSinh" },
            { data: "ngayKetThuc" },
            {
                data: 'ngayKetThuc',
                title: 'Số Ngày Sử Dụng',
                render: function (data) {
                    return SoNgaySuDung(data);
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
    $('#myTable tbody').on('click', 'tr', async function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected')
        } else {
            table.$('tr.selected').removeClass('selected')
            $(this).addClass('selected')
            // xử lý ở đây
            const rowId = table.row(this).data().maSuDungDichVu;
            let data = await SuDungDichVu_GetById(rowId);
            $('#suDungDichVu_MaSuDungDichVu').val(data.maSuDungDichVu);
            $('#suDungDichVu_TenSuDungDichVu').val(data.tenSuDungDichVu);
            $('#suDungDichVu_MaHocSinh').val(data.maHocSinh);
            $('#suDungDichVu_NgayBatDau').val(data.ngayBatDau);
            $('#suDungDichVu_NgayKetThuc').val(data.ngayKetThuc);
            $('#suDungDichVu_MaDichVu').val(data.maDichVu);
            $('#suDungDichVu_TrangThai').val(data.trangThai);
            await SearchNameHocSinh();
            ACN_tenDichVuSuDung = $('#suDungDichVu_MaDichVu option:selected').text();
            AutoCreateName_SuDungDichVu();
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
    $('#suDungDichVu_MaDichVu').change(function () {
        ACN_tenDichVuSuDung = $('#suDungDichVu_MaDichVu option:selected').text();
        AutoCreateName_SuDungDichVu();
    });
    // ============================================== TEXT CHANGE ===============================================
    $('#suDungDichVu_MaHocSinh').on('input', function () {
        SearchNameHocSinh();
    });
    $('#suDungDichVu_NgayBatDau').on('input', function () {
        ACN_tenNgayBatDau = $('#suDungDichVu_NgayBatDau').val();
        ACN_tenNgayKetThuc = addOneMonth(ACN_tenNgayBatDau);
        $('#suDungDichVu_NgayKetThuc').val(ACN_tenNgayKetThuc);
        AutoCreateName_SuDungDichVu();
    });
    $('#suDungDichVu_NgayKetThuc').on('input', function () {
        ACN_tenNgayKeThuc = $('#suDungDichVu_NgayKetThuc').val();
        AutoCreateName_SuDungDichVu();
    });
    // ============================================== BUTTON ===============================================
    $('#btnCreateSuDungDichVu').click(async function () {
        //If Status Create = True => Update Row Table
        if (await CreateSuDungDichVu() == true) {
            displayMessages(1, "Thêm thông tin thành công");
            let itemView = await SuDungDichVu_GetByIdTable($('#suDungDichVu_MaSuDungDichVu').val());
            itemView.maSuDungDichVu = '<input data-checkbox-id="' + itemView.maSuDungDichVu + '" type="checkbox"/>';
            if (itemView != null) {
                table.row.add(itemView).draw(false);
            }
        }
        else {
            displayMessages(3, "Thêm thông tin thất bại")
        }
    });

    $('#btnUpdateSuDungDichVu').click(async function () {
        //If Status Create = True => Update Row Table
        if (await UpdateSuDungDichVu() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView = await SuDungDichVu_GetByIdTable($('#suDungDichVu_MaSuDungDichVu').val());
            itemView.maSuDungDichVu = '<input data-checkbox-id="' + itemView.maSuDungDichVu + '" type="checkbox"/>';
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

    $('#btnDelete').click(async function () {
        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });

        if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
            let statusDelete = await SuDungDichVu_Delete(selectedIds, "Nhân viên Test");
            if (statusDelete) {
                displayMessages(1, "Xóa thành công");
                $("#DeleteModal").modal("hide");
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
            else {
                displayMessages(3, "Xóa thất bại");
            }
        }
    });

    $('#btnResetSuDungDichVu').click(function () {
        ACN_tenDichVuSuDung = "";
        ACN_tenHocSinh = "";
        ACN_tenNgayBatDau = "";
        ACN_tenNgayKetThuc = "";
        $('#suDungDichVu_MaSuDungDichVu').val(null);
        $('#suDungDichVu_TenSuDungDichVu').val(null);
        $('#suDungDichVu_MaHocSinh').val(null);
        $('#suDungDichVu_TenHocSinh').val(null);
        $('#suDungDichVu_NgayBatDau').val(null);
        $('#suDungDichVu_NgayKetThuc').val(null);
        $('#suDungDichVu_MaDichVu').val(0);
        $('#suDungDichVu_TrangThai').val("Tất cả");
    });

    $('#btnSearchSuDungDichVu').click(async function () {
        await CapNhatToken();
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