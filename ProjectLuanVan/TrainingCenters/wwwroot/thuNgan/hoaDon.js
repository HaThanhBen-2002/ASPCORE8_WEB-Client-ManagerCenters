let CtrungTam = JSON.parse(Cookies.get('trungTam'));
let CnhanVien = JSON.parse(Cookies.get('nhanVien'));
let Crole = JSON.parse(Cookies.get('role'));
let updateThanhToan = 0;
let trangThaiThanhToan = false;


async function PrintHoaDon(maPhieu) {
    let phieuThuChi = {
        MaPhieu: null,
        NgayTao: null,
        CodeHoaDon: null,
        NgayThanhToan: null,
        LoaiPhieu: null,
        TongTien: null,
        GhiChu: null,
        MaTrungTam: null,
        TrangThai: null,
        HinhThucThanhToan: null,
        MaNhanVien: null
    };
    if (maPhieu > 0) {
        let dataPTC = await PhieuThuChi_GetById(maPhieu);
        phieuThuChi.MaPhieu = dataPTC.maPhieu;
        phieuThuChi.NgayTao = dataPTC.ngayTao;
        phieuThuChi.CodeHoaDon = dataPTC.codeHoaDon;
        phieuThuChi.NgayThanhToan = dataPTC.ngayThanhToan;
        phieuThuChi.LoaiPhieu = dataPTC.loaiPhieu;
        phieuThuChi.TongTien = dataPTC.tongTien;
        phieuThuChi.MaTrungTam = dataPTC.maTrungTam;
        phieuThuChi.TrangThai = dataPTC.trangThai;
        phieuThuChi.HinhThucThanhToan = dataPTC.hinhThucThanhToan;
        phieuThuChi.MaNhanVien = dataPTC.maNhanVien;
        var selectedItems = [];
        let dataPTCSearch = await ChiTietThuChi_SearchByPhieuThuChiId(maPhieu);
        $.each(dataPTCSearch, function (index, item) {
            selectedItems.push({
                ten: item.tenChiTiet,
                gia: formatToVND(item.tongTien / item.soLuong),
                soLuong: item.soLuong,
                donViTinh: item.donVi,
                tongGia: formatToVND(item.tongTien)
            });
        });
        if (selectedItems != null && phieuThuChi != null) {
            $('#phieuThuChi_MaCodeHoaDon').text("Mã HD: " + phieuThuChi.CodeHoaDon);
            $('#phieuThuChi_NgayTao').text("Ngày tạo: " + phieuThuChi.NgayTao);
            $('#phieuThuChi_NgayThanhToan').text("Ngày thanh toán: " + phieuThuChi.NgayThanhToan);
            $('#phieuThuChiTongTien').text(formatToVND(phieuThuChi.TongTien));
            $('#phieuThuChi_TrungTam').text("Trung tâm:  " + GetTrungTamById(phieuThuChi.MaTrungTam));
            $('#phieuThuChi_LoaiPhieu').text("Loại hóa đơn: " + phieuThuChi.LoaiPhieu);
            $('#phieuThuChi_GhiChu').text(phieuThuChi.GhiChu);
            $('#phieuThuChi_HinhThucThanhToan').text("Hình thức thanh toán: " + phieuThuChi.HinhThucThanhToan);
            $('#phieuThuChi_TrangThai').text("Trạng thái:  " + phieuThuChi.TrangThai);
            selectedItems.forEach(function (item) {
                var row = '<tr>';
                row += '<td width="30%" class="px-1">' + item.ten + '</td>';
                row += '<td class="px-1">' + item.gia + '/' + item.donViTinh + '</td>';
                row += '<td width="10%" class="px-1">' + item.soLuong + '</td>';
                row += '<td class="px-1" data-tonggia="' + item.tongGia + '">' + item.tongGia + '</td>';
                row += '</tr>';
                $('#myTableHoaDon tbody').append(row);
            });
            // In hóa đơn
            var invoiceContent = $('#printableDiv').html();
            $('body').empty().html(invoiceContent);
            $('#imageDiv').html(' <img id="imageDiv" class="w-px-75 h-px-75 rounded-circle" src="/AdminAssets/assets/img/favicon/HTB.ico" />');
            window.print();
            window.location.href = "/Admin/PhieuThuChi/Index";
        }
        //$("#showHoaDon").modal('hide');
    }
}

async function GetTrungTamById(id) {
    let tenTrungTam = "";
    // Kiểm tra tính hợp lệ
    if (id != null) {
        let trungTam1 = await TrungTam_GetById(id);
        tenTrungTam = trungTam1.tenTrungTam;
    }
    return tenTrungTam;
}

