
////<script src="/AdminAssets/module/academicScore.js"></script>


//// Đặt giá trị int vào cookie
////Response.Cookies.Append("IdAccount", "1", new CookieOptions
////{
////    Expires = DateTime.Now.AddDays(30) // Thời hạn 30 ngày
////});


//// Lấy giá trị int từ cookie (nếu tồn tại)
////int IdUser = 0;
////if (Request.Cookies.TryGetValue("IdUser", out string intString)) {
////    if (int.TryParse(intString, out int myIntValue)) {
////        IdUser = myIntValue;
////    }
////}


////let academicScore = {
////    AcademicScoreId: 0,
////    ScoreName: null,
////    StudentId: null,
////    SubjectId: null,
////    Score: null,
////    Grade: null,
////    TestDate: null,
////    EmployeeId: null
////};

//function UpdateStudentView() {
//    let newValue = $('#StudentId').val();
//    if (newValue != null || newValue != 0) {
//        //lấy ID để show thông tin
//        $.ajax({
//            type: "POST",
//            url: "/Admin/Student/GetStudentView",
//            data: { id: newValue },
//            success: function (data) {
//                $('#Student_FullName').text(data.FullName);
//                $('#Student_DateOfBirth').text(data.DateOfBirth);
//                $('#Student_Gender').text(data.Gender);
//                $('#Student_DormitoryRoomName').text(data.DormitoryRoomName);
//                $('#Student_ClassName').text(data.ClassName);
//                $('#Student_FullName').text('Họ và Tên: ' + data.FullName);
//                $('#Student_DateOfBirth').text('Ngày sinh: ' + data.DateOfBirth);
//                $('#Student_Gender').text('Giới tính: ' + data.Gender);
//                $('#Student_DormitoryRoomName').text('Phòng ở: ' + data.DormitoryRoomName);
//                $('#Student_ClassName').text('Lớp học: ' + data.ClassName);
//                $('#Student_Ethnicity').text('Dân tộc: ' + data.Ethnicity);
//                $('#Student_Religion').text('Tôn giáo: ' + data.Religion);
//                $('#show1').text("Học sinh: " + data.FullName);
//            }
//        });
//    }
//    else {
//        $('#Student_FullName').text("");
//        $('#Student_DateOfBirth').text("");
//        $('#Student_Gender').text("");
//        $('#Student_DormitoryRoomName').text("");
//        $('#Student_ClassName').text("");
//        $('#Student_Ethnicity').text("");
//        $('#Student_Religion').text("");
//        $('#show1').text("Học sinh: ");
//    }
//}

//function UpdateSubjectCbb() {
//    $.ajax({
//        type: "POST",
//        url: "/Admin/Subject/GetAllSubject",
//        async: false,
//        success: function (data) {
//            $('#CbbSubjectId').empty();
//            // Thêm option mới dựa trên dữ liệu từ AJAX
//            $('#CbbSubjectId').append($('<option>', {
//                value: 0,
//                text: "Tất cả"
//            }));
//            $.each(data, function (index, subject) {

//                $('#CbbSubjectId').append($('<option>', {
//                    value: subject.SubjectId,
//                    text: subject.SubjectName
//                }));
//            });
//        }
//    });
//}

//function UpdateTrainingCenterCbb() {
//    $.ajax({
//        type: "POST",
//        url: "/Admin/TrainingCenter/GetAllTrainingCenter",
//        async: false,
//        success: function (data) {
//            $('#CbbTrainingCenterId').empty();
//            // Thêm option mới dựa trên dữ liệu từ AJAX
//            $('#CbbTrainingCenterId').append($('<option>', {
//                value: 0,
//                text: "Tất cả"
//            }));
//            $.each(data, function (index, trainingCenter) {

//                $('#CbbTrainingCenterId').append($('<option>', {
//                    value: trainingCenter.TrainingCenterId,
//                    text: trainingCenter.CenterName
//                }));
//            });
//        }
//    });
//}

