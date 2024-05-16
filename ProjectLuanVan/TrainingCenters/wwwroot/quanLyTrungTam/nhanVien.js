let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));
let Crole = JSON.parse(Cookies.get('role'));
var nhanVien = {
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
    MaTrungTam: CtrungTam,
    MaTaiKhoan: null,
    LoaiNhanVien: null,
    PhongBan: null,
    Luong: null,
    NganHang: null,
    SoTaiKhoan: null,
    DanToc: null,
    TonGiao: null
};
var emails = [];
var maNhanViens = [];
function isValidNhanVien(item) {
    // Kiểm tra tính hợp lệ
    if (CheckIsNull(item.TenNhanVien)) {
        displayMessages(2, "Vui lòng nhập (Tên nhân viên)"); return false;
    } else if (CheckIsNull(item.Cccd)) {
        displayMessages(2, "Vui lòng nhập (CCCD)"); return false;
    } else if (CheckIsNull(item.NgaySinh)) {
        displayMessages(2, "Vui lòng nhập (Ngày sinh)"); return false;
    } else if (CheckIsNull(item.SoDienThoai)) {
        displayMessages(2, "Vui lòng nhập (Số điện thoại)"); return false;
    } else if (CheckIsNull(item.Email)) {
        displayMessages(2, "Vui lòng nhập (Email)"); return false;
    } else if (CheckIsNull(item.GioiTinh)) {
        displayMessages(2, "Vui lòng chọn (Giới tính)"); return false;
    } else if (CheckIsNull(item.MaTrungTam)) {
        displayMessages(2, "Vui lòng chọn (Trung tâm)"); return false;
    } else if (CheckIsNull(item.LoaiNhanVien)) {
        displayMessages(2, "Vui lòng chọn (Loại nhân viên)"); return false;
    } else if (CheckIsNull(item.NganHang)) {
        item.NganHang = null;
    } else if (CheckIsNull(item.DanToc)) {
        item.DanToc = null;
    } else if (CheckIsNull(item.TonGiao)) {
        item.TonGiao = null;
    } else if (CheckIsNull(item.PhongBan)) {
        displayMessages(2, "Vui lòng chọn (Phòng ban)"); return false;
    } else {
        return true;
    }
}
function GetNhanVienById() {
    let item = {
        MaNhanVien: $('#nhanVien_MaNhanVien').val(),
        TenNhanVien: $('#nhanVien_TenNhanVien').val(),
        Cccd: $('#nhanVien_Cccd').val(),
        NgaySinh: $('#nhanVien_NgaySinh').val(),
        DiaChi: $('#nhanVien_DiaChi').val(),
        SoDienThoai: $('#nhanVien_SoDienThoai').val(),
        Email: $('#nhanVien_Email').val(),
        ThongTin: $('#nhanVien_ThongTin').val(),
        Luong: $('#nhanVien_Luong').val(),
        MaTaiKhoan: $('#nhanVien_MaTaiKhoan').val(),
        NganHang: $('#nhanVien_NganHang').val(),
        SoTaiKhoan: $('#nhanVien_SoTaiKhoan').val(),
        GioiTinh: $('#nhanVien_GioiTinh').val(),
        MaTrungTam: CtrungTam,
        LoaiNhanVien: $('#nhanVien_LoaiNhanVien').val(),
        PhongBan: $('#nhanVien_PhongBan').val(),
        DanToc: $('#nhanVien_DanToc').val(),
        TonGiao: $('#nhanVien_TonGiao').val(),
        HinhAnh: $('#imageShow').attr('src')
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
    $('#nhanVien_MaTrungTam').empty();
    $('#nhanVien_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#nhanVien_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
    $('#nhanVien_MaTrungTam').val(CtrungTam);
}

async  function CreateNhanVien() {
    let item = GetNhanVienById();
    item.MaTrungTam = CtrungTam;
    if (isValidNhanVien(item)) {
        item.MaNhanVien = null;
        let status = await NhanVien_Create(item);
        return status;
    }
}

async function UpdateNhanVien() {

    let item = GetNhanVienById();
    item.MaTrungTam = CtrungTam;
    if (isValidNhanVien(item) && CheckIsNull(item.MaNhanVien)!=true){
        let status = await NhanVien_Update(item);
        return status;
    }
}

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
        displayMessages(2,"Email không hợp lệ");
    }
}
//============================== END Send Email ===============================
//===== Func xữ lí ảnh
function openFileInput() {
    $("#fileInput").click();
}
// Xử lý file ảnh mà người dùng chọn
function handleFileSelect(input) {
    var file = input.files[0];
    if (file) {
        // Kiểm tra kích thước của file
        if (file.size > 500 * 1024) { // Kích thước lớn hơn 500KB
            alert("Vui lòng chọn một file ảnh có kích thước nhỏ hơn 500KB.");
            return;
        }

        var reader = new FileReader();
        reader.onload = function (e) {
            image = e.target.result;
            updateCarousel();
        };
        reader.readAsDataURL(file);
    }
}
// Hàm cập nhật carousel-inner
function updateCarousel() {
    var carouselInner = $("#carouselExample .carousel-inner");
    carouselInner.empty(); // Xóa tất cả các ảnh hiện tại
    var carouselItem =
        '<div class="carousel-item active">' +
        '<img id="imageShow" class="d-block img-fluid" style="border-radius: 0.5rem" alt="Không tìm thấy ảnh" src="' + image + '">' +
        '</div>';
    carouselInner.append(carouselItem);
}
// Hàm xóa ảnh
function deleteImage() {
    image = ""; // Xóa ảnh cuối cùng trong mảng
    updateCarousel();
}

