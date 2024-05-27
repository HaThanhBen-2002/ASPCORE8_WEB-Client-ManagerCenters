var TatCaDichVu = []; // Lưu thông tin cơ sở của all dịch vụ theo trung tâm (idText, idDichVu, tên dịch vụ, tổng số lượt sử dụng)
var DichVuCanThongKe = []; //Lưu danh sách những dịch vụ cần thống kê (idText, idDichVu, tên dịch vụ, tổng số lượt sử dụng)
var TrangThaiSuDungCanThongKe = [];// Lưu danh sách trạng thái cần thống kê (tên trạng thái)
var DanhSachSuDungDichVuDaThongKe = [];// Lưu danh sách trạng thái cần thống kê (tên trạng thái)
var table;



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
    $('#BCTK_MaTrungTam').empty();
    $('#BCTK_MaTrungTam').append($('<option>', {
        value: 0,
        text: "Tất cả"
    }));
    $.each(trungTams, function (index, item) {
        $('#BCTK_MaTrungTam').append($('<option>', {
            value: item.maTrungTam,
            text: item.tenTrungTam
        }));
    });
}
//=========== Xử lý mục CHỌN DỊCH VỤ
async function TatCaDichVu_ByTrungTam() {
    let trungTam = $('#BCTK_MaTrungTam').val();
    if (trungTam == 0) { trungTam = null; };
    let danhSachDichVu = await DichVu_SearchName(null);
    TatCaDichVu = [];

    // Sử dụng for...of để lặp qua danh sách và đợi mỗi lời gọi async hoàn thành trước khi tiếp tục
    for (let item of danhSachDichVu) {
        let suDungDichVu = {
            MaSuDungDichVu: null,
            TenSuDungDichVu: null,
            MaDichVu: item.maDichVu,
            MaHocSinh: null,
            MaTrungTam: trungTam,
            TrangThai: null,
            NgayBatDau: null,
            NgayKetThuc: null
        };
        let _countSDDV = await SuDungDichVu_SearchCount(suDungDichVu);
        var dichVu = {
            id: "tatCaDichVu" + item.maDichVu,
            value: item.maDichVu,
            ten: item.tenDichVu,
            countSDDV: _countSDDV
        };
        TatCaDichVu.push(dichVu);
    }
}
function BCTK_TatCaDichVu_ThemMuc(id, ten, giaTri) {
    // Tạo các phần tử HTML
    var rowDiv = $('<div>', { class: 'row' });
    var colAutoDiv = $('<div>', { class: 'w-px-20 col-auto' });
    var colDiv = $('<div>', { class: 'col' });

    var input = $('<input>', {
        type: 'checkbox',
        id: id,
        name: 'tatCaDichVu',
        value: giaTri
    });

    var label = $('<label>', {
        for: id,
        text: ten
    });
    // Gắn các phần tử vào nhau
    colAutoDiv.append(input);
    colDiv.append(label);
    rowDiv.append(colAutoDiv).append(colDiv);
    // Thêm mục mới vào form
    $('#BCTK_TatCaDichVu').append(rowDiv);
}
function BCTK_TatCaDichVu_Load() {
    $('#BCTK_TatCaDichVu').empty();
    TatCaDichVu.sort(function (a, b) {
        return b.countSDDV - a.countSDDV;
    });
    BCTK_TatCaDichVu_ThemMuc("tatCaDichVu0", "Tất cả", 0);
    TatCaDichVu.forEach(function (item) {
        let _ten = "(" + item.countSDDV + ") " + item.ten;
        BCTK_TatCaDichVu_ThemMuc(item.id, _ten, item.value);
    });
    $('#tatCaDichVu0').on('change', function () {
        if ($(this).is(':checked')) {
            // Checkbox được chọn
            // Chọn tất cả các input checkbox trong form có id là BCTK_TatCaDichVu và thiết lập trạng thái checked của chúng
            $('#BCTK_TatCaDichVu input[type="checkbox"]').prop('checked', true); // true để chọn
        } else {
            // Checkbox không được chọn
            // Chọn tất cả các input checkbox trong form có id là BCTK_TatCaDichVu và thiết lập trạng thái checked của chúng
            $('#BCTK_TatCaDichVu input[type="checkbox"]').prop('checked', false); //false để bỏ chọn
        }
    });
}
function BCTK_TatCaDichVu_Check() {
    var dichVuThongKe = $('#BCTK_TatCaDichVu input:checked').map(function () {
        return $(this).val();
    }).get();
    DichVuCanThongKe = [];
    if (dichVuThongKe.length > 0) {
        dichVuThongKe.forEach(function (item) {
            TatCaDichVu.forEach(function (item1) {
                if (item == item1.value) {
                    DichVuCanThongKe.push(item1);
                }
            });
        });
    }
    else {
        DichVuCanThongKe = [];
    }
}
function BCTK_TrangThaiSuDungDichVu_Check() {
    var trangThaiThongKe = $('#BCTK_TrangThaiSuDungDichVu input:checked').map(function () {
        return $(this).val();
    }).get();
    TrangThaiSuDungCanThongKe = [];
    if (trangThaiThongKe.length > 0) {
        trangThaiThongKe.forEach(function (item) {
            if (item != "Tất cả") {
                TrangThaiSuDungCanThongKe.push(item);
            }
        });
    }
    else {
        TrangThaiSuDungCanThongKe = [];
    }
}
//=========== Xử lý thống kê
async function ThongKe() {
    let trungTam = $('#BCTK_MaTrungTam').val();
    if (trungTam == 0) { trungTam = null };
    DanhSachSuDungDichVuDaThongKe = [];

    // Duyệt Dịch vụ cần thống kê
    for (let dichVu of DichVuCanThongKe) {
        //Nếu trạng thái == 6 thì lấy tất cả lượt sử dụng của dịch vụ
        //Ngược lại thì chỉ lấy nhưng trạng thái cần thống kê
        if (TrangThaiSuDungCanThongKe.length != 6) {
            for (let trangThai of TrangThaiSuDungCanThongKe) {
                var suDungDichVu = {
                    MaSuDungDichVu: null,
                    TenSuDungDichVu: null,
                    MaDichVu: dichVu.value,
                    MaHocSinh: null,
                    MaTrungTam: trungTam,
                    TrangThai: trangThai,
                    NgayBatDau: null,
                    NgayKetThuc: null
                };
                let listSuDungDichVu = await SuDungDichVu_Search(suDungDichVu);
                if (listSuDungDichVu.length != 0) {
                    listSuDungDichVu.forEach(function (luotSuDung) {
                        DanhSachSuDungDichVuDaThongKe.push(luotSuDung);
                    });
                }
            }
        } else {
            var suDungDichVu = {
                MaSuDungDichVu: null,
                TenSuDungDichVu: null,
                MaDichVu: dichVu.value,
                MaHocSinh: null,
                MaTrungTam: trungTam,
                TrangThai: null,
                NgayBatDau: null,
                NgayKetThuc: null
            };
            let listSuDungDichVu = await SuDungDichVu_Search(suDungDichVu);
            if (listSuDungDichVu.length != 0) {
                listSuDungDichVu.forEach(function (luotSuDung) {
                    DanhSachSuDungDichVuDaThongKe.push(luotSuDung);
                });
            }
        }
    }
}

