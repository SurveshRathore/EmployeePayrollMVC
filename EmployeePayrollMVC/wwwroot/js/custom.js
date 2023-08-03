$(document).ready(function () {
    showEmployeeDate();
});

function showEmployeeDate() {
    
    $.ajax({
        url: '/Ajax/EmployeeList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';

            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.empID + '</td>';
                object += '<td>' + item.empName + '</td>';
                object += '<td>' + item.empProfileImage + '</td>';
                object += '<td>' + item.empGender + '</td>';
                object += '<td>' + item.empDepartment + '</td>';
                object += '<td>' + item.empSalary + '</td>';
                object += '<td>' + item.empStartDate + '</td>';
                object += '<td>' + item.notes + '</td>';
                
                object += '</tr >';
            });
            $('#table_data').html(object);
        },
            

        error: function () {
            alert("Unable to fetch data");
        }
    });
};