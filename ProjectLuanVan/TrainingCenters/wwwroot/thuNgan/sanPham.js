let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));
let Crole = JSON.parse(Cookies.get('role'));
function isValidSanPham(item) {
    // Kiểm tra tính hợp lệ
    if (CheckIsNull(item.TenSanPham)) {
        displayMessages(2, "Vui lòng nhập (Tên sản phẩm)");
        return false;
    } else if (CheckIsNull(item.HanSuDung)) {
        displayMessages(2, "Vui lòng chọn (Hạn sử dụng)");
        return false;
    } else if (CheckIsNull(item.LoaiSanPham)) {
        displayMessages(2, "Vui lòng chọn (Loại sản phẩm)");
        return false;
    } else if (CheckIsNull(item.MaNhaCungCap)) {
        displayMessages(2, "Vui lòng chọn (Nhà cung cấp)");
        return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Trung tâm)");
        return false;
    } else if (CheckIsNull(item.Gia)) {
        displayMessages(2, "Vui lòng nhập (Giá)");
        return false;
    } else {
        return true;
    }
}

function GetSanPhamById() {
    let item = {
        MaSanPham: $('#sanPham_MaSanPham').val(),
        TenSanPham: $('#sanPham_TenSanPham').val(),
        ThongTin: $('#sanPham_ThongTin').val(),
        Gia: $('#sanPham_Gia').val(),
        HanSuDung: $('#sanPham_HanSuDung').val(),
        LoaiSanPham: $('#sanPham_LoaiSanPham').val(),
        MaNhaCungCap: $('#sanPham_MaNhaCungCap').val(),
        MaTrungTam: $('#sanPham_MaTrungTam').val()
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
    $('#sanPham_MaTrungTam').empty();
    $('#sanPham_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#sanPham_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
    $('#sanPham_MaTrungTam').val(CtrungTam);

}

async function CbbNhaCungCapByMaTrungTam() {
    let trungTam = CtrungTam;
    if (trungTam != 0 && trungTam != null) {

        let nhaCungCap = {
            MaNhaCungCap: null,
            TenNhaCungCap: null,
            GioiThieu: null,
            Email: null,
            SoDienThoai: null,
            NganHang: null,
            SoTaiKhoan: null,
            MaSoThue: null,
            MaTrungTam: trungTam
        };

        let nhaCungCaps = await NhaCungCap_SearchName(nhaCungCap);
        $('#sanPham_MaNhaCungCap').empty();
        $('#sanPham_MaNhaCungCap').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
        $.each(nhaCungCaps, function (index, item) {
            $('#sanPham_MaNhaCungCap').append($('<option>', {
                value: item.maNhaCungCap,
                text: item.tenNhaCungCap
            }));
        });
    }
    else {
        $('#sanPham_MaNhaCungCap').empty();
        $('#sanPham_MaNhaCungCap').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
    }
}

$(document).ready(async function () {
    await CapNhatToken();
    // ============================================== TABLE ===============================================
    var sanPham = {
        MaSanPham: null,
        TenSanPham: null,
        ThongTin: null,
        LoaiSanPham: null,
        HanSuDung: null,
        MaNhaCungCap: null,
        MaTrungTam: CtrungTam,
        Gia: null
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
            url: "/SanPham/LoadingDataTableView",
            dataType: "json",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            data: { item: sanPham },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
        },
        columns: [
            {
                data: 'maSanPham',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                }
            },
            { data: "tenSanPham" },
            { data: "loaiSanPham" },
            { data: "hanSuDung" },
            {
                data: 'gia',
                render: function (data, type, row) {
                    return formatToVND(data);
                }
            },
            { data: "tenNhaCungCap" },
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
            const rowId = table.row(this).data().maSanPham;
            // Thực hiện get giá trị của Academic với rowId
            let data = await SanPham_GetById(rowId);
            await CbbNhaCungCapByMaTrungTam();
            $('#sanPham_MaSanPham').val(data.maSanPham);
            $('#sanPham_TenSanPham').val(data.tenSanPham);
            $('#sanPham_ThongTin').val(data.thongTin);
            $('#sanPham_Gia').val(data.gia);
            $('#sanPham_HanSuDung').val(data.hanSuDung);
            $('#sanPham_LoaiSanPham').val(data.loaiSanPham);
            $('#sanPham_MaNhaCungCap').val(data.maNhaCungCap);
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
    CbbNhaCungCapByMaTrungTam();
    // ============================================== BUTTON ===============================================
    $('#btnResetSanPham').click(function () {
        $('#sanPham_MaSanPham').val(null);
        $('#sanPham_TenSanPham').val(null);
        $('#sanPham_ThongTin').val(null);
        $('#sanPham_Gia').val(null);
        $('#sanPham_HanSuDung').val("Tất cả");
        $('#sanPham_LoaiSanPham').val("Tất cả");
        $('#sanPham_MaNhaCungCap').val(0);
    });

    $('#btnSearchSanPham').click(async function () {
        await CapNhatToken();
        sanPham = GetSanPhamById();

        if (sanPham.LoaiSanPham == "Tất cả") {
            sanPham.LoaiSanPham = null;
        }
        if (sanPham.HanSuDung == "Tất cả") {
            sanPham.HanSuDung = null;
        }
        if (sanPham.MaNhaCungCap == 0) {
            sanPham.MaNhaCungCap = null;
        }
        if (sanPham.MaTrungTam == 0) {
            sanPham.MaTrungTam = null;
        }
        table.settings()[0].ajax.data = { item: sanPham };
        table.ajax.reload();
    });
});