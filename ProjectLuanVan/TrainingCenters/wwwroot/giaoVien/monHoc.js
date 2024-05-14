
function GetMonHocData() {
    return {
        MaMonHoc: $('#monHoc_MaMonHoc').val(),
        TenMonHoc: $('#monHoc_TenMonHoc').val(),
        ThongTin: $('#monHoc_ThongTin').val(),
        Gia: $('#monHoc_Gia').val(),
    };
}



$(document).ready(async function () {
    await CapNhatToken();
   // ============================================== TABLE ===============================================
    let monHoc = {
        MaMonHoc: null,
        TenMonHoc: null,
        Gia: null,
        ThongTin: null
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
            url: "/MonHoc/LoadingDataTableView",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            dataType: "json",
            data: { item: monHoc },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
        },
        columns: [
            {
                data: 'maMonHoc',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
            }
            },
            { data: "tenMonHoc" },
            {
                data: 'gia',
                render: function (data, type, row) {
                    return "******đ";
                }
            },
            { data: "thongTin" }
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
            const rowId = table.row(this).data().maMonHoc;
            let data = await MonHoc_GetById(rowId);
            $('#monHoc_MaMonHoc').val(data.maMonHoc);
            $('#monHoc_TenMonHoc').val(data.tenMonHoc);
            $('#monHoc_ThongTin').val(data.thongTin);
            $('#monHoc_Gia').val("******đ");
        }
    });

    // Event checkbox "Check All"
    $('#checkAll').change( function () {
        var isChecked = $(this).prop('checked');
        if (isChecked) {
            $('input[type="checkbox"]').each( function () {
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

    $('#btnResetMonHoc').click(function () {
        $('#monHoc_MaMonHoc').val(null);
        $('#monHoc_TenMonHoc').val(null);
        $('#monHoc_ThongTin').val(null);
        $('#monHoc_Gia').val(null);
    });

    $('#btnSearchMonHoc').click(async function () {
        await CapNhatToken();
        monHoc = GetMonHocData();
        table.settings()[0].ajax.data = { item: monHoc };
        table.ajax.reload();
    });
});