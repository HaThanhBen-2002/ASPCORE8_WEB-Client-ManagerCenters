var selectedItems = [];
function GetLopData() {
    return {
        MaLop: $('#lop_MaLop').val(),
        TenLop: $('#lop_TenLop').val(),
        MaNhanVien: $('#lop_MaNhanVien').val(),
        MaTrungTam: $('#lop_MaTrungTam').val(),
        NamHoc: $('#lop_NamHoc').val(),
        HocPhi: $('#lop_HocPhi').val(),
        LichHoc: $('#lop_LichHoc').val(),
        ThongTin: $('#lop_ThongTin').val(),
        NgayBatDau: $('#lop_NgayBatDau').val(),
        NgayKetThuc: $('#lop_NgayKetThuc').val(),
    };
}
// Hàm để cập nhật bảng từ mảng các đối tượng
function updateTable() {
    var tongTien = 0;
    // Đối tượng tạm thời để theo dõi các phần tử đã xuất hiện và số lượng của chúng
    var tempItems = {};
    // Kiểm tra và gộp các phần tử trùng lặp
    selectedItems.forEach(function (item) {
        var key = item.ten + item.gia; // Tạo khóa dựa trên các thuộc tính ten và gia
        var soLuongInt = parseInt(item.soLuong); // Chuyển đổi kiểu số lượng thành số nguyên
        if (tempItems[key]) {
            // Nếu phần tử đã tồn tại trong tempItems, cập nhật lại số lượng và tính lại tổng giá
            tempItems[key].soLuong += soLuongInt;
            tempItems[key].tongGia = formatToVND(tempItems[key].soLuong * parseVNDToNumber(tempItems[key].gia));
        } else {
            // Nếu phần tử chưa tồn tại trong tempItems, thêm vào với số lượng hiện tại, tính tổng giá và giữ lại donViTinh
            tempItems[key] = {
                ten: item.ten,
                gia: item.gia,
                soLuong: soLuongInt,
                tongGia: formatToVND(soLuongInt * parseVNDToNumber(item.gia)),
                donViTinh: item.donViTinh // Giữ lại donViTinh
            };
        }
    });
    // Chuyển đổi tempItems trở lại thành mảng selectedItems
    selectedItems = Object.values(tempItems).map(function (value) {
        return value;
    });
    // Tính tổng tiền của hóa đơn
    selectedItems.forEach(function (item) {
        tongTien += parseVNDToNumber(item.tongGia)
        $("#phieuThuChiTongTien").text(formatToVND(tongTien));
    });
    // Xóa các hàng hiện tại trong bảng trừ tiêu đề
    $('#myTableHoaDon tbody').empty();
    if (selectedItems != null) {
        // Lặp qua từng đối tượng trong mảng selectedItems và thêm vào bảng
        selectedItems.forEach(function (item, index) {
            var row = '<tr>';
            row += '<td width="30%" class="px-1">' + item.ten + '</td>';
            row += '<td class="px-1">' + item.gia + '/' + item.donViTinh + '</td>';
            row += '<td width="10%" class="px-1"><input type="number" class="quantity-input w-100 rounded-1" value="' + item.soLuong + '" min="1" data-index="' + index + '"/></td>';
            row += '<td class="px-1" data-tonggia="' + item.tongGia + '">' + item.tongGia + '</td>'; // Thêm data-tonggia vào để lưu trữ tổng giá ban đầu
            row += '</tr>';
            $('#myTableHoaDon tbody').append(row);
        });
    }

    // Thêm Id cho mỗi button trong hàng, chứa chỉ mục của hàng
    $('#myTableHoaDon tbody tr').each(function (index) {
        var rowIndex = index; // Lấy chỉ mục của hàng
        $(this).append('<td width="10%" class="px-1"><button onclick="DeleteItem(' + rowIndex +')" class="btn btn-xs btn-danger">Xóa</button></td>');
    });

}
function DeleteItem(index) {
    // Xóa phần tử tương ứng trong danh sách selectedItems
    selectedItems.splice(index, 1);
    // Cập nhật lại bảng
    updateTable();
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
    $('#phieuThuChi_MaTrungTam').empty();
    $('#phieuThuChi_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#phieuThuChi_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
}

async function CbbNhaCungCapByMaTrungTam() {
    let trungTam = $('#phieuThuChi_MaTrungTam').val();
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
        // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
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
async function CbbNhanVienByMaTrungTam() {
    let trungTam = $('#phieuThuChi_MaTrungTam').val();
    if (CheckIsNull(trungTam)!=true) {

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
        $('#lop_MaNhanVien').empty();
        $('#lop_MaNhanVien').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
        $.each(nhanViens, function (index, item) {
            $('#lop_MaNhanVien').append($('<option>', {
                value: item.maNhanVien,
                text: item.tenNhanVien
            }));
        });
    }
    else {
        $('#lop_MaNhanVien').empty();
        $('#lop_MaNhanVien').append($('<option>', {
            value: 0,
            text: "Tất cả"
        }));
    }
}

$(document).ready(async function () {
    await CapNhatToken();
    let thanhToan = false;

    // ============================================== TABLE ===============================================
    // Gán sự kiện change cho mỗi input
    // Gán sự kiện input cho mỗi input
    // Sử dụng delegation events để gán sự kiện input
    $('#myTableHoaDon').on('input', '.quantity-input', function () {
        let soLuong = parseInt($(this).val()); // Lấy giá trị mới của input
        let indexItem = $(this).data('index'); // Lấy giá của sản phẩm
        let tongGia = formatToVND(soLuong * parseVNDToNumber(selectedItems[indexItem].gia)); // Tính tổng giá mới
        selectedItems[indexItem].soLuong = soLuong;
        selectedItems[indexItem.tongGia] = tongGia;
        updateTable(); // Cập nhật lại bảng
    });

    // ============================================== CBB ===============================================
    CbbTrungTam();
    $('#phieuThuChi_MaTrungTam').change(function () {
        CbbNhaCungCapByMaTrungTam();
        CbbNhanVienByMaTrungTam();
    });
    // ============================================== BUTTON ===============================================
    // Sản phẩm
    $("#btnResetChiTietPhieuThuChiSanPham").click(function () {

        $('#sanPham_MaSanPham').val(null);
        $('#sanPham_TenSanPham').val(null);
        $('#sanPham_ThongTin').val(null);
        $('#sanPham_Gia').val(null);
        $('#sanPham_HanSuDung').val("Tất cả");
        $('#sanPham_LoaiSanPham').val("Tất cả");
        $('#sanPham_MaNhaCungCap').val(0);

        $('#checkAllSanPham').prop('checked', false);
        var isChecked = $(this).prop('checked');
        if (isChecked) {
            $('#myTableSanPham input[type="checkbox"]').each(function () {
                if (!$(this).hasClass('form-check-input')) {
                    $(this).prop('checked', true);
                }
            });
        } else {
            $('#myTableSanPham input[type="checkbox"]').each(function () {
                if (!$(this).hasClass('form-check-input')) {
                    $(this).prop('checked', false);
                }
            });
        }
    });
    $("#btnCreateChiTietPhieuThuChiSanPham").click(function () {
        $('#myTableSanPham tbody tr').each(function () {
            var checkbox = $(this).find('.checkbox');
            if (checkbox.prop('checked')) {
                var tenSanPham = $(this).find('td:nth-child(2)').text();
                var gia = $(this).find('td:nth-child(3)').text();
                var soLuong = $(this).find('.quantity-input').val();
                selectedItems.push({
                    ten: tenSanPham,
                    gia: gia,
                    soLuong: soLuong,
                    donViTinh: "sp",
                    tongGia: formatToVND(soLuong * parseVNDToNumber(gia))
                });

            }
        });
        updateTable();
    });
    $("#btnSearchChiTietPhieuThuChiSanPham").click(async function () {
        await CapNhatToken();
        let sanPham = {
            MaSanPham: $('#sanPham_MaSanPham').val(),
            TenSanPham: $('#sanPham_TenSanPham').val(),
            ThongTin: $('#sanPham_ThongTin').val(),
            Gia: $('#sanPham_Gia').val(),
            HanSuDung: $('#sanPham_HanSuDung').val(),
            LoaiSanPham: $('#sanPham_LoaiSanPham').val(),
            MaNhaCungCap: $('#sanPham_MaNhaCungCap').val(),
            MaTrungTam: $('#phieuThuChi_MaTrungTam').val()
        };

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
        if ($.fn.DataTable.isDataTable('#myTableSanPham')) {
            $('#myTableSanPham').DataTable().destroy();
        }
        // Table Object
        $('#myTableSanPham').DataTable({
            serverSide: true,
            scrollY: 300,
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
                        return '<input data-checkbox-id="' + data + '" type="checkbox" class="checkbox"/>';
                    }
                },
                {
                    data: "tenSanPham"
                },
                {
                    data: "gia",
                    render: function (data, type, row) {
                        return formatToVND(data);
                    }
                },
                {
                    data: null,
                    render: function (data, type, row) {
                        return '<input type="number" class="quantity-input w-100 rounded-1" value="1" min="1" />';
                    }
                }
            ],
            initComplete: function () {
                // Thêm sự kiện cho việc thay đổi số lượng row trên trang
                $('#myTableSanPham').on('length.dt', function (e, settings, len) {
                    // Gọi hàm CapNhatToken() khi có sự thay đổi
                    CapNhatToken().then(() => {
                    }).catch(error => {
                        console.error("Cập nhật token thất bại:", error);
                    });
                });
            }
        });
        // Event pageChange"myTable"
        $('#myTableSanPham').on('page.dt', function () {
            // Thực hiện các hành động khi trang của DataTable thay đổi
            $('#checkAllSanPham').prop('checked', false);
        });
        // Event checkbox "Check All"
        $('#checkAllSanPham').change(function () {
            var isChecked = $(this).prop('checked');
            if (isChecked) {
                $('#myTableSanPham input[type="checkbox"]').each(function () {
                    if (!$(this).hasClass('form-check-input')) {
                        $(this).prop('checked', true);
                    }
                });
            } else {
                $('#myTableSanPham input[type="checkbox"]').each(function () {
                    if (!$(this).hasClass('form-check-input')) {
                        $(this).prop('checked', false);
                    }
                });
            }
        });

    });

    // Dịch vụ
    $("#btnResetChiTietPhieuThuChiDichVu").click(function () {

        $('#dichVu_MaDichVu').val(null);
        $('#dichVu_TenDichVu').val(null);
        $('#dichVu_ThongTin').val(null);
        $('#dichVu_Gia').val(null);

        $('#checkAllDichVu').prop('checked', false);
        var isChecked = $(this).prop('checked');
        if (isChecked) {
            $('#myTableDichVu input[type="checkbox"]').each(function () {
                if (!$(this).hasClass('form-check-input')) {
                    $(this).prop('checked', true);
                }
            });
        } else {
            $('#myTableDichVu input[type="checkbox"]').each(function () {
                if (!$(this).hasClass('form-check-input')) {
                    $(this).prop('checked', false);
                }
            });
        }
    });
    $("#btnCreateChiTietPhieuThuChiDichVu").click(function () {
        $('#myTableDichVu tbody tr').each(function () {
            var checkbox = $(this).find('.checkbox');
            if (checkbox.prop('checked')) {
                var tenDichVu = $(this).find('td:nth-child(2)').text();
                var gia = $(this).find('td:nth-child(3)').text();
                var soLuong = $(this).find('.quantity-input').val();
                selectedItems.push({
                    ten: tenDichVu,
                    gia: gia,
                    soLuong: soLuong,
                    donViTinh: "dv",
                    tongGia: formatToVND(soLuong * parseVNDToNumber(gia))
                });
            }
        });
        updateTable();
    });
    $("#btnSearchChiTietPhieuThuChiDichVu").click(async function () {
        await CapNhatToken();

        let dichVu = {
            MaDichVu: $('#dichVu_MaDichVu').val(),
            TenDichVu: $('#dichVu_TenDichVu').val(),
            ThongTin: $('#dichVu_ThongTin').val(),
            Gia: $('#dichVu_Gia').val(),
        };

        
        if ($.fn.DataTable.isDataTable('#myTableDichVu')) {
            $('#myTableDichVu').DataTable().destroy();
        }
        // Table Object
        $('#myTableDichVu').DataTable({
            serverSide: true,
            scrollY: 300,
            searching: false,
            lengthChange: true,
            ordering: false,
            ajax: {
                type: "POST",
                url: "/DichVu/LoadingDataTableView",
                dataType: "json",
                headers: {
                    "Authorization": `Bearer ${getToken()}`
                },
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
                        return '<input data-checkbox-id="' + data + '" type="checkbox" class="checkbox"/>';
                    }
                },
                {
                    data: "tenDichVu"
                },
                {
                    data: "gia",
                    render: function (data, type, row) {
                        return formatToVND(data);
                    }
                },
                {
                    data: null,
                    render: function (data, type, row) {
                        return '<input type="number" class="quantity-input w-100 rounded-1" value="1" min="1" />';
                    }
                }
            ],
            initComplete: function () {
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
        // Event pageChange"myTable"
        $('#myTableDichVu').on('page.dt', function () {
            // Thực hiện các hành động khi trang của DataTable thay đổi
            $('#checkAllDichVu').prop('checked', false);
        });
        // Event checkbox "Check All"
        $('#checkAllDichVu').change(function () {
            var isChecked = $(this).prop('checked');
            if (isChecked) {
                $('#myTableDichVu input[type="checkbox"]').each(function () {
                    if (!$(this).hasClass('form-check-input')) {
                        $(this).prop('checked', true);
                    }
                });
            } else {
                $('#myTableDichVu input[type="checkbox"]').each(function () {
                    if (!$(this).hasClass('form-check-input')) {
                        $(this).prop('checked', false);
                    }
                });
            }
        });

    });

    // Tùy chỉnh
    $("#btnResetChiTietPhieuThuChiTuyChinh").click(function () {
        $('#chiTietPhieuThuChi_TenChiTiet').val(null);
        $('#chiTietPhieuThuChi_SoLuong').val(null);
        $('#chiTietPhieuThuChi_DonViTinh').val(null);
        $('#chiTietPhieuThuChi_Gia').val(null);
        $('#chiTietPhieuThuChi_TongTien').val(null);
    });
    $("#btnCreateChiTietPhieuThuChiTuyChinh").click(function () {
            // Lấy giá trị từ các input
            let tenChiTiet = $('#chiTietPhieuThuChi_TenChiTiet').val();
            let soLuong = $('#chiTietPhieuThuChi_SoLuong').val();
            let donViTinh = $('#chiTietPhieuThuChi_DonViTinh').val();
            let gia = $('#chiTietPhieuThuChi_Gia').val();
            selectedItems.push({
                ten: tenChiTiet,
                gia: formatToVND(gia),
                soLuong: soLuong,
                donViTinh: donViTinh,
                tongGia: formatToVND(soLuong * parseVNDToNumber(gia))
            });
            updateTable();
    });

    // Học phi
    $("#btnResetChiTietPhieuThuChiLop").click(async function () {

        $('#lop_MaLop').val(null);
        $('#lop_TenLop').val(null);
        $('#lop_NamHoc').val(null);
        $('#lop_HocPhi').val(null);
        $('#lop_LichHoc').val(null);
        $('#lop_ThongTin').val(null);
        $('#lop_NgayBatDau').val(null);
        $('#lop_NgayKetThuc').val(null);
        await CbbNhanVienByMaTrungTam();
        $('#lop_MaNhanVien').val(0);

        $('#checkAllLop').prop('checked', false);
        var isChecked = $(this).prop('checked');
        if (isChecked) {
            $('#myTableLop input[type="checkbox"]').each(function () {
                if (!$(this).hasClass('form-check-input')) {
                    $(this).prop('checked', true);
                }
            });
        } else {
            $('#myTableLop input[type="checkbox"]').each(function () {
                if (!$(this).hasClass('form-check-input')) {
                    $(this).prop('checked', false);
                }
            });
        }
    });
    $("#btnCreateChiTietPhieuThuChiLop").click(function () {
        $('#myTableLop tbody tr').each(function () {
            var checkbox = $(this).find('.checkbox');
            if (checkbox.prop('checked')) {
                var tenLop = $(this).find('td:nth-child(2)').text();
                var gia = $(this).find('td:nth-child(3)').text();
                var soLuong = $(this).find('.quantity-input').val();
                selectedItems.push({
                    ten: tenLop,
                    gia: gia,
                    soLuong: soLuong,
                    donViTinh: "dv",
                    tongGia: formatToVND(soLuong * parseVNDToNumber(gia))
                });
            }
        });
        updateTable();
    });
    $("#btnSearchChiTietPhieuThuChiLop").click(async function () {
        await CapNhatToken();

        let lop = {
            MaLop: $('#lop_MaLop').val(),
            TenLop: $('#lop_TenLop').val(),
            MaNhanVien: $('#lop_MaNhanVien').val(),
            MaTrungTam: $('#phieuThuChi_MaTrungTam').val(),
            NamHoc: $('#lop_NamHoc').val(),
            HocPhi: $('#lop_HocPhi').val(),
            LichHoc: $('#lop_LichHoc').val(),
            ThongTin: $('#lop_ThongTin').val(),
            NgayBatDau: $('#lop_NgayBatDau').val(),
            NgayKetThuc: $('#lop_NgayKetThuc').val(),
        };
        if (lop.MaNhanVien == 0) {
            lop.MaNhanVien = null;
        }
        if (lop.MaTrungTam == 0) {
            lop.MaTrungTam = null;
        }
        if ($.fn.DataTable.isDataTable('#myTableLop')) {
            $('#myTableLop').DataTable().destroy();
        }
        // Table Object
        $('#myTableLop').DataTable({
            serverSide: true,
            scrollY: 300,
            searching: false,
            lengthChange: true,
            ordering: false,
            ajax: {
                type: "POST",
                url: "/Lop/LoadingDataTableView",
                dataType: "json",
                headers: {
                    "Authorization": `Bearer ${getToken()}`
                },
                data: { item: lop },
                dataSrc: 'data',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("Authorization", `Bearer ${getToken()}`);
                }
            },
            columns: [
                {
                    data: 'maLop',
                    render: function (data, type, row) {
                        return '<input data-checkbox-id="' + data + '" type="checkbox" class="checkbox"/>';
                    }
                },
                {
                    data: "tenLop"
                },
                {
                    data: "hocPhi",
                    render: function (data, type, row) {
                        return formatToVND(data);
                    }
                },
                {
                    data: null,
                    render: function (data, type, row) {
                        return '<input type="number" class="quantity-input w-100 rounded-1" value="1" min="1" />';
                    }
                }
            ],
            initComplete: function () {
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
        // Event pageChange"myTable"
        $('#myTableLop').on('page.dt', function () {
            // Thực hiện các hành động khi trang của DataTable thay đổi
            $('#checkAllLop').prop('checked', false);
        });
        // Event checkbox "Check All"
        $('#checkAllLop').change(function () {
            var isChecked = $(this).prop('checked');
            if (isChecked) {
                $('#myTableLop input[type="checkbox"]').each(function () {
                    if (!$(this).hasClass('form-check-input')) {
                        $(this).prop('checked', true);
                    }
                });
            } else {
                $('#myTableLop input[type="checkbox"]').each(function () {
                    if (!$(this).hasClass('form-check-input')) {
                        $(this).prop('checked', false);
                    }
                });
            }
        });

    });

    // Create Hóa Đơn
    $("#btnCreatePhieuThuChi").click(async function () {
        let phieuThuChi = {
            MaPhieu: null,
            NgayTao: null,
            CodeHoaDon: null,
            NgayThanhToan: null,
            LoaiPhieu: $('#phieuThuChi_LoaiPhieu').val(),
            TongTien: parseVNDToNumber($('#phieuThuChiTongTien').text()),
            GhiChu: $('#phieuThuChi_GhiChu').val(),
            MaTrungTam: $('#phieuThuChi_MaTrungTam').val(),
            TrangThai: null,
            HinhThucThanhToan: $('#phieuThuChi_HinhThucThanhToan').val(),
            MaNhanVien: null
        };
        if (phieuThuChi.MaTrungTam == "Tất cả" || phieuThuChi.MaTrungTam == 0 || phieuThuChi.LoaiPhieu == "Tất cả" || phieuThuChi.HinhThucThanhToan == "Tất cả") {
            displayMessages(2, "Vui lòng chọn đầy đủ thông tin hóa đơn");
        }
        else {
            var listChiTietHoaDon = [];
            if (selectedItems.length > 0) {
                selectedItems.forEach(function (item) {
                    listChiTietHoaDon.push({
                        MaChiTiet: null,
                        TenChiTiet: item.ten,
                        MaPhieu: null,
                        SoLuong: item.soLuong,
                        DonVi: item.donViTinh,
                        TongTien: parseVNDToNumber(item.tongGia)
                    });
                });
                // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
                phieuThuChi = await PhieuThuChi_Create(phieuThuChi, listChiTietHoaDon, thanhToan);
                if (phieuThuChi != null) {
                    
                    $('#phieuThuChi_MaCodeHoaDon').text("Mã HD: " + phieuThuChi.CodeHoaDon);
                    $('#phieuThuChi_NgayTao').text("Ngày tạo: " + phieuThuChi.NgayTao);
                    $('#phieuThuChi_NgayThanhToan').text("Ngày thanh toán: " + phieuThuChi.NgayThanhToan);


                    // Lưu lại phần hình ảnh
                    var imageHtml = $('#imageDiv').html();

                    // Thay đổi các select box thành dạng text
                    var trungTamText = $('select[name="phieuThuChi_MaTrungTam"] option:selected').text();
                    $('#phieuThuChi_MaTrungTam').replaceWith('<span>' + trungTamText + '</span>');

                    var loaiPhieuText = $('select[name="phieuThuChi_LoaiPhieu"] option:selected').text();
                    $('#phieuThuChi_LoaiPhieu').replaceWith('<span>' + loaiPhieuText + '</span>');

                    var hinhThucThanhToanText = $('select[name="phieuThuChi_HinhThucThanhToan"] option:selected').text();
                    $('#phieuThuChi_HinhThucThanhToan').replaceWith('<span>' + hinhThucThanhToanText + '</span>');

                    // Chuyển phần textarea thành dạng text
                    var ghiChuText = $('#phieuThuChi_GhiChu').val();
                    $('#phieuThuChi_GhiChu').replaceWith('<span>' + ghiChuText + '</span>');

                    // Ẩn checkbox thanh toán
                    $('#showThanhToan').hide();

                    // Thêm lại phần hình ảnh
                    $('#imageDiv').html(imageHtml);

                    // Loại bỏ cột cuối cùng trong bảng
                    $('#myTableHoaDon th:last-child').remove();
                    $('#myTableHoaDon td:last-child').remove();

                    // In hóa đơn
                    var invoiceContent = $('#printableDiv').html();
                    var originalContent = $('body').html();
                    $('body').empty().html(invoiceContent);
                    window.print();
                    window.location.href = "/Admin/PhieuThuChi/ChiTietHoaDon";
                    displayMessages(1, "Tạo hóa đơn thành công");
                    
                }
                else {
                    displayMessages(3, "Tạo hóa đơn thất bại");

                }

            }
            else {
                displayMessages(2, "Hóa đơn không có nội dung");
            }
        }
    });

    //========================= CHECK BOX================
    $('#thanhToan').change(function () {
        if ($(this).is(':checked')) {
            thanhToan = true;
            $('#phieuThuChi_TrangThai').text("Trạng thái: Đã thanh toán");
            
        } else {
            thanhToan = false;
            $('#phieuThuChi_TrangThai').text("Trạng thái: Chưa thanh toán");
        }
    });
});