async function ViewHoaDon(maPhieu) {
    updateThanhToan = maPhieu;
    $('#updateHoaDon').hide();
    $('#prinHoaDon').show();
    let phieuThuChi = {
        MaPhieu: null,
        NgayTao: null,
        CodeHoaDon: null,
        NgayThanhToan: null,
        LoaiPhieu: null,
        TongTien: null,
        GhiChu: null,
        MaTrungTam: null,
        TrangThai: null,
        HinhThucThanhToan: null,
        MaNhanVien: null
    };
    if (maPhieu > 0) {
        let dataPT = await PhieuThuChi_GetById(maPhieu);
        phieuThuChi.MaPhieu = dataPT.maPhieu;
        phieuThuChi.NgayTao = dataPT.ngayTao;
        phieuThuChi.CodeHoaDon = dataPT.codeHoaDon;
        phieuThuChi.NgayThanhToan = dataPT.ngayThanhToan;
        phieuThuChi.LoaiPhieu = dataPT.loaiPhieu;
        phieuThuChi.TongTien = dataPT.tongTien;
        phieuThuChi.MaTrungTam = dataPT.maTrungTam;
        phieuThuChi.TrangThai = dataPT.trangThai;
        phieuThuChi.HinhThucThanhToan = dataPT.hinhThucThanhToan;
        phieuThuChi.MaNhanVien = dataPT.maNhanVien;
        var selectedItems = [];
        let datas = await ChiTietThuChi_SearchByPhieuThuChiId(maPhieu);
        datas.forEach(function (item) {
            selectedItems.push({
                ten: item.tenChiTiet,
                gia: formatToVND(item.tongTien / item.soLuong),
                soLuong: item.soLuong,
                donViTinh: item.donVi,
                tongGia: formatToVND(item.tongTien)
            });
        });
        if (selectedItems != null && phieuThuChi != null) {
            if (CheckIsNull(phieuThuChi.NgayThanhToan)) {
                trangThaiThanhToan = true;
            }
            else {
                trangThaiThanhToan = false;
            }
            $('#phieuThuChi_MaCodeHoaDon').text("Mã HD: " + phieuThuChi.CodeHoaDon);
            $('#phieuThuChi_NgayTao').text("Ngày tạo: " + phieuThuChi.NgayTao);
            $('#phieuThuChi_NgayThanhToan').text("Ngày thanh toán: " + phieuThuChi.NgayThanhToan);
            $('#phieuThuChiTongTien').text(formatToVND(phieuThuChi.TongTien));
            $('#phieuThuChi_TrungTam').text("Trung tâm:  " + await GetTrungTamById(phieuThuChi.MaTrungTam));
            $('#phieuThuChi_LoaiPhieu').text("Loại hóa đơn: " + phieuThuChi.LoaiPhieu);
            $('#phieuThuChi_GhiChu').text(phieuThuChi.GhiChu);
            $('#phieuThuChi_HinhThucThanhToan').text("Hình thức thanh toán: " + phieuThuChi.HinhThucThanhToan);
            $('#phieuThuChi_TrangThai').text("Trạng thái:  " + phieuThuChi.TrangThai);
            $('#myTableHoaDon tbody').empty();
            selectedItems.forEach(function (item) {
                var row = '<tr>';
                row += '<td width="30%" class="px-1">' + item.ten + '</td>';
                row += '<td class="px-1">' + item.gia + '/' + item.donViTinh + '</td>';
                row += '<td width="10%" class="px-1">' + item.soLuong + '</td>';
                row += '<td class="px-1" data-tonggia="' + item.tongGia + '">' + item.tongGia + '</td>';
                row += '</tr>';
                $('#myTableHoaDon tbody').append(row);
            });

            $("#showHoaDon").modal('show');
        }
        //$("#showHoaDon").modal('hide');
    }
}

async function UpdateThanhToan(id) {
    let table = $('#myTable').DataTable();
    let status = false;
    // Kiểm tra tính hợp lệ
    if (id != null) {
        let statusUpdate = await PhieuThuChi_UpdateThanhToan(id);
        status = statusUpdate;
    }
    if (status) {
        displayMessages(1, "Cập nhật thanh toán thành công");
        let itemView = await PhieuThuChi_GetByIdTable(id);
        itemView.maPhieu = '<input data-checkbox-id="' + itemView.maPhieu + '" type="checkbox"/>';
        if (itemView != null) {
            table.rows('.selected').remove().draw(false);
            table.row.add(itemView).draw(false);
        }
    }
    else {
        displayMessages(2, "Cập nhật thanh toán thất bại");
    }

}
function EditHoaDon(maPhieu) {
    
    ViewHoaDon(maPhieu);
    $('#updateHoaDon').show();
    $('#prinHoaDon').hide();

    
}



