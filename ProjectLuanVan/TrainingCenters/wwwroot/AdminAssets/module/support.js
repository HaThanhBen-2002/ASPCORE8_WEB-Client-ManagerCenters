// <reference path="student.js" />

//const { remove } = require("immutable");

//<script src="/AdminAssets/module/academicScore.js"></script>

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