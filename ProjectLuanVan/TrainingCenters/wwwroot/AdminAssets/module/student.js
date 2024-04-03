

//// Tìm tùy chọn có văn bản tương ứng và gán thuộc tính 'selected' cho nó
//$('#Ethnicity option').filter(function () {
//    return $(this).text() === optionText;


//}).prop('selected', true);
function CheckIdParent(id) {
    let n;
    $.ajax({
        type: "POST",
        url: "/Admin/Parent/CheckIdParent",
        async: false,
        data: { id: id },
        success: function (data) {
            n = data;
        }
    });
    // Trả về chuỗi ngày đã được định dạng
    return n;
}
function UpdateTrainingCenterCbb() {
    $.ajax({
        type: "POST",
        url: "/Admin/TrainingCenter/GetAllTrainingCenter",
        async: false,
        success: function (data) {
            $('#CbbTrainingCenterId').empty();
            // Thêm option mới dựa trên dữ liệu từ AJAX
            $('#CbbTrainingCenterId').append($('<option>', {
                value: 0,
                text: "Tất cả"
            }));
            $.each(data, function (index, trainingCenter) {

                $('#CbbTrainingCenterId').append($('<option>', {
                    value: trainingCenter.TrainingCenterId,
                    text: trainingCenter.CenterName
                }));
            });
        }
    });
}
function UpdateDormitoryRoomCbb(id) {
    if (id == 0 || id == null) {
        $('#CbbDormitoryRoomId').empty();
        // Thêm option mới dựa trên dữ liệu Default
        $('#CbbDormitoryRoomId').append($('<option>', {
            value: 0,
            text: "Vui lòng chỉ định Trung tâm"
        }));
    }
    else {
        let dormitoryRoom1 = {
            DormitoryRoomId: 0,
            DormitoryRoomName: null,
            TrainingCenterId: id ,
            Capacity: null,
            Facilities: null,
            Status: null,
            Note: null,
            EmployeeId: null,
            NumberStudents: null
        };
        $.ajax({
            type: "POST",
            url: "/Admin/DormitoryRoom/Search",
            async: false,
            data: { dormitoryRoom: dormitoryRoom1 },
            success: function (data) {
                $('#CbbDormitoryRoomId').empty();
                $('#CbbDormitoryRoomId').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                $.each(data, function (index, dormitoryRoom) {

                    $('#CbbDormitoryRoomId').append($('<option>', {
                        value: dormitoryRoom.DormitoryRoomId,
                        text: dormitoryRoom.DormitoryRoomName
                    }));
                });
            }
        });
    }
}
function UpdateClassCbb(id) {
    if (id == 0 || id == null) {
        $('#CbbClassId').empty();
        // Thêm option mới dựa trên dữ liệu Default
        $('#CbbClassId').append($('<option>', {
            value: 0,
            text: "Vui lòng chỉ định Trung tâm"
        }));
    }
    else {
        let class1 = {
            ClassId: 0,
            ClassName: null,
            EmployeeId: null,
            TrainingCenterId: id,
            NumberStudents: null,
            Description: null,
            StartDate: null,
            EndDate: null
        };
        $.ajax({
            type: "POST",
            url: "/Admin/Class/Search",
            async: false,
            data: { demo: class1 },
            success: function (data) {
                $('#CbbClassId').empty();
                $('#CbbClassId').append($('<option>', {
                    value: 0,
                    text: "Tất cả"
                }));
                $.each(data, function (index, class2) {
                    $('#CbbClassId').append($('<option>', {
                        value: class2.ClassId,
                        text: class2.ClassName
                    }));
                });
            }
        });
    }
}
function UpdateParentView() {
    let newValue = $('#ParentId').val();
    if (newValue != null || newValue != 0) {
        //lấy ID để show thông tin
        $.ajax({
            type: "POST",
            url: "/Admin/Parent/GetParentView",
            data: { id: newValue },
            success: function (data) {
                $('#Parent_ParentId').text('Mã phụ huynh: ' + data.ParentId);
                $('#Parent_ParentName').text('Tên phụ huynh: ' + data.ParentName);
                $('#Parent_DateOfBirth').text('Ngày sinh: ' + data.DateOfBirth);
                $('#Parent_Phone1').text('Số điện thoại 1: ' + data.Phone1);
                $('#Parent_Phone2').text('Số điện thoại 2: ' + data.Phone2);
                $('#Parent_Email').text('Email: ' + data.Email);
                $('#show1').text('Tên phụ huynh: ' + data.ParentName);
            }
        });
    }
    else {
        $('#Parent_ParentId').text('Mã phụ huynh: ');
        $('#Parent_ParentName').text('Tên phụ huynh: ');
        $('#Parent_DateOfBirth').text('Ngày sinh: ');
        $('#Parent_Phone1').text('Số điện thoại 1: ');
        $('#Parent_Phone2').text('Số điện thoại 2: ');
        $('#Parent_Email').text('Email: ');
        $('#show1').text('Tên phụ huynh: ');
    }
}
function UpdateStudent(item) {

    if (item.StudentId == null || item.StudentId == "") {
        displayMessages(2, "Vui lòng nhập (Mã học sinh)");
    }
    else if (item.FullName == null || item.FullName == "") {
        displayMessages(2, "Vui lòng nhập (Tên học sinh)");
    }
    else if (item.DateOfBirth == null || item.DateOfBirth == "") {
        displayMessages(2, "Vui lòng nhập (Ngày sinh)");
    }
    else if (item.Gender == null || item.Gender == "" || item.Gender == 2) {
        displayMessages(2, "Vui lòng chọn (Giới tính)");
    }
    else if (item.DormitoryRoomId == null || item.DormitoryRoomId == "" || item.DormitoryRoomId == 0) {
        displayMessages(2, "Vui lòng chọn (Phòng ở)");
    }
    else if (item.ClassId == null || item.ClassId == "" || item.ClassId == 0) {
        displayMessages(2, "Vui lòng chọn (Lớp học)");
    }
    else if (CheckIdParent(item.ParentId) != true) {
        displayMessages(2, "Vui lòng kiểm tra (Mã phụ huynh)");
    }
    else if (item.TrainingCenterId == null || item.TrainingCenterId == "" || item.TrainingCenterId == 0) {
        displayMessages(2, "Vui lòng nhập (Trung tâm)");
    }
    else if (item.Religion == null || item.Religion == "" || item.Religion == "Tất cả") {
        displayMessages(2, "Vui lòng nhập (Tôn giáo)");
    }
    else if (item.Ethnicity == null || item.Ethnicity == "" || item.Ethnicity == "Tất cả") {
        displayMessages(2, "Vui lòng nhập (Dân tộc)");
    }
    else {
        var statusUpdate = false;
        if (item.Gender == 1) {
            item.Gender = true;
        }
        else {
            item.Gender = false;
        }
        // Gọi ajax thêm dữ liệu vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/Student/Update",
            async: false,
            data: { student: JSON.stringify(item) },
            success: function (data) {
                statusUpdate = data;
            }
        });
        return statusUpdate;
    }
}
function CreateStudent(item) {


    if (item.FullName == null || item.FullName == "") {
        displayMessages(2, "Vui lòng nhập (Tên học sinh)");
    }
    else if (item.DateOfBirth == null || item.DateOfBirth == "") {
        displayMessages(2, "Vui lòng nhập (Ngày sinh)");
    }
    else if (isValidDateFormat(item.DateOfBirth) != true) {
        displayMessages(2, "Vui lòng nhập (Ngày sinh)");
    }
    else if (item.Gender == null || item.Gender == "" || item.Gender == 2) {
        displayMessages(2, "Vui lòng chọn (Giới tính)");
    }
    else if (item.DormitoryRoomId == null || item.DormitoryRoomId == "" || item.DormitoryRoomId == 0) {
        displayMessages(2, "Vui lòng chọn (Phòng ở)");
    }
    else if (item.ClassId == null || item.ClassId == "" || item.ClassId == 0) {
        displayMessages(2, "Vui lòng chọn (Lớp học)");
    }
    else if (CheckIdParent(item.ParentId) != true) {
        displayMessages(2, "Vui lòng kiểm tra (Mã phụ huynh)");
    }
    else if (item.TrainingCenterId == null || item.TrainingCenterId == "" || item.TrainingCenterId == 0) {
        displayMessages(2, "Vui lòng nhập (Trung tâm)");
    }
    else if (item.Religion == null || item.Religion == "" || item.Religion == "Tất cả") {
        displayMessages(2, "Vui lòng nhập (Tôn giáo)");
    }
    else if (item.Ethnicity == null || item.Ethnicity == "" || item.Ethnicity == "Tất cả") {
        displayMessages(2, "Vui lòng nhập (Dân tộc)");
    }
    else {
        var statusCreate = false;
        item.StudentId = 0;
        if (item.Gender == 1) {
            item.Gender = true;
        }
        else {
            item.Gender = false;
        }
        // Gọi ajax thêm dữ liệu vào CSDL
        $.ajax({
            type: "POST",
            url: "/Admin/Student/Create",
            async: false,
            data: { student: JSON.stringify(item) },
            success: function (data) {
                statusCreate = data;
            }
        });
        return statusCreate;
    }
}
//===== Func xữ lí ảnh
function openFileInput() {
    $("#fileInput").click();
}
// Xử lý file ảnh mà người dùng chọn
function handleFileSelect(input) {
    var file = input.files[0];
    if (file) {
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

$(document).ready(function () {
    UpdateTrainingCenterCbb();
    UpdateDormitoryRoomCbb(0);
    UpdateClassCbb(0);
    //=============================== TABLE ===================================
    var student = {
        StudentId: 0,
        FullName: null,
        DateOfBirth: null,
        Gender: null,
        DormitoryRoomId: null,
        ClassId: null,
        ParentId: null,
        TrainingCenterId: null,
        Ethnicity: null,
        Religion: null,
        Description: null,
        Image: null
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
            url: "/Admin/Student/LoadingData",
            dataType: "json",
            data: { search: JSON.stringify(student) },
            dataSrc: 'data.$values'
        },
        columns: [
            {
                data: 'studentId',
                render: function (data, type, row) {
                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
                }
            },
            { data: "fullName" },
            { data: "dateOfBirth" },
            { data: "dormitoryRoomName" },
            { data: "className" },
            { data: "gender" },
            { data: "ethnicity" }
        ],
    });

    // Table Object
    var table = $('#myTable').DataTable();

    // Event pageChange"myTable"
    table.on('page.dt', function () {
        // Thực hiện các hành động khi trang của DataTable thay đổi
        $('#checkAll').prop('checked', false);
    });

    // Event selectItem "myTable"
    $('#myTable tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected')
        } else {
            table.$('tr.selected').removeClass('selected')
            $(this).addClass('selected')
            // xử lý ở đây
            const rowId = table.row(this).data().studentId;
            // Thực hiện get giá trị của Academic với rowId
            $.ajax({
                type: "POST",
                url: "/Admin/Student/GetStudent",
                // contentType: "application/json",
                data: { id: rowId },
                success: function (data) {
                    $('#StudentId').val(data.StudentId);
                    $('#FullName').val(data.FullName);
                    $('#DateOfBirth').val(data.DateOfBirth);
                    $('#ParentId').val(data.ParentId);
                    if (data.Gender == true) {
                        $('#Gender').val(1);
                    }
                    else if (data.Gender == false) {
                        $('#Gender').val(0);
                    }
                    else {
                        $('#Gender').val(2);
                    }
                    $('#Description').val(data.Description);
                    if (data.TrainingCenterId != null && data.TrainingCenterId != 0) {
                        $('#CbbTrainingCenterId').val(data.TrainingCenterId);
                    }
                    if (data.DormitoryRoomId != null && data.DormitoryRoomId != 0) {
                        UpdateDormitoryRoomCbb(data.TrainingCenterId);
                        $('#CbbDormitoryRoomId').val(data.DormitoryRoomId);
                    }
                    if (data.ClassId != null && data.ClassId != 0) {
                        UpdateClassCbb(data.ClassId);
                        $('#CbbClassId').val(data.ClassId);
                    }
                    if (data.Ethnicity != null && data.Ethnicity != 0) {
                        $('#Ethnicity option').filter(function () {
                            return $(this).text() === data.Ethnicity;
                        }).prop('selected', true);
                    }
                    if (data.Religion != null && data.Religion != 0) {
                        $('#Religion option').filter(function () {
                            return $(this).text() === data.Religion;
                        }).prop('selected', true);
                    }
                    $('#imageShow').attr('src', data.Image);
                    UpdateParentView();
                }
            });

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
    
    //=============================== CBB Change ==============================
    $('#CbbTrainingCenterId').change(function () {
        UpdateDormitoryRoomCbb($('#CbbTrainingCenterId').val());
        UpdateClassCbb($('#CbbTrainingCenterId').val());
    });
    //=============================== FORM INPUT ==============================
    // Event input "StudentId"
    $('#ParentId').on('input', function () {
        UpdateParentView();
    });
    //=============================== KHÁC ====================================
    $('#ParentId').focus(function () {
        if ($('#showAll').prop('checked')) {
            $('#showParentView').addClass('show');
        }
    });
    $('#ParentId').blur(function () {
        $('#showParentView').removeClass('show');
    });
    //=============================== IMAGE ===================================
    // đối tượng ảnh
    var image = "";
    $("#addImage").click(function () {
        openFileInput();
    });
    //=============================== Button ==============================
    $('#btnResetStudent').click(function () {
        $('#StudentId').val(null);
        $('#FullName').val(null);
        $('#DateOfBirth').val(null);
        $('#ParentId').val(null);
        $('#Gender').val(2);
        $('#Description').val(null);
        $('#CbbTrainingCenterId').val(0);
        UpdateDormitoryRoomCbb(0);
        UpdateClassCbb(0);
        $('#Ethnicity option').filter(function () {
            return $(this).text() === "Tất cả";
        }).prop('selected', true);
        $('#Religion option').filter(function () {
            return $(this).text() === "Tất cả";
        }).prop('selected', true);
        UpdateParentView();
        $('#show1').text("Phụ huynh: ");
        image = ""
        deleteImage();
    });
    $('#btnUpdateStudent').click(function () {
        let item = {
            StudentId: $('#StudentId').val(),
            FullName: $('#FullName').val(),
            DateOfBirth: $('#DateOfBirth').val(),
            Gender: $('#Gender').val(),
            DormitoryRoomId: $('#CbbDormitoryRoomId').val(),
            ClassId: $('#CbbClassId').val(),
            ParentId: $('#ParentId').val(),
            TrainingCenterId: $('#CbbTrainingCenterId').val(),
            Ethnicity: $('#Ethnicity').val(),
            Religion: $('#Religion').val(),
            Description: $('#Description').val(),
            Image: $('#imageShow').attr('src')
        };
        if (UpdateStudent(item) == true) {
            displayMessages(1, "Sửa thông tin thành công")
            let studentView;

            $.ajax({
                type: "POST",
                url: "/Admin/Student/GetStudentView1",
                async: false,
                data: { id: item.StudentId },
                success: function (data) {
                    studentView = data;
                }
            });
            studentView.StudentId = '<input data-checkbox-id="' + studentView.StudentId + '" type="checkbox"/>';
            if (studentView != null) {
                table.rows('.selected').remove().draw(false);
                table.row.add(studentView).draw(false);
            }
        } else {
            displayMessages(2, "Sửa thông tin học sinh thất bại");
        }

    });
    $('#btnCreateStudent').click(function () {
        let item = {
            StudentId: $('#StudentId').val(),
            FullName: $('#FullName').val(),
            DateOfBirth: $('#DateOfBirth').val(),
            Gender: $('#Gender').val(),
            DormitoryRoomId: $('#CbbDormitoryRoomId').val(),
            ClassId: $('#CbbClassId').val(),
            ParentId: $('#ParentId').val(),
            TrainingCenterId: $('#CbbTrainingCenterId').val(),
            Ethnicity: $('#Ethnicity').val(),
            Religion: $('#Religion').val(),
            Description: $('#Description').val(),
            Image: $('#imageShow').attr('src')
        };
        //alert(item.Image);
        if (CreateStudent(item) == true) {
            displayMessages(1, "Thêm mới thông tin thành công")
            let studentView;
            $.ajax({
                type: "POST",
                url: "/Admin/Student/GetStudentView",
                async: false,
                data: { id: item.StudentId },
                success: function (data) {
                    studentView = data;
                }
            });
            studentView.StudentId = '<input data-checkbox-id="' + studentView.StudentId + '" type="checkbox"/>';
            if (studentView != null) {
                table.row.add(studentView).draw(false);
            }
        } else {
            displayMessages(2, "Thêm mới thông tin thất bại");
        }

    });
    // Event button "btnDeleteAcademicScore"
    $('#btnDeleteAcademicScore').click(function () {

        let selectedIds = [];
        // Lặp qua các checkbox để xác định đối tượng nào được chọn
        $('input[type="checkbox"]:checked').each(function () {
            let checkboxId = $(this).data("checkbox-id");
            selectedIds.push(parseInt(checkboxId));
        });
        if (selectedIds.length >= 1 && selectedIds != null) {
            $("#DeleteModal").modal("show");
        }
    });    // btn Xác nhận xóa
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
                url: "/Admin/Student/Delete",
                async: false,
                data: { ids: selectedIds }, // Truyền danh sách ID đến action
                success: function (data) {
                    if (data == true) {
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
                    if (rowData && rowData.studentId) {
                        var checkbox = $('input[data-checkbox-id="' + rowData.studentId + '"]');
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
    // Event button "btnSearchAcademicScore"
    $('#btnSearchStudent').click(function () {
        // Cập nhật giá trị cho các thuộc tính của searchAcademicScore
        student.StudentId = $('#StudentId').val() || 0;
        student.FullName = $('#FullName').val() || null;
        student.DateOfBirth = $('#DateOfBirth').val() || null;
        student.Gender = $('#Gender').val() || null;
        student.ParentId = $('#ParentId').val() || null;
        student.Description = $('#Description').val() || null;
        student.DormitoryRoomId = $('#CbbDormitoryRoomId').val() || null;
        student.ClassId = $('#CbbClassId').val() || null;
        student.TrainingCenterId = $('#CbbTrainingCenterId').val() || null;
        student.Ethnicity = $('#Ethnicity').val() || null;
        student.Religion = $('#Religion').val() || null;
        student.Image = null;

        if (student.Gender == 1) {
            student.Gender = true;
        }
        else if (student.Gender == 0) {
            student.Gender = false;
        }
        else {
            student.Gender = null;
        }

        if ($('#CbbDormitoryRoomId').val() == 0) {
            student.DormitoryRoomId = null;
        }
        alert($('#CbbTrainingCenterId').val());
        if ($('#CbbTrainingCenterId').val() == 0) {
            student.TrainingCenterId = null;
        }
        if ($('#CbbClassId').val() == 0) {
            student.ClassId = null;
        }
        if ($('#Ethnicity').val() == "Tất cả") {
            student.Ethnicity = null;
        }
        if ($('#Religion').val() == "Tất cả") {
            student.Religion = null;
        }
        table.settings()[0].ajax.data = { search: JSON.stringify(student) };
        table.ajax.reload();
    });
});