$(document).ready(async function () {
    await CapNhatToken();
    // ============================================== TABLE ===============================================
    let phieuThuChi = {
        MaPhieu: null,
        NgayTao: null,
        CodeHoaDon: null,
        NgayThanhToan: null,
        LoaiPhieu: null,
        TongTien: null,
        GhiChu: null,
        MaTrungTam: CtrungTam,
        TrangThai: "Chưa thanh toán",
        HinhThucThanhToan: null,
        MaNhanVien: null
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
            url: "/PhieuThuChi/LoadingDataTableView",
            dataType: "json",
            headers: {
                "Authorization": `Bearer ${getToken()}`
            },
            data: { item: phieuThuChi },
            dataSrc: 'data',
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
            }
        },
        columns: [
            {
                data: 'maPhieu',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                }
            },
            { data: "loaiPhieu" },
            {
                data: 'tongTien',
                render: function (data, type, row) {
                    return formatToVND(data);
                }
            },
            { data: "ngayTao" },
            { data: "hinhThucThanhToan" },
            { data: "trangThai" },
            {
                data: 'maPhieu',
                render: function (data, type, row) {
                    return '<button onclick="ViewHoaDon(' + data + ')" class="btn btn-xs btn-secondary px-1"><i class="bx bx-show"></i></button> <button onclick="PrintHoaDon(' + data + ')" class="btn btn-xs btn-secondary px-1"><i class="bx bxs-printer"></i></button> <button onclick="EditHoaDon(' + data + ')" class="btn btn-xs btn-secondary px-1"><i class="bx bxs-message-square-edit"></i></button>';
                }
            },
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

    // ============================================== BUTTON ===============================================

    //$('#btnDeletePhieuThuChi').click(function () {
    //    let selectedIds = [];
    //    // Lặp qua các checkbox để xác định đối tượng nào được chọn
    //    $('input[type="checkbox"]:checked').each(function () {
    //        let checkboxId = $(this).data("checkbox-id");
    //        selectedIds.push(parseInt(checkboxId));
    //    });
    //    if (selectedIds.length >= 1 && selectedIds != null) {
    //        $("#DeleteModal").modal("show");
    //    }
    //});

    //$('#btnDelete').click(async function () {
    //    // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
    //    let selectedIds = [];
    //    // Lặp qua các checkbox để xác định đối tượng nào được chọn
    //    $('input[type="checkbox"]:checked').each(function () {
    //        let checkboxId = $(this).data("checkbox-id");
    //        selectedIds.push(parseInt(checkboxId));
    //    });

    //    if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
    //        let statusDelete = await PhieuThuChi_Delete(selectedIds,"Nhân viên Test");
    //        if (statusDelete) {
    //            displayMessages(1, "Xóa thành công");
    //            $("#DeleteModal").modal("hide");
    //            // Lặp qua từng hàng
    //            table.rows().every(function () {
    //                var rowData = this.data();
    //                // Kiểm tra xem rowData có tồn tại không trước khi truy cập thuộc tính
    //                if (rowData && rowData.maPhieuThuChi) {
    //                    var checkbox = $('input[data-checkbox-id="' + rowData.maPhieuThuChi + '"]');
    //                    if (checkbox.prop('checked')) {
    //                        // Xóa hàng nếu checkbox được kiểm tra
    //                        this.remove();
    //                    }
    //                }
    //            });
    //            // Vẽ lại DataTables sau khi xóa các hàng
    //            table.draw();
    //        }
    //        else {
    //            displayMessages(3, "Xóa thất bại");
    //        }
    //    }
    //});

    $('#btnPhieuThuChi_TimKiem').click(async function () {
        await CapNhatToken();
        var loaiHoaDonValues = $('#loaiHoaDonForm input:checked').map(function () {
            return $(this).val();
        }).get();

        var trangThaiValues = $('#trangThaiForm input:checked').map(function () {
            return $(this).val();
        }).get();

        var hinhThucThanhToanValues = $('#hinhThucThanhToanForm input:checked').map(function () {
            return $(this).val();
        }).get();

        phieuThuChi.LoaiPhieu = loaiHoaDonValues[0];
        phieuThuChi.TrangThai = trangThaiValues[0];
        phieuThuChi.HinhThucThanhToan = hinhThucThanhToanValues[0];
        phieuThuChi.CodeHoaDon = $('#phieuThuChi_SearchMaHoaDon').val();
        phieuThuChi.NgayTao = $('#phieuThuChi_SearchNgayTao').val();
        // Bạn có thể thêm các xử lý bổ sung ở đây nếu cần

        if (phieuThuChi.LoaiPhieu == "Tất cả") {
            phieuThuChi.LoaiPhieu = null;
        }
        if (phieuThuChi.TrangThai == "Tất cả") {
            phieuThuChi.TrangThai = null;
        }
        if (phieuThuChi.HinhThucThanhToan == "Tất cả") {
            phieuThuChi.HinhThucThanhToan = null;
        }
        table.settings()[0].ajax.data = { item: phieuThuChi };
        table.ajax.reload();
    });


    $('#prinHoaDon').click(function () {
        PrintHoaDon(updateThanhToan); 
    });

    $('#updateHoaDon').click(function () {
        if (trangThaiThanhToan) {
            UpdateThanhToan(updateThanhToan);
        }
        else {
            displayMessages(2, "Hóa đơn đã thanh toán");
        }
    });

    //============================CB========================
    $('input[type="checkbox"]').change(function () {
        var groupName = $(this).attr('name');
        var checkedBox = $(this);
        $('input[name="' + groupName + '"]').not(checkedBox).prop('checked', false);
    });
});