
/*<script src="/AdminAssets/module/academicScore.js"></script>*/
function getCurrentYear() {
    const currentDate = new Date();
    return currentDate.getFullYear();
}
function getCurrentMonth() {
    const currentDate = new Date();
    const currentMonth = currentDate.getMonth() + 1; // Tháng trong JavaScript được đánh số từ 0 đến 11
    return currentMonth;
}
function generateMonthList(currentMonth) {
    let listMonth = [];
    for (let i = 1; i <= currentMonth; i++) {
        let month = i.toString().padStart(2, '0'); // Chuyển số thành chuỗi và thêm '0' ở trước nếu cần
        listMonth.push('Tháng ' + month);
    }
    return listMonth;
}
function generateMonthYearList(currentMonth, currentYear) {
    let listMonthYear = [];
    for (let i = 1; i <= currentMonth; i++) {
        let month = i.toString().padStart(2, '0'); // Chuyển số thành chuỗi và thêm '0' ở trước nếu cần
        listMonthYear.push(month + '/' + currentYear);
    }
    return listMonthYear;
}
// Func chuyển đổi số thành số tiền
function formatToVND(number) {
    if (number == null) {
        return "0 đ";
    }
    // Sử dụng hàm replace để chèn dấu chấm vào số tiền 
    var formattedNumber = number.toString().replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    // Thêm dấu đồng
    formattedNumber += ' đ';
    return formattedNumber;
}
function parseVNDToNumber(vndString) {
    // Loại bỏ dấu chấm và ký tự không phải số từ chuỗi
    var numberString = vndString.replace(/[^\d]/g, '');
    // Chuyển đổi chuỗi thành số
    var number = parseFloat(numberString);
    return number;
}
// Func hiển hiện Tin Nhắn Thông Báo
function displayMessages(status, mesg) {
    let successData = '';
    let errorData = '';
    let warningData = '';
    if (status == 1) {
        successData = mesg;
    }
    else if (status == 2) {
        warningData = mesg;
    }
    else {
        errorData = mesg;
    }
    if (successData !== '') {
        toastr.success(successData);
    }
    if (errorData !== '') {
        toastr.error(errorData);
    }
    if (warningData !== '') {
        toastr.warning(warningData);
    }
}
function getTimeToday() {
    let today = new Date();

    let day = String(today.getDate()).padStart(2, '0');
    let month = String(today.getMonth() + 1).padStart(2, '0'); // Tháng từ 0-11 nên cần +1
    let year = today.getFullYear();

    let hours = String(today.getHours()).padStart(2, '0');
    let minutes = String(today.getMinutes()).padStart(2, '0');
    let seconds = String(today.getSeconds()).padStart(2, '0');

    return `${day}/${month}/${year} ${hours}:${minutes}:${seconds}`;
}

function addOneMonth(dateStr) {
    var parts = dateStr.split('/');
    var day = parseInt(parts[0]);
    var month = parseInt(parts[1]);
    var year = parseInt(parts[2]);

    // Create a new date object
    var date = new Date(year, month - 1, day);
    date.setMonth(date.getMonth() + 1); // Add one month

    // If month overflow to next year
    if (date.getMonth() == 0) {
        date.setFullYear(date.getFullYear());
    }

    // Format the date as dd/mm/yyyy
    var nextMonth = ('0' + (date.getMonth() + 1)).slice(-2);
    var nextDay = ('0' + date.getDate()).slice(-2);
    var nextYear = date.getFullYear();

    return `${nextDay}/${nextMonth}/${nextYear}`;
}

function addMonthNumber(dateStr, number) {
    var parts = dateStr.split('/');
    var day = parseInt(parts[0]);
    var month = parseInt(parts[1]);
    var year = parseInt(parts[2]);

    // Tạo đối tượng Date mới
    var date = new Date(year, month - 1, day);
    date.setMonth(date.getMonth() + number);

    // Nếu ngày hiện tại là ngày cuối cùng của tháng, cần kiểm tra và điều chỉnh lại
    if (day !== date.getDate()) {
        date.setDate(0); // Đặt ngày thành ngày cuối cùng của tháng trước
    }

    // Định dạng ngày dưới dạng dd/mm/yyyy
    var nextDay = ('0' + date.getDate()).slice(-2);
    var nextMonth = ('0' + (date.getMonth() + 1)).slice(-2);
    var nextYear = date.getFullYear();

    return `${nextDay}/${nextMonth}/${nextYear}`;
}
// Trả về số ngày của date2 = date1 - có trả về số âm
function getDaysDifference(date1, date2) {
    // Chuyển đổi date1 từ chuỗi thành đối tượng Date
    var parts1 = date1.split('/');
    var day1 = parseInt(parts1[0]);
    var month1 = parseInt(parts1[1]);
    var year1 = parseInt(parts1[2]);
    var dateObj1 = new Date(year1, month1 - 1, day1);

    // Chuyển đổi date2 từ chuỗi thành đối tượng Date
    var parts2 = date2.split('/');
    var day2 = parseInt(parts2[0]);
    var month2 = parseInt(parts2[1]);
    var year2 = parseInt(parts2[2]);
    var dateObj2 = new Date(year2, month2 - 1, day2);

    // Tính toán sự khác biệt giữa hai ngày (milliseconds)
    var differenceInTime = dateObj2 - dateObj1;

    // Chuyển đổi sự khác biệt từ milliseconds sang ngày
    var differenceInDays = differenceInTime / (1000 * 3600 * 24);

    return differenceInDays;
}

