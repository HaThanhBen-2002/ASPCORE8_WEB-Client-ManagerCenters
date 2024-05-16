//===== Thống kê số lượng ALL ===== Return number
async function TKSL_TrungTam() {
    let trungTam = await TrungTam_SearchCount();
    return trungTam;
}
async function TKSL_DichVu() {
    try {
        let dichVu = await DichVu_SearchCount();
        return dichVu;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKSL_SanPham(maTrungTam) {
    try {
        var sp = {
            MaSanPham: null,
            TenSanPham: null,
            ThongTin: null,
            LoaiSanPham: null,
            HanSuDung: null,
            MaNhaCungCap: null,
            MaTrungTam: maTrungTam,
            Gia: null
        };

        let sanPham = await SanPham_SearchCount(sp);
        return sanPham;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKSL_HoaDon(maTrungTam) {
    try {
        let hd = {
            MaPhieu: null,
            NgayTao: null,
            CodeHoaDon: null,
            NgayThanhToan: null,
            LoaiPhieu: null,
            TongTien: null,
            GhiChu: null,
            MaTrungTam: maTrungTam,
            TrangThai: null,
            HinhThucThanhToan: null,
            MaNhanVien: null
        };

        let hoaDon = await PhieuThuChi_SearchCount(hd);
        return hoaDon;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKSL_NhanVien(maTrungTam) {
    try {
        var nv = {
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
            MaTrungTam: maTrungTam,
            MaTaiKhoan: null,
            LoaiNhanVien: null,
            PhongBan: null,
            Luong: null,
            NganHang: null,
            SoTaiKhoan: null,
            DanToc: null,
            TonGiao: null
        };
        let nhanVien = await NhanVien_SearchCount(nv);
        return nhanVien;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKSL_NhaCungCap(maTrungTam) {
    try {
        var ncc = {
            MaNhaCungCap: null,
            TenNhaCungCap: null,
            GioiThieu: null,
            Email: null,
            SoDienThoai: null,
            NganHang: null,
            SoTaiKhoan: null,
            MaSoThue: null,
            MaTrungTam: maTrungTam
        };
        let nhaCungCap = await NhaCungCap_SearchCount(ncc);
        return nhaCungCap;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKSL_MonHoc() {
    try {
        let monHoc = await MonHoc_SearchCount();
        return monHoc;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKSL_Lop(maTrungTam) {
    try {
        var l = {
            MaLop: null,
            TenLop: null,
            MaNhanVien: null,
            MaTrungTam: maTrungTam,
            NamHoc: null,
            HocPhi: null,
            LichHoc: null,
            ThongTin: null,
            NgayBatDau: null,
            NgayKetThuc: null
        };
        let lop = await Lop_SearchCount(l);
        return lop;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKSL_KetQua(maTrungTam) {
    try {
        let kq = {
            MaKetQua: null,
            TenKetQua: null,
            MaHocSinh: null,
            MaMonHoc: null,
            Diem: null,
            XepLoai: null,
            NgayKiemTra: null,
            TrangThai: null,
            MaNhanVien: null,
            MaTrungTam: maTrungTam
        };

        let ketQua = await KetQua_SearchCount(kq);
        return ketQua;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKSL_HocSinh(maTrungTam) {
    try {
        var hs = {
            MaHocSinh: null,
            TenHocSinh: null,
            NgaySinh: null,
            GioiTinh: null,
            MaLop: null,
            MaTrungTam: maTrungTam,
            ThongTin: null,
            HinhAnh: null,
            DiaChi: null,
            ChieuCao: null,
            CanNang: null,
            TinhTrangRang: null,
            TinhTrangMat: null,
            Bmi: null,
            TinhTrangTamLy: null,
            ChucNangCoThe: null,
            DanhGiaSucKhoe: null,
            Cccdcha: null,
            Cccdme: null,
            TenCha: null,
            TenMe: null,
            NgaySinhCha: null,
            NgaySinhMe: null,
            SoDienThoaiCha: null,
            SoDienThoaiMe: null,
            EmailCha: null,
            EmailMe: null,
            NgheNghiepCha: null,
            NgheNghiepMe: null
        };

        let hocSinh = await HocSinh_SearchCount(hs);
        return hocSinh;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKT_HoaDon(maTrungTam, thangNam) {
    try {
        // Object Search
        let phieuThuChiDoanhThu = {
            MaPhieu: null,
            NgayTao: null,
            CodeHoaDon: null,
            NgayThanhToan: thangNam,
            LoaiPhieu: null,
            TongTien: null,
            GhiChu: null,
            MaTrungTam: maTrungTam,
            TrangThai: null,
            HinhThucThanhToan: null,
            MaNhanVien: null
        };
        let thu = await PhieuThuChi_HoaDonThuThang(phieuThuChiDoanhThu);
        return thu;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKC_HoaDon(maTrungTam, thangNam) {
    try {
        // Object Search
        let phieuThuChiDoanhThu = {
            MaPhieu: null,
            NgayTao: null,
            CodeHoaDon: null,
            NgayThanhToan: thangNam,
            LoaiPhieu: null,
            TongTien: null,
            GhiChu: null,
            MaTrungTam: maTrungTam,
            TrangThai: null,
            HinhThucThanhToan: null,
            MaNhanVien: null
        };

        let chi = await PhieuThuChi_HoaDonChiThang(phieuThuChiDoanhThu);
        return chi;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}
async function TKDT_HoaDon(maTrungTam, thangNam) {
    try {
        let thu = await TKT_HoaDon(maTrungTam, thangNam);
        let chi = await TKC_HoaDon(maTrungTam, thangNam);
        return (thu - chi);
    } catch (error) {
        console.error("Lỗi khi tính toán doanh thu:", error);
        return 0; // hoặc trả về giá trị mặc định khác nếu cần
    }
}

//===== Thống kê số lượng By Object ===== Return number
async function TKSL_TrungTam_Search(trungTam) {
    try {
        let trungTamCount = await TrungTam_SearchCount(trungTam);
        return trungTamCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu TrungTam:", error);
        return 0;
    }
}
async function TKSL_DichVu_Search(dichVu) {
    try {
        let dichVuCount = await DichVu_SearchCount(dichVu);
        return dichVuCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu DichVu:", error);
        return 0;
    }
}
async function TKSL_SanPham_Search(sanPham) {
    try {
        let sanPhamCount =  await SanPham_SearchCount(sanPham);
        return sanPhamCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu SanPham:", error);
        return 0;
    }
}
async function TKSL_HoaDon_Search(hoaDon) {
    try {
        let hoaDonCount = await PhieuThuChi_SearchCount(hoaDon);
        return hoaDonCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu HoaDon:", error);
        return 0;
    }
}
async function TKSL_NhanVien_Search(nhanVien) {
    try {
        let nhanVienCount = await NhanVien_SearchCount(nhanVien);
        return nhanVienCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu NhanVien:", error);
        return 0;
    }
}
async function TKSL_NhaCungCap_Search(nhaCungCap) {
    try {
        let nhaCungCapCount = await NhaCungCap_SearchCount(nhaCungCap);
        return nhaCungCapCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu NhaCungCap:", error);
        return 0;
    }
}
async function TKSL_MonHoc_Search(monHoc) {
    try {
        let monHocCount = await MonHoc_SearchCount(monHoc);
        return monHocCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu MonHoc:", error);
        return 0;
    }
}
async function TKSL_Lop_Search(lop) {
    try {
        let lopCount = await Lop_SearchCount(lop);
        return lopCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu Lop:", error);
        return 0;
    }
}
async function TKSL_KetQua_Search(ketQua) {
    try {
        let ketQuaCount = await KetQua_SearchCount(ketQua);
        return ketQuaCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu KetQua:", error);
        return 0;
    }
}
async function TKSL_HocSinh_Search(hocSinh) {
    try {
        let hocSinhCount = await HocSinh_SearchCount(hocSinh);
        return hocSinhCount;
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu HocSinh:", error);
        return 0;
    }
}


//===== Vẽ Biểu Đồ ===== Return options biểu đồ
async function GetOptions_TyLeHoaDon(maTrungTam, thang, nam) {
    //List Loại 
    let loaiHoaDons = ['Hóa đơn thu', 'Hóa đơn khác', 'Hóa đơn tạm ứng', 'Hóa đơn chi'];
    let countLoaiHoaDons = [];

    let phieuThuChiBase = {
        MaPhieu: null,
        NgayTao: null,
        CodeHoaDon: null,
        NgayThanhToan: null,
        LoaiPhieu: null,
        TongTien: null,
        GhiChu: null,
        MaTrungTam: maTrungTam,
        TrangThai: null,
        HinhThucThanhToan: null,
        MaNhanVien: null
    };

    let thangNamTaoHoaDon = thang !== '0' ? `${thang}/` : '';
    thangNamTaoHoaDon += nam || '';

    if (CheckIsNull(thangNamTaoHoaDon)) {
        thangNamTaoHoaDon = null;
    }

    // Sử dụng Promise.all để thực hiện các yêu cầu AJAX
    await Promise.all(loaiHoaDons.map(async (item) => {
        let phieuThuChi = { ...phieuThuChiBase, MaTrungTam: maTrungTam, LoaiPhieu: item, NgayTao: thangNamTaoHoaDon };
        try {
            let data = await PhieuThuChi_SearchCount(phieuThuChi);
            countLoaiHoaDons.push(data);
        } catch (error) {
            console.error(`Lỗi khi lấy dữ liệu cho loại ${item}:`, error);
            countLoaiHoaDons.push(0);
        }
    }));

    loaiHoaDons = loaiHoaDons.map((item, index) => `${item} (${countLoaiHoaDons[index]})`);

    var options = {
        series: countLoaiHoaDons,
        chart: {
            width: 380,
            type: 'pie',
        },
        labels: loaiHoaDons,
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 250
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };

    return options;
}
async function GetOptions_DoanhThuHoaDon(maTrungTam, nam) {
    let phieuThuChiBase = {
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

    let currentMonth = getCurrentMonth();
    let currentYear = getCurrentYear();

    let listMonthYear = (nam == currentYear) ? generateMonthYearList(currentMonth, currentYear) : generateMonthYearList(12, nam);
    let listMonthName = generateMonthList(listMonthYear.length);

    let thuPromises = listMonthYear.map(async (item) => {
        let phieuThuChi = { ...phieuThuChiBase, MaTrungTam: maTrungTam, NgayTao: item };
        try {
            return await PhieuThuChi_HoaDonThuThang(phieuThuChi);
        } catch (error) {
            console.error(`Lỗi khi lấy dữ liệu thu cho tháng ${item}:`, error);
            return 0;
        }
    });

    let chiPromises = listMonthYear.map(async (item) => {
        let phieuThuChi = { ...phieuThuChiBase, MaTrungTam: maTrungTam, NgayTao: item };
        try {
            return await PhieuThuChi_HoaDonChiThang(phieuThuChi);
        } catch (error) {
            console.error(`Lỗi khi lấy dữ liệu chi cho tháng ${item}:`, error);
            return 0;
        }
    });

    let thu = await Promise.all(thuPromises);
    let chi = await Promise.all(chiPromises);

    let doanhThu = thu.map((value, index) => value - chi[index]);

    let options = {
        series: [{
            name: 'Doanh Thu',
            data: doanhThu
        }, {
            name: 'Thu',
            data: thu
        }, {
            name: 'Chi',
            data: chi
        }],
        chart: {
            type: 'bar',
            height: 350
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                endingShape: 'rounded'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: listMonthName,
        },
        yaxis: {
            title: {
                text: '$ (vnđ)'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return formatToVND(val);
                }
            }
        }
    };

    return options;
}
async function GetOptions_HinhThucThanhToan(maTrungTam, thang, nam, theoluot) {
    let hinhThucThanhToans = ['Tiền mặt', 'Thẻ tín dụng', 'Trả góp', 'Ví điện tử', 'Chuyển khoản ngân hàng'];
    let phieuThuChiBase = {
        MaPhieu: null,
        NgayTao: null,
        CodeHoaDon: null,
        NgayThanhToan: null,
        LoaiPhieu: 'Hóa đơn thu',
        TongTien: null,
        GhiChu: null,
        MaTrungTam: maTrungTam,
        TrangThai: null,
        HinhThucThanhToan: null,
        MaNhanVien: null
    };

    let thangNamTaoHoaDon = thang !== '0' ? `${thang}/${nam || ''}` : null;

    let promises = hinhThucThanhToans.map(async (item) => {
        let phieuThuChi = { ...phieuThuChiBase, MaTrungTam: maTrungTam, HinhThucThanhToan: item, NgayThanhToan: thangNamTaoHoaDon };

        try {
            if (theoluot) {
                let data = await PhieuThuChi_SearchCount(phieuThuChi);
                return data;
            } else {
                let data = await PhieuThuChi_SearchTongTien(phieuThuChi);
                return data;
            }
        } catch (error) {
            console.error(`Lỗi khi lấy dữ liệu cho hình thức thanh toán ${item}:`, error);
            return 0;
        }
    });

    let results = await Promise.all(promises);

    let hinhThucThanhToansFormatted = results.map((value, index) => {
        return theoluot ? `${hinhThucThanhToans[index]} (${value} lượt)` : `${hinhThucThanhToans[index]} (${formatToVND(value)})`;
    });

    let options = {
        series: [{
            data: results
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
            categories: hinhThucThanhToansFormatted,
        }
    };

    return options;
}
async function fetchTrungTams() {
    return new Promise(async (resolve, reject) => {
        let trungTams = [];
        let dataAjax = await TrungTam_SearchName();
        $.each(dataAjax, function (index, item) {
            trungTams.push({
                maTrungTam: item.maTrungTam,
                tenTrungTam: item.tenTrungTam
            });
        });
        resolve(trungTams);
    });
}
async function fetchTrungTamByMa(maTrungTam) {
    return new Promise(async (resolve, reject) => {
        let trungTams = [];
        var trungTam = {
            MaTrungTam: maTrungTam,
            TenTrungTam: null,
            DiaChi: null,
            Email: null,
            MaSoThue: null,
            SoDienThoai: null,
            DienTich: null,
            NganHang: null,
            SoTaiKhoan: null,
        };
        let dataAjax = await TrungTam_SearchName(trungTam);
        $.each(dataAjax, function (index, item) {
            trungTams.push({
                maTrungTam: item.maTrungTam,
                tenTrungTam: item.tenTrungTam
            });
        });
        resolve(trungTams);
    });
}
async function GetOptions_TyLeHoaDonDaThanhToan(maTrungTam, thang, nam) {
    let phieuThuChi = {
        MaPhieu: null,
        NgayTao: null,
        CodeHoaDon: null,
        NgayThanhToan: null,
        LoaiPhieu: null,
        TongTien: null,
        GhiChu: null,
        MaTrungTam: maTrungTam,
        TrangThai: 'Chưa thanh toán',
        HinhThucThanhToan: null,
        MaNhanVien: null
    };
    let thangNamTaoHoaDon = thang !== '0' ? `${thang}/` : '';
    thangNamTaoHoaDon += nam || '';

    if (CheckIsNull(thangNamTaoHoaDon)) {
        thangNamTaoHoaDon = null;
    }
    phieuThuChi.NgayTao = thangNamTaoHoaDon;
    try {
        let [hdChuaThanhToan, tongSoHoaDon] = await Promise.all([
            fetchCount(phieuThuChi),
            fetchCount({ ...phieuThuChi, TrangThai: null })
        ]);

        let soHoaDonDaThanhToan = tongSoHoaDon - hdChuaThanhToan;
        let tyLeThanhToan = (soHoaDonDaThanhToan / tongSoHoaDon) * 100;
        var options = {
            series: [tyLeThanhToan],
            chart: {
                height: 220,
                type: 'radialBar',
                toolbar: {
                    show: true
                }
            },
            plotOptions: {
                radialBar: {
                    startAngle: -135,
                    endAngle: 225,
                    hollow: {
                        margin: 0,
                        size: '70%',
                        background: '#fff',
                        image: undefined,
                        imageOffsetX: 0,
                        imageOffsetY: 0,
                        position: 'front',
                        dropShadow: {
                            enabled: true,
                            top: 3,
                            left: 0,
                            blur: 4,
                            opacity: 0.24
                        }
                    },
                    track: {
                        background: '#fff',
                        strokeWidth: '67%',
                        margin: 0, // margin is in pixels
                        dropShadow: {
                            enabled: true,
                            top: -3,
                            left: 0,
                            blur: 4,
                            opacity: 0.35
                        }
                    },

                    dataLabels: {
                        show: true,
                        name: {
                            offsetY: -10,
                            show: true,
                            color: '#888',
                            fontSize: '17px'
                        },
                        value: {
                            formatter: function (val) {
                                return parseInt(val);
                            },
                            color: '#111',
                            fontSize: '36px',
                            show: true,
                        }
                    }
                }
            },
            fill: {
                type: 'gradient',
                gradient: {
                    shade: 'dark',
                    type: 'horizontal',
                    shadeIntensity: 0.5,
                    gradientToColors: ['#ABE5A1'],
                    inverseColors: true,
                    opacityFrom: 1,
                    opacityTo: 1,
                    stops: [0, 100]
                }
            },
            stroke: {
                lineCap: 'round'
            },
            labels: ['Đã thanh toán'],
        };

        return options;

    } catch (error) {
        console.error("Error fetching data:", error);
        throw error;
    }
}
async function fetchCount(phieuThuChi) {
    try {
        let data = await PhieuThuChi_SearchCount(phieuThuChi);
        return data;
    } catch (error) {
        console.error("Error fetching count:", error);
        throw error;
    }
}

async function GetOptions_DoanhThuTrungTam(nam, maTrungTam) {
    let seriesValue = [];

    let currentMonth = getCurrentMonth();
    let currentYear = getCurrentYear();

    let listMonthYear = (nam == currentYear) ? generateMonthYearList(currentMonth, currentYear) : generateMonthYearList(12, nam);
    let listMonthName = generateMonthList(listMonthYear.length);

    let trungTams = await fetchTrungTamByMa(maTrungTam);

    let promises = trungTams.map(async (item) => {
        let objectSeries = {
            name: item.tenTrungTam,
            data: []
        };

        for (let thangNam of listMonthYear) {
            objectSeries.data.push(await TKDT_HoaDon(item.maTrungTam, thangNam));
        }

        return objectSeries;
    });

    seriesValue = await Promise.all(promises);

    let options = {
        series: seriesValue,
        chart: {
            height: 370,
            type: 'area'
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth'
        },
        xaxis: {
            type: 'text',
            categories: listMonthName
        },
        tooltip: {
            x: {
                format: 'dd/MM/yy HH:mm'
            },
        },
    };

    return options;
}