//function UpdateEmployeeView() {
//    let newValue = $('#EmployeeId').val();
//    if (newValue != null || newValue != 0) {
//        //lấy ID để show thông tin
//        $.ajax({
//            type: "POST",
//            url: "/Admin/Employee/GetEmployeeTeacherView",
//            data: { id: newValue },
//            success: function (data) {
//                $('#Employee_EmployeeName').text('Họ và Tên: ' + data.EmployeeName);
//                $('#Employee_DateOfBirth').text('Ngày sinh: ' + data.DateOfBirth);
//                $('#Employee_Gender').text('Giới tính: ' + data.Gender);
//                $('#Employee_Phone').text('Số điện thoại: ' + data.Phone);
//                $('#Employee_Email').text('Email: ' + data.Email);
//                $('#show3').text('Giáo viên: ' + data.EmployeeName);
//            }
//        });
//    }
//    else {
//        $('#Employee_EmployeeName').text('Họ và Tên: ');
//        $('#Employee_DateOfBirth').text('Ngày sinh: ');
//        $('#Employee_Gender').text('Giới tính: ');
//        $('#Employee_Phone').text('Số điện thoại: ');
//        $('#Employee_Email').text('Email: ');
//        $('#show3').text('Giáo viên: ');
//    }
//}

//function CreateAcademicScore(item) {

//    if (item.ScoreName == null || item.ScoreName == "") {
//        displayMessages(2, "Vui lòng nhập (Tên phiếu điểm)");
//    }
//    else if (item.StudentId == null || item.StudentId == 0) {
//        displayMessages(2, "Vui lòng nhập (Mã học sinh)");
//    }
//    else if (item.SubjectId == null || item.SubjectId == 0) {
//        displayMessages(2, "Vui lòng nhập (Mã môn học)");
//    }
//    else if (item.Score == null || item.Score == 0) {
//        displayMessages(2, "Vui lòng nhập (Điểm số)");
//    }
//    else if (item.TestDate == null || item.TestDate == "") {
//        displayMessages(2, "Vui lòng nhập (Ngày kiểm tra)");
//    }
//    else if (item.EmployeeId == null || item.EmployeeId == 0) {
//        displayMessages(2, "Vui lòng nhập (Mã giáo viên)");
//    }
//    else if (isValidDateFormat(item.TestDate) != true) {
//        displayMessages(2, "Dữ liệu không đúng định dạng (Ngày kiểm tra)");
//    }
//    // Check Db
//    else if (CheckIdStudent(item.StudentId) != true) {
//        displayMessages(2, "Không tìm thấy (Mã học sinh)");
//    }
//    else if (CheckIdEmployee_Teacher(item.EmployeeId) != true) {
//        displayMessages(2, "Không tìm thấy (Mã giáo viên)");
//    }
//    else {
//        var statusCreate = false;

//        // Gọi ajax thêm dữ liệu vào CSDL
//        $.ajax({
//            type: "POST",
//            url: "/Admin/AcademicScore/Create",
//            async: false,
//            data: { academicScore: JSON.stringify(item) },
//            success: function (data) {
//                statusCreate = data;
//            }
//        });
//        return statusCreate;
//    }
//}

//function UpdateAcademicScore(item) {

//    if (item.ScoreName == null || item.ScoreName == "") {
//        displayMessages(2, "Vui lòng nhập (Tên phiếu điểm)");
//    }
//    else if (CheckIdAcademicScore(item.AcademicScoreId) != true) {
//        displayMessages(2, "Không tìm thấy (Bảng điểm)");
//    }
//    else if (item.StudentId == null || item.StudentId == 0) {
//        displayMessages(2, "Vui lòng nhập (Mã học sinh)");
//    }
//    else if (item.SubjectId == null || item.SubjectId == 0) {
//        displayMessages(2, "Vui lòng nhập (Mã môn học)");
//    }
//    else if (item.Score == null || item.Score == 0) {
//        displayMessages(2, "Vui lòng nhập (Điểm số)");
//    }
//    else if (item.TestDate == null || item.TestDate == "") {
//        displayMessages(2, "Vui lòng nhập (Ngày kiểm tra)");
//    }
//    else if (item.EmployeeId == null || item.EmployeeId == 0) {
//        displayMessages(2, "Vui lòng nhập (Mã giáo viên)");
//    }
//    else if (isValidDateFormat(item.TestDate) != true) {
//        displayMessages(2, "Dữ liệu không đúng định dạng (Ngày kiểm tra)");
//    }
//    // Check Db
//    else if (CheckIdStudent(item.StudentId) != true) {
//        displayMessages(2, "Không tìm thấy (Mã học sinh)");
//    }
//    else if (CheckIdEmployee_Teacher(item.EmployeeId) != true) {
//        displayMessages(2, "Không tìm thấy (Mã giáo viên)");
//    }
//    else {
//        var statusUpdate = false;

//        // Gọi ajax thêm dữ liệu vào CSDL
//        $.ajax({
//            type: "POST",
//            url: "/Admin/AcademicScore/Update",
//            async: false,
//            data: { academicScore: JSON.stringify(item) },
//            success: function (data) {
//                statusUpdate = data;
//            }
//        });
//        return statusUpdate;
//    }
//}

