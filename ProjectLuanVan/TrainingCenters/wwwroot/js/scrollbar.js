document.addEventListener('DOMContentLoaded', function () {
    var scrollX = 0;
    var scrolling = false;
    var scrollElement = document.querySelector('.custom-scrollbar');

    // Bắt đầu cuộn khi giữ chuột trái
    scrollElement.addEventListener('mousedown', function (event) {
        if (event.button === 0) { // 0 là chuột trái
            scrolling = true;
            scrollX = event.clientX;
        }
    });

    // Kết thúc cuộn khi thả chuột
    document.addEventListener('mouseup', function () {
        scrolling = false;
    });

    // Cuộn tự động
    document.addEventListener('mousemove', function (event) {
        if (scrolling) {
            var deltaX = scrollX - event.clientX;
            scrollX = event.clientX;
            scrollElement.scrollLeft += deltaX;
        }
    });
});