async function exportToExcel() {
    var listNhanVien = await NhanVien_SearchName(nhanVien);
    var listTrungTam = await TrungTam_SearchName();

    listNhanVien = listNhanVien.map(function (item) {
        delete item.$id;
        return {
            'Mã Nhân Viên': item.maNhanVien,
            'Tên Nhân Viên': item.tenNhanVien,
            'CCCD': item.cccd,
            'Ngày Sinh': item.ngaySinh,
            'Giới Tính': item.gioiTinh,
            'Địa Chỉ': item.diaChi,
            'Số Điện Thoại': item.soDienThoai,
            'Email': item.email,
            'Thông Tin': item.thongTin,
            'Mã Trung Tâm': item.maTrungTam,
            'Mã Tài Khoản': item.maTaiKhoan,
            'Loại Nhân Viên': item.loaiNhanVien,
            'Phòng Ban': item.phongBan,
            'Lương': item.luong,
            'Tên Ngân Hàng': item.nganHang,
            'Số Tài Khoản': item.soTaiKhoan,
            'Dân Tộc': item.danToc,
            'Tôn Giáo': item.tonGiao
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

    var danhSachNhanVien = XLSX.utils.json_to_sheet(listNhanVien);
    XLSX.utils.book_append_sheet(workbook, danhSachNhanVien, "Danh sách nhân viên");

    var danhSachTrungTam = XLSX.utils.json_to_sheet(listTrungTam);
    XLSX.utils.book_append_sheet(workbook, danhSachTrungTam, "Thông tin trung tâm");

    XLSX.writeFile(workbook, "DanhSachNhanVien.xlsx");
}

$(document).ready(async function () {
    await CapNhatToken();
    
    //=============================== IMAGE ===================================
    // đối tượng ảnh
    var image = "";
    $("#addImage").click(function () {
        openFileInput();
    });
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
            url: "/NhanVien/LoadingDataTableView",
            dataType: "json",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            data: { item: nhanVien },
            dataSrc: 'data',
            beforeSend: function(xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
        },
        columns: [
            {
                data: 'maNhanVien',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                }
            },
            { data: "tenNhanVien" },
            { data: "loaiNhanVien" },
            { data: "ngaySinh" },
            { data: "gioiTinh" },
            { data: "phongBan" }
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
            const rowId = table.row(this).data().maNhanVien;
            let data = await NhanVien_GetById(rowId);
            $('#nhanVien_MaNhanVien').val(data.maNhanVien);
            $('#nhanVien_TenNhanVien').val(data.tenNhanVien);
            $('#nhanVien_Cccd').val(data.cccd);
            $('#nhanVien_NgaySinh').val(data.ngaySinh);
            $('#nhanVien_DiaChi').val(data.diaChi);
            $('#nhanVien_SoDienThoai').val(data.soDienThoai);
            $('#nhanVien_Email').val(data.email);
            $('#nhanVien_ThongTin').val(data.thongTin);
            $('#nhanVien_Luong').val(data.luong);
            $('#nhanVien_MaTaiKhoan').val(data.maTaiKhoan);
            $('#nhanVien_NganHang').val(data.nganHang);
            $('#nhanVien_SoTaiKhoan').val(data.soTaiKhoan);
            $('#nhanVien_GioiTinh').val(data.gioiTinh);
            $('#nhanVien_LoaiNhanVien').val(data.loaiNhanVien);
            $('#nhanVien_PhongBan').val(data.phongBan);
            $('#nhanVien_DanToc').val(data.danToc);
            $('#nhanVien_TonGiao').val(data.tonGiao);
            $('#imageShow').attr('src', data.hinhAnh);
            
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
    //=============================== CBB ===================================
    CbbTrungTam();
    
    // ============================================== BUTTON ===============================================
    $('#btnCreateNhanVien').click(async function () {
        //If Status Create = True => Update Row Table
        let item = GetNhanVienById();
        var nhanVien1 = {
            MaNhanVien: null,
            TenNhanVien: null,
            Cccd: null,
            NgaySinh: null,
            GioiTinh: null,
            DiaChi: null,
            SoDienThoai: null,
            Email: item.Email,
            ThongTin: null,
            HinhAnh: null,
            MaTrungTam: CtrungTam,
            MaTaiKhoan: null,
            LoaiNhanVien: null,
            PhongBan: null,
            Luong: null,
            NganHang: null,
            SoTaiKhoan: null,
            DanToc: null,
            TonGiao: null
        };
        let checkEmail = await NhanVien_Search(nhanVien1);

        if (checkEmail.length != 0) {
            displayMessages(2, "Email đã tồn tại")
        }
        else {
            if (await CreateNhanVien() == true) {
                displayMessages(1, "Thêm thông tin thành công");
                let itemView = await NhanVien_GetByIdTable($('#nhanVien_MaNhanVien').val());
                itemView.maNhanVien = '<input data-checkbox-id="' + itemView.maNhanVien + '" type="checkbox"/>';
                if (itemView != null) {
                    table.row.add(itemView).draw(false);
                }
            }
            else {
                displayMessages(3, "Thêm thông tin thất bại")
            }
        }
    });

    $('#btnUpdateNhanVien').click(async function () {
        //If Status Create = True => Update Row Table
        if (await UpdateNhanVien() == true) {
            displayMessages(1, "Cập nhật thông tin thành công");
            let itemView = await NhanVien_GetByIdTable($('#loSanPham_MaLoSanPham').val());
            itemView.maNhanVien = '<input data-checkbox-id="' + itemView.maNhanVien + '" type="checkbox"/>';
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

    $('#btnDeleteNhanVien').click(function () {
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
            let statusDelete = await NhanVien_Delete(selectedIds, "Nhân viên Test");
            if (statusDelete) {
                displayMessages(1, "Xóa thành công");
                $("#DeleteModal").modal("hide");
                // Lặp qua từng hàng
                table.rows().every(function () {
                    var rowData = this.data();
                    // Kiểm tra xem rowData có tồn tại không trước khi truy cập thuộc tính
                    if (rowData && rowData.maNhanVien) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maNhanVien + '"]');
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

    $('#btnResetNhanVien').click(function () {
        $('#nhanVien_MaNhanVien').val(null);
        $('#nhanVien_TenNhanVien').val(null);
        $('#nhanVien_Cccd').val(null);
        $('#nhanVien_NgaySinh').val(null);
        $('#nhanVien_DiaChi').val(null);
        $('#nhanVien_SoDienThoai').val(null);
        $('#nhanVien_Email').val(null);
        $('#nhanVien_ThongTin').val(null);
        $('#nhanVien_Luong').val(null);
        $('#nhanVien_MaTaiKhoan').val(null);
        $('#nhanVien_NganHang').val("Tất cả");
        $('#nhanVien_SoTaiKhoan').val(null);
        $('#nhanVien_GioiTinh').val("Tất cả");
        $('#nhanVien_LoaiNhanVien').val("Tất cả");
        $('#nhanVien_PhongBan').val("Tất cả");
        $('#nhanVien_DanToc').val("Tất cả");
        $('#nhanVien_TonGiao').val("Tất cả");
        $('#imageShow').attr('src', null);
    });

    $('#btnSearchNhanVien').click(async function () {
        await CapNhatToken();
        nhanVien = GetNhanVienById();
        nhanVien.HinhAnh = null;
        // Bạn có thể thêm các xử lý bổ sung ở đây nếu cần
        if (nhanVien.DanToc == "Tất cả") {
            nhanVien.DanToc = null;
        }
        if (nhanVien.TonGiao == "Tất cả") {
            nhanVien.TonGiao = null;
        }
        if (nhanVien.NganHang == "Tất cả") {
            nhanVien.NganHang = null;
        }
        if (nhanVien.PhongBan == "Tất cả") {
            nhanVien.PhongBan = null;
        }
        if (nhanVien.LoaiNhanVien == "Tất cả") {
            nhanVien.LoaiNhanVien = null;
        }
        if (nhanVien.GioiTinh == "Tất cả") {
            nhanVien.GioiTinh = null;
        }
        if (nhanVien.MaTrungTam == 0) {
            nhanVien.MaTrungTam = null;
        }

        table.settings()[0].ajax.data = { item: nhanVien };
        table.ajax.reload();
    });

    // Khác==============================

    $('#giaiPhongDuLieu').click(function () {
        nhanVien.MaNhanVien = 0;
        table.settings()[0].ajax.data = { item: nhanVien };
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
    $('#btnViewSendEmail').click(async function () {
        emails = [];
        maNhanViens = [];
        //Get list maNhanVien có checkbox = true
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            maNhanViens.push(parseInt(checkboxId));
        });
        //Lấy email nhân viên đang show chi tiết
        if (isValidEmail($('#nhanVien_Email').val()) && maNhanViens.length <= 2) {
            emails.push($('#nhanVien_Email').val());
        }
        //Lấy thông tin email dựa vào tham số object nhanVien
        let maNhanVienNames = await NhanVien_SearchName(nhanVien);
        $.each(maNhanVienNames, function (index, item) {
            $.each(maNhanViens, function (indexMa, ma) {
                if (item.maNhanVien === ma) {
                    emails.push(item.email);
                    maNhanViens.splice(indexMa, 1);
                }
            });
        });
        UpdateTableEmail();
    });
});