//$(document).ready(function () {
    
//    UpdateSubjectCbb();
//    UpdateTrainingCenterCbb();
    
//    //============================================== TABLE ===============================================
//    var searchAcademicScore = {
//        AcademicScoreId: 0,
//        ScoreName: null,
//        StudentId: null,
//        SubjectId: null,
//        Score: null,
//        Grade: null,
//        TestDate: null,
//        EmployeeId: null,
//        TrainingCenterId: null
//    };
//    // Loading Data Table
//    $('#myTable').DataTable({
//        serverSide: true,
//        scrollY: 400,
//        searching: false,
//        lengthChange: true,
//        ordering: false,
//        ajax: {
//            type: "POST",
//            url: "/Admin/AcademicScore/LoadingData",
//            dataType: "json",
//            data: { search: JSON.stringify(searchAcademicScore) },
//            dataSrc: 'data.$values'
//        },
//        columns: [
//            {
//                data: 'academicScoreId',
//                render: function (data, type, row) {
//                    return '<input data-checkbox-id="' + data + '" type="checkbox"/>';
//                }
//            },
//            { data: "scoreName" },
//            { data: "studentName" },
//            { data: "employeeName" },
//            { data: "subjectName" },
//            { data: "score" },
//            { data: "grade" },
//            { data: "testDate" }
//        ],

//    });

//    // Table Object
//    var table = $('#myTable').DataTable();

//    // Event pageChange"myTable"
//    table.on('page.dt', function () {
//        // Thực hiện các hành động khi trang của DataTable thay đổi
//        $('#checkAll').prop('checked', false);
//    });

//    // Event selectItem "myTable"
//    $('#myTable tbody').on('click', 'tr', function () {
//        if ($(this).hasClass('selected')) {
//            $(this).removeClass('selected')
//        } else {
//            table.$('tr.selected').removeClass('selected')
//            $(this).addClass('selected')
//            // xử lý ở đây
//            const rowId = table.row(this).data().academicScoreId;
//            // Thực hiện get giá trị của Academic với rowId
//            $.ajax({
//                type: "POST",
//                url: "/Admin/AcademicScore/GetById",
//                // contentType: "application/json",
//                data: { id: rowId },
//                success: function (data) {
//                    $('#AcademicScoreId').val(data.AcademicScoreId);
//                    $('#ScoreName').val(data.ScoreName);
//                    $('#Score').val(data.Score);
//                    $('#Grade').val(data.Grade);
//                    $('#StudentId').val(data.StudentId);
//                    $('#SubjectId').val(data.SubjectId);
//                    $('#EmployeeId').val(data.EmployeeId);
//                    $('#TestDate').val(data.TestDate);
//                    if (data.StudentId != null && data.StudentId != 0) {
//                        UpdateStudentView();
//                    }
//                    if (data.SubjectId != null && data.SubjectId != 0) {
//                        $('#CbbSubjectId').val(data.SubjectId);
//                    }
//                    if (data.EmployeeId != null && data.EmployeeId != 0) {
//                        UpdateEmployeeView();
//                    }
//                    if (data.TrainingCenterId != null && data.TrainingCenterId != 0) {
//                        $('#CbbTrainingCenterId').val(data.TrainingCenterId);
//                    }
//                    // Xữ lý dữ liệu cũ (nếu có)
//                }
//            });

//        }
//    });

//    // Event checkbox "Check All"
//    $('#checkAll').change(function () {
//        var isChecked = $(this).prop('checked');
//        if (isChecked) {
//            $('input[type="checkbox"]').each(function () {
//                if ($(this).hasClass('form-check-input') != true) {
//                    // Thực hiện hành động cho checkbox có class "form-check-input" ở đây
//                    $(this).prop('checked', true);
//                }
//            });
//        } else {
//            $('input[type="checkbox"]').each(function () {
//                if ($(this).hasClass('form-check-input') != true) {
//                    // Thực hiện hành động cho checkbox có class "form-check-input" ở đây
//                    $(this).prop('checked', false);
//                }
//            });
//        }
//    });


//    //============================================== BUTTON ===============================================
//    // btn Xác nhận xóa
//    $('#btnDelete').click(function () {
//        // Tạo một mảng để lưu trữ ID của các đối tượng được chọn
//        let selectedIds = [];
//        // Lặp qua các checkbox để xác định đối tượng nào được chọn
//        $('input[type="checkbox"]:checked').each(function () {
//            let checkboxId = $(this).data("checkbox-id");
//            selectedIds.push(parseInt(checkboxId));
//        });

