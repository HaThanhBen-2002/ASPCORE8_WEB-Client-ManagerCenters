
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

function CreateLop() {
    let item = GetLopData();
    // Kiểm tra tính hợp lệ
    if (isValidLop(item)) {
        let status = false;
        item.MaLop = null;
        // Gửi dữ liệu thông qua AJAX để thêm vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/Lop/Create",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function UpdateLop() {
    let item = GetLopData();
    // Kiểm tra tính hợp lệ
    if (isValidLop(item) && CheckIsNull(item.MaLop)!=true) {
        let status = false;
        // Gửi dữ liệu thông qua AJAX để cập nhật vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/Lop/Update",
            async: false,
            data: { item: item },
            success: function (data) {
                status = data.isSuccess;
            }
        });
        return status;
    }
}

function CbbTrungTam() {
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
    $.ajax({
        type: "POST",
        url: "/Admin/TrungTam/SearchName",
        data: { item: trungTam },
        success: function (data) {
            $('#sanPham_MaTrungTam').empty();
            $('#sanPham_MaTrungTam').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
            $.each(data.$values, function (index, item) {
                $('#sanPham_MaTrungTam').append($('<option>', {
                    value: item.maTrungTam,
                    text: item.tenTrungTam
                }));
            });
        }
    });

}
function CbbNhaCungCapByMaTrungTam() {
    let trungTam = $('#sanPham_MaTrungTam').val();
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

        $.ajax({
            type: "POST",
            url: "/Admin/NhaCungCap/SearchName",
            async: false,
            data: { item: nhaCungCap },
            success: function (data) {
                $('#sanPham_MaNhaCungCap').empty();
                $('#sanPham_MaNhaCungCap').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
                $.each(data.$values, function (index, item) {
                    $('#sanPham_MaNhaCungCap').append($('<option>', {
                        value: item.maNhaCungCap,
                        text: item.tenNhaCungCap
                    }));
                });
            }
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

function CbbNhanVienByMaTrungTam() {
    let trungTam = $('#lop_MaTrungTam').val();
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
        $.ajax({
            type: "POST",
            url: "/Admin/NhanVien/SearchName",
            async: false,
            data: { item: nhanVien },
            success: function (data) {
                $('#lop_MaNhanVien').empty();
                $('#lop_MaNhanVien').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                // Duyệt qua mảng data.$values và thêm option cho mỗi phần tử
                $.each(data.$values, function (index, item) {
                    $('#lop_MaNhanVien').append($('<option>', {
                        value: item.maNhanVien,
                        text: item.tenNhanVien
                    }));
                });
            }
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

$(document).ready(function () {
    // ============================================== TABLE ===============================================


    // Loading Data Table
   

    // ============================================== CBB ===============================================
    CbbTrungTam();
    CbbNhaCungCapByMaTrungTam();
    $('#sanPham_MaTrungTam').change(function () {
        CbbNhaCungCapByMaTrungTam();
    });
    // ============================================== BUTTON ===============================================
    $("#btnSearchChiTietPhieuThuChiSanPham").click(function () {

        let sanPham = {
            MaSanPham: $('#sanPham_MaSanPham').val(),
            TenSanPham: $('#sanPham_TenSanPham').val(),
            ThongTin: $('#sanPham_ThongTin').val(),
            Gia: $('#sanPham_Gia').val(),
            HanSuDung: $('#sanPham_HanSuDung').val(),
            LoaiSanPham: $('#sanPham_LoaiSanPham').val(),
            MaNhaCungCap: $('#sanPham_MaNhaCungCap').val(),
            MaTrungTam: $('#sanPham_MaTrungTam').val()
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
            scrollY: 400,
            searching: false,
            lengthChange: true,
            ordering: false,
            ajax: {
                type: "POST",
                url: "/Admin/SanPham/LoadingDataTableView",
                dataType: "json",
                data: { item: sanPham },
                dataSrc: 'data'
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
            ]
        });
        // Event pageChange"myTable"
        $('#myTableSanPham').on('page.dt', function () {
            // Thực hiện các hành động khi trang của DataTable thay đổi
            $('#checkAll').prop('checked', false);
        });
        // Event checkbox "Check All"
        $('#checkAllSanPham').change(function () {
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
    });
});