//============ Biểu đồ Thống kê lượt sử dụng của từng dịch vụ
function TaoBieuDoDichVuLuotSuDung() {
    var results = [];
    var formatted = [];
    DichVuCanThongKe.forEach( function (dichVu) {
        var countt = 0;
        DanhSachSuDungDichVuDaThongKe.forEach( function (dichVuTK) {
            if (dichVu.value == dichVuTK.maDichVu) {
                countt += 1;
                tenDichVu = dichVuTK.tenDichVu;
            }
        });
        results.push(countt);
        formatted.push(dichVu.ten + " (" + countt + ") lượt");
    });

    let options = {
        series: [{
            data: results,
            name: "Tổng lượt sử dụng dịch vụ"
        }],
        chart: {
            type: 'bar',
            height: 200
        },
        plotOptions: {
            bar: {
                borderRadius: 4,
                horizontal: true,
            }
        },
        dataLabels: {
            enabled: false
        },
        xaxis: {
            categories: formatted,//
        }
    };
    return options;
}
let chartDichVuLuotSuDung;
async function CreateChartDichVuLuotSuDung() {
    if (chartDichVuLuotSuDung) {
        chartDichVuLuotSuDung.destroy();
    }
    // Khởi tạo biểu đồ mới
    chartDichVuLuotSuDung = new ApexCharts($("#chartDichVuLuotSuDung")[0], TaoBieuDoDichVuLuotSuDung());
    chartDichVuLuotSuDung.render();
}