//        if (selectedIds.length >= 1 && $('#accountActivation').is(':checked')) {
//            let statusDelete = false;
//            // Gửi danh sách ID được chọn đến action bằng Ajax
//            $.ajax({
//                type: "POST",
//                url: "/Admin/AcademicScore/Delete",
//                async: false,
//                data: { ids: selectedIds }, // Truyền danh sách ID đến action
//                success: function (data) {
//                    if (data == true) {
//                        displayMessages(1, "Xóa thành công");
//                        $("#DeleteModal").modal("hide");
//                        statusDelete = true;
//                    }
//                    else {
//                        statusDelete = false;
//                        displayMessages(2, "Xóa thất bại");
//                    }
//                }
//            });
//            if (statusDelete) {
//                // Lặp qua từng hàng
//                table.rows().every(function () {
//                    var rowData = this.data();
//                    // Kiểm tra xem rowData có tồn tại không trước khi truy cập thuộc tính
//                    if (rowData && rowData.academicScoreId) {
//                        var checkbox = $('input[data-checkbox-id="' + rowData.academicScoreId + '"]');
//                        if (checkbox.prop('checked')) {
//                            // Xóa hàng nếu checkbox được kiểm tra
//                            this.remove();
//                        }
//                    }
//                });
//                // Vẽ lại DataTables sau khi xóa các hàng
//                table.draw();
//            }
//        }
//    });

//    // Event button "btnResetAcademicScore"
//    $('#btnResetAcademicScore').click(function () {
//        $('#AcademicScoreId').val(null);
//        $('#ScoreName').val(null);
//        $('#Score').val(null);
//        $('#Grade').val(null);
//        $('#StudentId').val(null);
//        $('#CbbSubjectId').val(0);
//        $('#CbbTrainingCenterId').val(0);
//        $('#EmployeeId').val(null);
//        $('#TestDate').val(null);
//        $('#Student_Name').val(null);
//        $('#show1').text("Học sinh: ");
//        $('#show2').text("Môn: ");
//        $('#show3').text("Giáo viên: ");
//    });

//    // Event button "btnCreateAcademicScore"
//    $('#btnCreateAcademicScore').click(function () {
//        let item = {
//            AcademicScoreId: $('#AcademicScoreId').val(),
//            ScoreName: $('#ScoreName').val(),
//            StudentId: $('#StudentId').val(),
//            SubjectId: $('#CbbSubjectId').val(),
//            Score: $('#Score').val(),
//            Grade: $('#Grade').val(),
//            TestDate: $('#TestDate').val(),
//            EmployeeId: $('#EmployeeId').val(),
//            TrainingCenterId: $('#CbbTrainingCenterId').val()
//        };
//        if (CreateAcademicScore(item) == true) {
//            displayMessages(1, "Thêm điểm thành công")
//            let academicScoreView;

//            $.ajax({
//                type: "POST",
//                url: "/Admin/AcademicScore/GetAcademicScoretView",
//                async: false,
//                data: { id: item.AcademicScoreId },
//                success: function (data) {
//                    academicScoreView = data;
//                }
//            });
//            academicScoreView.academicScoreId = '<input data-checkbox-id="' + academicScoreView.academicScoreId + '" type="checkbox"/>';
//            if (academicScoreView != null) {
//                table.row.add(academicScoreView).draw(false);
//            }
//        } else {
//            displayMessages(2, "Nhập điểm thất bại")
//        }
//    });

//    // Event button "btnUpdateAcademicScore"
//    $('#btnUpdateAcademicScore').click(function () {

//        let item = {
//            AcademicScoreId: $('#AcademicScoreId').val(),
//            ScoreName: $('#ScoreName').val(),
//            StudentId: $('#StudentId').val(),
//            SubjectId: $('#CbbSubjectId').val(),
//            Score: $('#Score').val(),
//            Grade: $('#Grade').val(),
//            TestDate: $('#TestDate').val(),
//            EmployeeId: $('#EmployeeId').val(),
//            TrainingCenterId: $('#CbbTrainingCenterId').val()
//        };
//        if (UpdateAcademicScore(item) == true) {
//            displayMessages(1, "Sửa điểm thành công")
//            let academicScoreView;

