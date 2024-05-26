// Lưu thông tin tạm thời của 1 Tin nhắn
var messageTam;
var indexMessageTam = 0;
// Lưu danh sách tin nhắn cần gửi cho khách hàng
var danhSachMessage = [];
// Tải dữ liệu cho các ComboBox
async function CbbTrungTam() {
    let trungTams = await TrungTam_SearchName(null);
    $('#yeuCauThanhToan_MaTrungTam').empty();
    $('#yeuCauThanhToan_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#yeuCauThanhToan_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
}
async function CbbDichVu() {
    let dichVus = await DichVu_SearchName(null);
    $('#yeuCauThanhToan_MaDichVu').empty();
    $('#yeuCauThanhToan_MaDichVu').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(dichVus, function (index, item) {
        $('#yeuCauThanhToan_MaDichVu').append($('<option>', {
            value: item.maDichVu,
            text: item.tenDichVu
        }));
    });
}
// Func Support Tính số ngày của dịch vụ sử dụng
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

//============================== Send Email ===============================
// Phần xữ lý danh sách Message
function UpdateTableMessage() {
    $('#soluongMessage').text("Tổng số tin nhắn (" + danhSachMessage.length + ")");
    // Xóa các hàng hiện tại trong bảng trừ tiêu đề
    $('#myTableMessage tbody').empty();
    if (danhSachMessage != null) {
        // Lặp qua từng đối tượng trong mảng selectedItems và thêm vào bảng
        danhSachMessage.forEach(function (item, index) {
            var row = '<tr>';
            row += '<td class="px-1">' + item.Subject + '</td>';
            row += '</tr>';
            $('#myTableMessage tbody').append(row);
        });
    }
    // Thêm Id cho mỗi button trong hàng, chứa chỉ mục của hàng
    $('#myTableMessage tbody tr').each(function (index) {
        var rowIndex = index; // Lấy chỉ mục của hàng
        $(this).append('<td class="px-1"><button onclick="ViewMessage(' + rowIndex + ')" class="btn btn-xs btn-primary">Xem</button></td>');
    });

}
function ViewMessage(index) {
    let message = danhSachMessage[index];
    if (index != null && message != null) {
        messageTam = message;
        indexMessageTam = index;
        UpdateTableEmail();
    }
}

// Phần edit Message
function UpdateTableEmail() {
    if (messageTam != null) {
        $('#soluongEmail').text("Tổng số tin nhắn (" + messageTam.To.length + ")");
        // Xóa các hàng hiện tại trong bảng trừ tiêu đề
        $('#myTableEmail1 tbody').empty();
        if (messageTam.To != null) {
            // Lặp qua từng đối tượng trong mảng selectedItems và thêm vào bảng
            messageTam.To.forEach(function (item, index) {
                var row = '<tr>';
                row += '<td class="px-1">' + item + '</td>';
                row += '</tr>';
                $('#myTableEmail1 tbody').append(row);
            });
        }
        // Thêm Id cho mỗi button trong hàng, chứa chỉ mục của hàng
        $('#myTableEmail1 tbody tr').each(function (index) {
            var rowIndex = index; // Lấy chỉ mục của hàng
            $(this).append('<td class="px-1"><button onclick="DeleteItem(' + rowIndex + ')" class="btn btn-xs btn-danger">Xóa</button></td>');
        });
        $('#email_TieuDe1').val(messageTam.Subject);
        $('#summernote1').summernote('code', null);
        $("#summernote1").summernote({
            height: 500,
        });
        $('#summernote1').summernote('code', messageTam.Content);
    }
}
function DeleteItem(index) {
    // Xóa phần tử tương ứng trong danh sách selectedItems
    messageTam.To.splice(index, 1);
    // Cập nhật lại bảng
    UpdateTableEmail();
}
function AddItem(item) {
    if (isValidEmail(item)) {
        let coutt = 0;
        messageTam.To.forEach(function (email) {
            if (email == item) {
                coutt += 1;
            }
        });
        if (coutt == 0) {
            messageTam.To.push(item);
            // Cập nhật lại bảng
            UpdateTableEmail();
        }
        else {
            displayMessages(2, "Email đã có trong danh sách");
        }
    }
    else {
        displayMessages(2, "Email không hợp lệ");
    }
}
//============================== END Send Email ===============================


$(document).ready(async function () {
    await CapNhatToken();
    $('#summernote1').summernote('code', null);
   // ============================================== TABLE ===============================================
    var suDungDichVu = {
        MaSuDungDichVu: null,
        TenSuDungDichVu: null,
        MaDichVu: null,
        MaHocSinh: null,
        MaTrungTam: null,
        TrangThai: "Sắp hết hạn",
        NgayBatDau: null,
        NgayKetThuc: null
    };
    // Loading Data Table
    $('#myTable').DataTable({
        serverSide: true,
        scrollY: 300,
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
    $('#yeuCauThanhToan_MaTrungTam').change(async function () {
        let maTrungTam = $('#yeuCauThanhToan_MaTrungTam').val();
        suDungDichVu.MaTrungTam = maTrungTam;
        await CapNhatToken();
        if (suDungDichVu.MaTrungTam == 0) {
            suDungDichVu.MaTrungTam = null;
        }
        if (suDungDichVu.MaDichVu == 0) {
            suDungDichVu.MaDichVu = null;
        }
        table.settings()[0].ajax.data = { item: suDungDichVu };
        table.ajax.reload();
    });
    $('#yeuCauThanhToan_MaDichVu').change(async function () {
        let maDichVu = $('#yeuCauThanhToan_MaDichVu').val();
        suDungDichVu.MaDichVu = maDichVu;
        await CapNhatToken();
        if (suDungDichVu.MaTrungTam == 0) {
            suDungDichVu.MaTrungTam = null;
        }
        if (suDungDichVu.MaDichVu == 0) {
            suDungDichVu.MaDichVu = null;
        }
        table.settings()[0].ajax.data = { item: suDungDichVu };
        table.ajax.reload();
    });
    // ============================================== TEXT CHANGE ===============================================
    // ============================================== BUTTON ===============================================
    //btn Tải tin nhắn
    $('#btnLoadMessage').click(async function () {
        danhSachMessage = [];
        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            if (checkboxId != null) {
                selectedIds.push(parseInt(checkboxId));
            }
        });
        if (selectedIds.length >= 1) {
            for (let itemId of selectedIds) {
                let suDungDichVu = await SuDungDichVu_GetById(itemId);
                if (suDungDichVu != null) {
                    let hocSinh = await HocSinh_GetById(suDungDichVu.maHocSinh);
                    let dichVu = await DichVu_GetById(suDungDichVu.maDichVu);

                    let emailPhuHuynh = [];
                    if (hocSinh.emailCha != null) {
                        emailPhuHuynh.push(hocSinh.emailCha);
                    }
                    if (hocSinh.emailMe != null) {
                        emailPhuHuynh.push(hocSinh.emailMe);
                    }
                    let tieuDe = "Thông báo " + hocSinh.tenHocSinh + " cần gia hạn dịch vụ " + dichVu.tenDichVu;
                    var emailContent = `
                        <div class="content">
                            <p>Xin chào Phụ huynh <strong>`+ hocSinh.tenHocSinh + ` </strong>,</p>
                            <p> Chúng tôi xin nhắc nhở bạn về việc gia hạn cho dịch vụ <strong>`+ dichVu.tenDichVu + `</strong> mà bạn đã đăng ký vào ngày ` + suDungDichVu.ngayBatDau +`</p>
                            <table>
                                <tr>
                                    <td><strong>Tên dịch vụ:</strong></td>
                                    <td>`+ dichVu.tenDichVu + `</td>
                                </tr>
                                <tr>
                                    <td><strong>Giá dịch vụ:</strong></td>
                                    <td>`+ formatToVND(dichVu.gia) + `</td>
                                </tr>
                                <tr>
                                    <td><strong>Ngày đăng ký dịch vụ:</strong></td>
                                    <td>`+ suDungDichVu.ngayBatDau + `</td>
                                </tr>
                                <tr>
                                    <td><strong>Ngày hết hạn:</strong></td>
                                    <td>`+ suDungDichVu.ngayKetThuc + `</td>
                                </tr>
                            </table>
                            </br>
                            <p>Vui lòng gia hạn dịch vụ để tránh gián đoạn dịch vụ.</p>
                            <p>Nếu bạn có bất kỳ câu hỏi nào, xin vui lòng liên hệ với chúng tôi.</p>
                        </div>
                        <div class="footer">
                            <p>Trân trọng,<br/>Đội ngũ hỗ trợ khách hàng (Hà Thanh Bền)</p>
                        </div>`;
                    let mes = {
                        To: emailPhuHuynh,
                        Subject: tieuDe,
                        Content: emailContent
                    }
                    danhSachMessage.push(mes);
                }
            }
        }

        UpdateTableMessage();

    });
    //btn Thêm email
    $('#btnThemEmail1').click(function () {
        AddItem($('#email_ThemDiaChiEmail1').val());
    });
    //btn Cập nhật tin nhắn
    $('#btnUpdateMessger').click(function () {
        if (messageTam.To.length <= 0) {
            displayMessages(2, "Danh sách email đang rỗng");
        }
        else if (messageTam.Subject.length <= 0) {
            displayMessages(2, "Tiêu đề email rỗng");
        }
        else if (messageTam.Content.length <= 0) {
            displayMessages(2, "Nội dung email rỗng");
        }
        else {
            messageTam.Subject = $('#email_TieuDe1').val();
            messageTam.Content = $('#summernote1').val();
            danhSachMessage[indexMessageTam] = messageTam;
            UpdateTableMessage();
            displayMessages(1, "Cập nhật tin nhắn thành công");
        }
    });
    //btn Gửi Tin Nhắn
    $('#btnSendMessage').click(async function () {
        showLoading();
        let danhSachMessageTam = [];
        if (danhSachMessage.length != 0) {
            for (let item of danhSachMessage) {
                try {
                    if (item != null) {
                        let statusSend = await SendEmailText(item);
                        if (!statusSend) {
                            danhSachMessageTam.push(item);
                        }
                    }
                    console.log(item);

                } catch (error) {
                    console.error(`Error sending email to ${item}:`, error);
                }
            }
            if (danhSachMessageTam.length == danhSachMessage.length) {
                displayMessages(3, "Lỗi không thể gửi tin nhắn");
            }
            else {
                danhSachMessage = danhSachMessageTam;
                UpdateTableMessage();
                $('#soluongMessage').text("Tổng số tin nhắn không gửi được (" + danhSachMessage.length + ")");
            }
        }
        else {
            displayMessages(2, "Không tìm thấy tin nhắn cần gửi");
        }
        hideLoading();
    });

});