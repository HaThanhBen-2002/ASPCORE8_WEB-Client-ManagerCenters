var nhaCungCap = {
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
var emails = [];
var maNhaCungCaps = [];
//============================== Send Email ===============================
function UpdateTableEmail() {

    $('#quantityEmail').text("Địa Chỉ Email (" + emails.length + ")");
    // Xóa các hàng hiện tại trong bảng trừ tiêu đề
    $('#myTableEmail tbody').empty();
    if (emails != null) {
        // Lặp qua từng đối tượng trong mảng selectedItems và thêm vào bảng
        emails.forEach(function (item, index) {
            var row = '<tr>';
            row += '<td class="px-1">' + item + '</td>';
            row += '</tr>';
            $('#myTableEmail tbody').append(row);
        });
    }

    // Thêm Id cho mỗi button trong hàng, chứa chỉ mục của hàng
    $('#myTableEmail tbody tr').each(function (index) {
        var rowIndex = index; // Lấy chỉ mục của hàng
        $(this).append('<td class="px-1"><button onclick="DeleteItem(' + rowIndex + ')" class="btn btn-xs btn-danger">Xóa</button></td>');
    });

}
function DeleteItem(index) {
    // Xóa phần tử tương ứng trong danh sách selectedItems
    emails.splice(index, 1);
    // Cập nhật lại bảng
    UpdateTableEmail();
}
function AddItem(item) {
    if (isValidEmail(item)) {
        // Xóa phần tử tương ứng trong danh sách selectedItems
        emails.push(item);
        // Cập nhật lại bảng
        UpdateTableEmail();
    }
    else {
        displayMessages(2, "Email không hợp lệ");
    }
}
//============================== END Send Email ===============================
async function exportToExcel() {
    var listNhaCungCap = await NhaCungCap_Search(nhaCungCap);
    var listTrungTam = await TrungTam_Search();
    listNhaCungCap = listNhaCungCap.map(function (item) {
        delete item.$id;
        return {
            'Mã Nhà Cung Cấp': item.maNhaCungCap,
            'Tên Nhà Cung Cấp': item.tenNhaCungCap,
            'Giới Thiệu': item.gioiThieu,
            'Email': item.email,
            'Số Điện Thoại': item.soDienThoai,
            'Ngân Hàng': item.nganHang,
            'Số Tài Khoản': item.soTaiKhoan,
            'Mã Số Thuế': item.maSoThue,
            'Mã Trung Tâm': item.maTrungTam
        };
    });
    listTrungTam = listTrungTam.map(function (item) {
        delete item.$id;
        return {
            'Mã Trung Tâm': item.maTrungTam,
            'Tên Trung Tâm': item.tenTrungTam
        };
    });
    var workbook = XLSX.utils.book_new();

    var danhSachNhaCungCap = XLSX.utils.json_to_sheet(listNhaCungCap);
    XLSX.utils.book_append_sheet(workbook, danhSachNhaCungCap, "Danh sách nhà cung cấp");

    var danhSachTrungTam = XLSX.utils.json_to_sheet(listTrungTam);
    XLSX.utils.book_append_sheet(workbook, danhSachTrungTam, "Thông tin trung tâm");

    XLSX.writeFile(workbook, "DanhSachNhaCungCap.xlsx");
}





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

async function CreateNhaCungCap() {
    let item = GetNhaCungCapById();
    // Kiểm tra tính hợp lệ
    if (isValidNhaCungCap(item)) {
        item.MaNhaCungCap = null;
        let status = await NhaCungCap_Create(item);
        return status;
    }
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
    $('#nhaCungCap_MaTrungTam').empty();
    $('#nhaCungCap_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#nhaCungCap_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
}

async function UpdateNhaCungCap() {

    let item = GetNhaCungCapById();
    // Kiểm tra tính hợp lệ
    if (isValidNhaCungCap(item) && CheckIsNull(item.MaNhaCungCap)!=true){
        let status = await NhaCungCap_Update(item);
        return status;
    }
}

$(document).ready(async function () {
    await CapNhatToken();
    // ============================================== TABLE ===============================================

    // Loading Data Table
    $('#myTable').DataTable({
        serverSide: true,
        scrollY: 400,
        searching: false,
        lengthChange: true,
        ordering: false,
        ajax: {
            type: "POST",
            url: "/NhaCungCap/LoadingDataTableView",
            dataType: "json",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            data: { item: nhaCungCap },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
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
            const rowId = table.row(this).data().maNhaCungCap;
            // Thực hiện get giá trị của Academic với rowId
            let data = await NhaCungCap_GetById(rowId);
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
    $('#btnCreateNhaCungCap').click(async function () {
        try {
            if (await CreateNhaCungCap() == true) {
                displayMessages(1, "Thêm thông tin thành công");
                let itemView = await NhaCungCap_GetByIdTable($('#nhaCungCap_MaNhaCungCap').val());
                itemView.maNhaCungCap = '<input data-checkbox-id="' + itemView.maNhaCungCap + '" type="checkbox"/>';
                if (itemView != null) {
                    table.row.add(itemView).draw(false);
                }
            } else {
                displayMessages(2, "Thêm thông tin thất bại");
            }
        } catch (error) {
            console.error("Error:", error);
        }
    });


    $('#btnUpdateNhaCungCap').click(async function () {
        // If Status Update = True => Update Row Table
        if (await UpdateNhaCungCap() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView = await NhaCungCap_GetByIdTable($('#nhaCungCap_MaNhaCungCap').val());
            itemView.maNhaCungCap = '<input data-checkbox-id="' + itemView.maNhaCungCap + '" type="checkbox"/>';
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
            displayMessages(2, "Cập nhật thông tin thất bại");
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

    $('#btnDelete').click(async function () {
        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });

        if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
            let statusDelete = await NhaCungCap_Delete(selectedIds, "Nhân viên TEST");
            if (statusDelete) {
                displayMessages(1, "Xóa thành công");
                $("#DeleteModal").modal("hide");
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
            else {
                displayMessages(3, "Xóa thất bại");
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

    $('#btnSearchNhaCungCap').click(async function () {
        await CapNhatToken();
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

    // Khác==============================

    $('#giaiPhongDuLieu').click(function () {
        nhaCungCap.MaNhaCungCap = 0;
        table.settings()[0].ajax.data = { item: nhaCungCap };
        table.ajax.reload();
    });

    $('#showThongTin').click(function () {
        $("#viewShowThongTin").toggle();
    });
    $('#btnThemEmail').click(function () {
        AddItem($('#email_ThemDiaChiEmail').val());

    });
    $('#btnSendEmail').click(async function () {
        showLoading();
        let contentEmail = $("#summernote").summernote('code');
        let subject = $("#email_TieuDe").val();
        if (emails == null) {
            displayMessages(2, "Không tìm thấy email để gửi");
        }
        else if (CheckIsNull(subject)) {
            displayMessages(2, "Vui lòng nhập tiêu đề Email");
        }
        else if (CheckIsNull(contentEmail)) {
            displayMessages(2, "Vui lòng soạn nội dung Email");
        }
        else {
            let message = {
                To: emails,
                Subject: subject,
                Content: contentEmail,
            };
            let statusSend = await SendEmailText(message);
            if (statusSend) {
                displayMessages(1, "Gửi Email Thành Công");
            }
            else {
                displayMessages(3, "Gửi Email Thất Bại");
            }
            hideLoading();

        }
    });
    // Content Email
    $('#summernote').summernote('code', $("#CContent").val());
    $("#summernote").summernote({
        height: 400,
    });
    $('#btnViewSendEmail').click( async function () {
        emails = [];
        maNhaCungCaps = [];
        //Get list maNhaCungCap có checkbox = true
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            maNhaCungCaps.push(parseInt(checkboxId));
        });
        //Lấy email nhân viên đang show chi tiết
        if (isValidEmail($('#nhaCungCap_Email').val()) && maNhaCungCaps.length <= 2) {
            emails.push($('#nhaCungCap_Email').val());
        }

        //Lấy thông tin email dựa vào tham số object nhaCungCap
        let nhaCungCapNames = await NhaCungCap_SearchName(nhaCungCap);
        $.each(nhaCungCapNames, function (index, item) {
            $.each(maNhaCungCaps, function (indexMa, ma) {
                if (item.maNhaCungCap === ma) {
                    emails.push(item.email);
                    maNhaCungCaps.splice(indexMa, 1); // Xóa phần tử khớp từ mảng maNhaCungCaps
                }
            });
        });
        UpdateTableEmail();
    });
});