//            $.ajax({
//                type: "POST",
//                url: "/Admin/AcademicScore/GetAcademicScoretView",
//                async: false,
//                data: { id: item.AcademicScoreId },
//                success: function (data) {
//                    academicScoreView = data;
//                }
//            });
//            academicScoreView.academicScoreId = '<input data-checkbox-id="' + academicScoreView.academicScoreId + '" type="checkbox"/>';
//            if (academicScoreView != null) {
//                table.rows('.selected').remove().draw(false);
//                table.row.add(academicScoreView).draw(false);
//            }
//        } else {
//            displayMessages(2, "Sửa điểm thất bại")
//        }

//    });

//    // Event button "btnDeleteAcademicScore"
//    $('#btnDeleteAcademicScore').click(function () {

//        let selectedIds = [];
//        // Lặp qua các checkbox để xác định đối tượng nào được chọn
//        $('input[type="checkbox"]:checked').each(function () {
//            let checkboxId = $(this).data("checkbox-id");
//            selectedIds.push(parseInt(checkboxId));
//        });
//        if (selectedIds.length >= 1 && selectedIds != null) {
//            $("#DeleteModal").modal("show");
//        }
//    });

//    // Event button "btnSearchAcademicScore"
//    $('#btnSearchAcademicScore').click(function () {
//        // Cập nhật giá trị cho các thuộc tính của searchAcademicScore
//        searchAcademicScore.AcademicScoreId = $('#AcademicScoreId').val() || 0; // Sử dụng toán tử "||" để mặc định giá trị là 0 nếu không có giá trị nhập vào
//        searchAcademicScore.ScoreName = $('#ScoreName').val() || null;
//        searchAcademicScore.StudentId = $('#StudentId').val() || null;
//        searchAcademicScore.SubjectId = $('#CbbSubjectId').val() || null;
//        searchAcademicScore.Score = $('#Score').val() || null;
//        searchAcademicScore.Grade = $('#Grade').val() || null;
//        searchAcademicScore.TestDate = $('#TestDate').val() || null;
//        searchAcademicScore.EmployeeId = $('#EmployeeId').val() || null;
//        searchAcademicScore.TrainingCenterId = $('#CbbTrainingCenterId').val() || null;
//        if ($('#CbbSubjectId').val() == 0) {
//            searchAcademicScore.SubjectId = null;
//        }
//        if ($('#CbbTrainingCenterId').val() == 0) {
//            searchAcademicScore.TrainingCenterId = null;
//        }
//        table.settings()[0].ajax.data = { search: JSON.stringify(searchAcademicScore) };
//        table.ajax.reload();
//    });

//    //============================================== FORM INPUT ===============================================

//    // Event input "Scoro"
//    $('#Score').on('input', function () {
//        var score = parseInt($(this).val());
//        var grade;
//        if (score >= 90) {
//            grade = 'A+';
//        } else if (score >= 80) {
//            grade = 'A';
//        } else if (score >= 70) {
//            grade = 'B+';
//        } else if (score >= 60) {
//            grade = 'B';
//        } else if (score >= 50) {
//            grade = 'C';
//        }
//        else if (score >= 0) {
//            grade = 'F';
//        }
//        else {
//            grade = null;
//        }
//        $('#Grade').val(grade);
//    });

//    $('#Score').on('keypress', function (e) {
//        var key = e.which;
//        // Lấy giá trị hiện tại của ô nhập liệu
//        var currentValue = $(this).val();
//        // Thêm ký tự vừa nhập vào giá trị hiện tại để kiểm tra
//        var newValue = currentValue + String.fromCharCode(key);

//        // Kiểm tra xem giá trị mới có hợp lệ hay không
//        if (newValue < 0 || newValue > 100 || isNaN(newValue)) {
//            // Nếu giá trị không hợp lệ, ngăn người dùng nhập
//            e.preventDefault();
//        }
//    });

//    // Event input "StudentId"
//    $('#StudentId').on('input', function () {
//        UpdateStudentView();
//    });

//    // Event input "EmployeeId"
//    $('#EmployeeId').on('input', function () {
//        UpdateEmployeeView();
//    });

//    //============================================== KHÁC ===============================================
//    $('#StudentId').focus(function () {
//        if ($('#showAll').prop('checked')) {
//            $('#showStudentView').addClass('show');
//        }
//    });
//    $('#StudentId').blur(function () {
//        $('#showStudentView').removeClass('show');
//    });

//    $('#EmployeeId').focus(function () {
//        if ($('#showAll').prop('checked')) {
//            $('#showEmployeeView').addClass('show');
//        }
//    });
//    $('#EmployeeId').blur(function () {
//        $('#showEmployeeView').removeClass('show');
//    });

//});