// Func lấy ngày tháng năm hiện tại
function GetToDay() {
    // Lấy ngày hiện tại
    var today = new Date();

    // Lấy ngày, tháng và năm từ đối tượng Date
    var day = today.getDate();
    var month = today.getMonth() + 1; // Lưu ý: Tháng bắt đầu từ 0 (0 - January, 1 - February, ...)
    var year = today.getFullYear();

    // Định dạng ngày, tháng và năm thành chuỗi có định dạng "dd/mm/yyyy"
    var formattedDate = (day < 10 ? '0' : '') + day + '/' + (month < 10 ? '0' : '') + month + '/' + year;

    // Trả về chuỗi ngày đã được định dạng
    return formattedDate;
}

function isValidDateFormat(input) {
    // Sử dụng regex để kiểm tra định dạng
    var regex = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/;

    // Kiểm tra xem input có khớp với định dạng không
    if (!regex.test(input)) {
        return false;
    }

    // Lấy ra các phần tử ngày, tháng, năm từ chuỗi
    var parts = input.split('/');
    var day = parseInt(parts[0], 10);
    var month = parseInt(parts[1], 10);
    var year = parseInt(parts[2], 10);

    // Kiểm tra xem ngày, tháng, năm có hợp lệ không
    if (year < 1000 || year > 9999 || month == 0 || month > 12 || day == 0 || day > 31) {
        return false;
    }

    // Kiểm tra thêm trường hợp các tháng có số ngày khác nhau
    var daysInMonth = new Date(year, month, 0).getDate();
    if (day > daysInMonth) {
        return false;
    }

    // Trả về true nếu tất cả đều hợp lệ
    return true;
}

function CheckIsNull(value) {
    if (value == null || value.trim() === "" || parseFloat(value) <= 0 || value === "Tất cả") {
        return true;
    } else {
        return false;
    }
}

// Hiển thị màn hình loading
function showLoading() {
    $("#loadingScreen").show();
}

// Ẩn màn hình loading
function hideLoading() {
    $("#loadingScreen").hide();
}

function isValidEmail(email) {
    if (email != null) {
        // Sử dụng biểu thức chính quy để kiểm tra địa chỉ email
        const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        // Kiểm tra xem email có khớp với biểu thức chính quy hay không
        return emailRegex.test(email);
    }
}

async function sendEmailKyThuatVien(viTriSuCo) {
    showLoading();
    // Chuyển trạng thái của button sang disabled
    $('#sendEmailError').prop('disabled', true);

    // Đặt một độ trễ để kích hoạt lại button sau 5 phút
    setTimeout(function () {
        $('#sendEmailError').prop('disabled', false);
    }, 2 * 60 * 1000);  // 2 phút * 60 giây/phút * 1000 ms/giây
    let name = $('#emailKyThuat_TenKhachHang').val();
    let sdt = $('#emailKyThuat_SDT').val();
    let suCo = $('#emailKyThuat_SuCo').val();
    let moTa = $('#emailKyThuat_MoTaSuCo').val();
    let ngayGui = getTimeToday();
    if (CheckIsNull(name)) {
        displayMessages(2, "Vui lòng nhập Tên của bạn");
    }
    else if (CheckIsNull(sdt)) {
        displayMessages(2, "Vui lòng nhập Số điện thoại của bạn");
    }
    else if (CheckIsNull(suCo)) {
        displayMessages(2, "Vui lòng chọn sự cố gặp phải");
    }
    else if (CheckIsNull(moTa)) {
        displayMessages(2, "Vui lòng nhập mô tả cho sự cố trên");
    }
    else {
        let emailContent = `
            <strong>Thông Báo Lỗi Đến Từ: ${name}</strong><br>
            <strong>Số điện thoại:</strong> ${sdt}<br>
            <strong>Sự cố:</strong> ${suCo}<br>
            <strong>Hệ thống nhận thấy tại:</strong> ${window.location.href}<br>
            <strong>Thời gian:</strong> ${ngayGui}<br>
            <strong>Mô tả từ khách hàng:</strong><br>
            ${moTa}`;
        let message = {
            To: [],
            Subject: "Hệ Thống BENBEN Thông Báo Sự Cố",
            Content: emailContent
        };
        let stratusSend = await SendEmailKyThuat(message);
        if (stratusSend) {
            displayMessages(1, "Đã gửi thông báo đến kỹ thuật viên");
        }
        else {
            displayMessages(3, "Gửi Thông Báo Thất Bại");
        }
        hideLoading();
    }
}