//============ Biểu đồ Thống kê trạng thái sử dụng dịch vụ
function TaoBieuDoSuDungDichVuTrangThai() {

    var dataChart = [];
    var textData = [];

    var lbTongLuotHetHan = 0;
    var lbTongLuotChoThanhToan = 0;
    var lbTongLuotCanGiaHan = 0;
    var lbTongLuotDaHuy = 0;

    TrangThaiSuDungCanThongKe.forEach(function (trangThai) {
        var countt = 0;
        DanhSachSuDungDichVuDaThongKe.forEach(function (dichVuTK) {
            if (trangThai == dichVuTK.trangThai) {
                countt += 1;
            }
        });
        if (trangThai == "Hết hạn") {
            lbTongLuotHetHan = countt;
        }
        else if (trangThai == "Chờ thanh toán") {
            lbTongLuotChoThanhToan = countt;
        }
        else if (trangThai == "Gần hết hạn") {
            lbTongLuotCanGiaHan = countt;
        }
        else if (trangThai == "Đã hủy") {
            lbTongLuotDaHuy = countt;
        }
        dataChart.push(countt);
        textData.push(trangThai + " (" + countt + ") lượt")
    });

    $('#lbTongLuotHetHan').text("Thống kê hết hạn: " + lbTongLuotHetHan);
    $('#lbTongLuotChoThanhToan').text("Thống kê chờ thanh toán: " + lbTongLuotChoThanhToan);
    $('#lbTongLuotCanGiaHan').text("Thống kê cần gia hạn: " + lbTongLuotCanGiaHan);
    $('#lbTongLuotDaHuy').text("Thống kê đã hủy: " + lbTongLuotDaHuy);
    var options = {
        series: dataChart,
        labels: textData,
        chart: {
            type: 'polarArea',
        },
        stroke: {
            colors: ['#fff']
        },
        fill: {
            opacity: 0.8
        },
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };
    return options;
}
let chartSuDungDichVuTrangThai;
async function CreateChartSuDungDichVuTrangThai() {
    if (chartSuDungDichVuTrangThai) {
        chartSuDungDichVuTrangThai.destroy();
    }
    // Khởi tạo biểu đồ mới
    chartSuDungDichVuTrangThai = new ApexCharts($("#chartSuDungDichVuTrangThai")[0], TaoBieuDoSuDungDichVuTrangThai());
    chartSuDungDichVuTrangThai.render();
}

