function PrintHoaDon(maPhieu) {
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
        $.ajax({
            type: "POST",
            url: "/Admin/PhieuThuChi/GetById",
            async: false,
            data: { id: maPhieu },
            success: function (data) {
                phieuThuChi.MaPhieu = data.maPhieu;
                phieuThuChi.NgayTao = data.ngayTao;
                phieuThuChi.CodeHoaDon = data.codeHoaDon;
                phieuThuChi.NgayThanhToan = data.ngayThanhToan;
                phieuThuChi.LoaiPhieu = data.loaiPhieu;
                phieuThuChi.TongTien = data.tongTien;
                phieuThuChi.MaTrungTam = data.maTrungTam;
                phieuThuChi.TrangThai = data.trangThai;
                phieuThuChi.HinhThucThanhToan = data.hinhThucThanhToan;
                phieuThuChi.MaNhanVien = data.maNhanVien;
            }
        });
        var selectedItems = [];
        $.ajax({
            type: "POST",
            url: "/Admin/ChiTietThuChi/SearchByPhieuThuChiId",
            async: false,
            data: { id: maPhieu },
            success: function (data) {
                data.$values.forEach(function (item) {
                    selectedItems.push({
                        ten: item.tenChiTiet,
                        gia: formatToVND(item.tongTien / item.soLuong),
                        soLuong: item.soLuong,
                        donViTinh: item.donVi,
                        tongGia: formatToVND(item.tongTien)
                    });
                });
            }
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

function GetTrungTamById(id) {
    let tenTrungTam = "";
    // Kiểm tra tính hợp lệ
    if (id != null) {
        $.ajax({
            type: "POST",
            url: "/Admin/TrungTam/GetById",
            async: false,
            data: { id: id },
            success: function (data) {
                tenTrungTam = data.tenTrungTam;
            }
        });
    }
    return tenTrungTam;
}

function ViewHoaDon(maPhieu) {
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
        $.ajax({
            type: "POST",
            url: "/Admin/PhieuThuChi/GetById",
            async: false,
            data: { id: maPhieu },
            success: function (data) {
                phieuThuChi.MaPhieu = data.maPhieu;
                phieuThuChi.NgayTao = data.ngayTao;
                phieuThuChi.CodeHoaDon = data.codeHoaDon;
                phieuThuChi.NgayThanhToan = data.ngayThanhToan;
                phieuThuChi.LoaiPhieu = data.loaiPhieu;
                phieuThuChi.TongTien = data.tongTien;
                phieuThuChi.MaTrungTam = data.maTrungTam;
                phieuThuChi.TrangThai = data.trangThai;
                phieuThuChi.HinhThucThanhToan = data.hinhThucThanhToan;
                phieuThuChi.MaNhanVien = data.maNhanVien;
            }
        });
        var selectedItems = [];
        $.ajax({
            type: "POST",
            url: "/Admin/ChiTietThuChi/SearchByPhieuThuChiId",
            async: false,
            data: { id: maPhieu },
            success: function (data) {
                data.$values.forEach(function (item) {
                    selectedItems.push({
                        ten: item.tenChiTiet,
                        gia: formatToVND(item.tongTien / item.soLuong),
                        soLuong: item.soLuong,
                        donViTinh: item.donVi,
                        tongGia: formatToVND(item.tongTien)
                    });
                });
            }
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

            $("#showHoaDon").modal('show');
            // Lặp qua từng đối tượng trong mảng selectedItems và thêm vào bảng
        }
        //$("#showHoaDon").modal('hide');
    }
}



$(document).ready(function () {
    // ============================================== TABLE ===============================================
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
    // Loading Data Table
    $('#myTable').DataTable({
        serverSide: true,
        scrollY: 400,
        searching: false,
        lengthChange: true,
        ordering: false,
        ajax: {
            type: "POST",
            url: "/Admin/PhieuThuChi/LoadingDataTableView",
            dataType: "json",
            data: { item: phieuThuChi },
            dataSrc: 'data'
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
                    return '<button onclick="ViewHoaDon(' + data + ')" class="btn btn-xs btn-primary">Xem</button> <button onclick="PrintHoaDon(' + data + ')" class="btn btn-xs btn-primary">Print</button>';
                }
            },



        ],

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

    $('#btnDeletePhieuThuChi').click(function () {
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

    $('#btnDelete').click(function () {
        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });

        if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
            let statusDelete = false;
            // Gửi danh sách ID được chọn đến action bằng Ajax
            $.ajax({
                type: "POST",
                url: "/Admin/PhieuThuChi/Delete",
                async: false,
                data: { ids: selectedIds, nguoiXoa: "Nhân viên TEST" }, // Truyền danh sách ID đến action
                success: function (data) {
                    if (data.isSuccess == true) {
                        displayMessages(1, "Xóa thành công");
                        $("#DeleteModal").modal("hide");
                        statusDelete = true;
                    }
                    else {
                        statusDelete = false;
                        displayMessages(2, "Xóa thất bại");
                    }
                }
            });
            if (statusDelete) {
                // Lặp qua từng hàng
                table.rows().every(function () {
                    var rowData = this.data();
                    // Kiểm tra xem rowData có tồn tại không trước khi truy cập thuộc tính
                    if (rowData && rowData.maPhieuThuChi) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.maPhieuThuChi + '"]');
                        if (checkbox.prop('checked')) {
                            // Xóa hàng nếu checkbox được kiểm tra
                            this.remove();
                        }
                    }
                });
                // Vẽ lại DataTables sau khi xóa các hàng
                table.draw();
            }
        }
    });

    $('#btnPhieuThuChi_TimKiem').click(function () {
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


    //============================CB========================
    $('input[type="checkbox"]').change(function () {
        var groupName = $(this).attr('name');
        var checkedBox = $(this);

        $('input[name="' + groupName + '"]').not(checkedBox).prop('checked', false);
    });
});