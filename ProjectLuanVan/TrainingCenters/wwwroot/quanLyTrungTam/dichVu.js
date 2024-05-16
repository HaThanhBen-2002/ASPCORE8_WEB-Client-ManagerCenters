let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));
let Crole = JSON.parse(Cookies.get('role'));


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