//============ Thống kê thông tin phụ
async function ThongKeKhac() {

    var lbTongLuot = DanhSachSuDungDichVuDaThongKe.length;

    var lbTongLuotHeThong = await SuDungDichVu_SearchCount(null);

    let trungTam = $('#BCTK_MaTrungTam').val();
    if (trungTam == 0) { trungTam = null; };
    let suDungDichVuTrungTam = {
        MaSuDungDichVu: null,
        TenSuDungDichVu: null,
        MaDichVu: null,
        MaHocSinh: null,
        MaTrungTam: trungTam,
        TrangThai: null,
        NgayBatDau: null,
        NgayKetThuc: null
    };
    var lbTongLuotTrungTam = await SuDungDichVu_SearchCount(suDungDichVuTrungTam);
    $('#lbTongLuot').text("Tổng lượt thống kê: " + lbTongLuot);
    $('#lbTongLuotTrungTam').text("Tổng của trung tâm: " + lbTongLuotTrungTam);
    $('#lbTongLuotHeThong').text("Tổng trên hệ thống: " + lbTongLuotHeThong);
    // Clear old data
    table.clear();

    // Add new data
    table.rows.add(DanhSachSuDungDichVuDaThongKe);

    // Redraw the table
    table.draw();
}



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
$(document).ready(async function () {
    await CapNhatToken();

    //=============================== CBB ===================================
    CbbTrungTam();
    $('#BCTK_MaTrungTam').change(async function () {
        //Xữ lý khi thay đổi Trung Tâm
        await TatCaDichVu_ByTrungTam();
        BCTK_TatCaDichVu_Load();
        $('#tatCaDichVu0').prop('checked', true);
        $('#BCTK_TatCaDichVu input[type="checkbox"]').prop('checked', true);
    });
    //=============================== LoadData ===================================
    await TatCaDichVu_ByTrungTam();
    BCTK_TatCaDichVu_Load();
    //=============================== CheckBox ===================================
    $('#trangThai0').change(function () {
        // Kiểm tra trạng thái mới của checkbox
        if ($(this).is(':checked')) {
            // Checkbox được chọn
            // Chọn tất cả các input checkbox trong form có id là BCTK_TatCaDichVu và thiết lập trạng thái checked của chúng
            $('#BCTK_TrangThaiSuDungDichVu input[type="checkbox"]').prop('checked', true); // true để chọn
        } else {
            // Checkbox không được chọn
            // Chọn tất cả các input checkbox trong form có id là BCTK_TatCaDichVu và thiết lập trạng thái checked của chúng
            $('#BCTK_TrangThaiSuDungDichVu input[type="checkbox"]').prop('checked', false); //false để bỏ chọn
        }
    });
    $('#tatCaDichVu0').prop('checked', true);
    $('#BCTK_TatCaDichVu input[type="checkbox"]').prop('checked', true);
    $('#trangThai0').prop('checked', true);
    $('#BCTK_TrangThaiSuDungDichVu input[type="checkbox"]').prop('checked', true);
    //=============================== BUTTON ===================================
    $('#btnChonDichVu').click(async function () {
        BCTK_TatCaDichVu_Check();
        BCTK_TrangThaiSuDungDichVu_Check();
        await ThongKe();
        CreateChartDichVuLuotSuDung();
        CreateChartSuDungDichVuTrangThai();
        ThongKeKhac();
    });
    BCTK_TatCaDichVu_Check();
    BCTK_TrangThaiSuDungDichVu_Check();
    await ThongKe();
    CreateChartDichVuLuotSuDung();
    CreateChartSuDungDichVuTrangThai();
    ThongKeKhac();

    $('#myTable').DataTable({
        serverSide: false,
        scrollY: 400,
        searching: false,
        lengthChange: true,
        ordering: false,
        data: DanhSachSuDungDichVuDaThongKe,
        columns: [
            { data: "tenSuDungDichVu" },
            { data: "trangThai" },
            { data: "ngayBatDau" },
            { data: "ngayKetThuc" },
            {
                data: 'ngayKetThuc',
                title: 'Số Ngày Sử Dụng',
                render: function (data) {
                    return SoNgaySuDung(data);
                }
            }
        ],
        dom: 'Bfrtip', // Thêm các nút vào bảng
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        initComplete: function () {
            // Thêm CSS vào các nút
            var buttons = $('.dt-buttons').find('button');
            buttons.css({
                'height': '25px',
                'line-height': '25px',
                'padding': '0 15px'
            });
        }
    });
    table = $('#myTable').DataTable();

});