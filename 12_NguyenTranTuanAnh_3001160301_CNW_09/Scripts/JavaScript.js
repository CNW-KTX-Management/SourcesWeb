$(document).ready(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: "/SinhVien/ListSinhVien",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ID + '</td>';
                html += '<td>' + item.MSSV + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.NgaySinh + '</td>';
                html += '<td>' + item.Phone + '</td>';
                html += '<td>' + item.Passpotr + '</td>';
                html += '<td>' + item.GioiTinh + '</td>';
                html += '<td><a href="#" data-toggle="modal" data-target="#myModal" onClick = "return detailFood(' + item.id + ')">Edit</a> | <a href="#" onClick = "return deleteFood(' + item.id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function AddSinhVien() {
    var sv = {
        MSSV: $('#MSSV').val(),
        Name: $('#Name').val(),
        NgaySinh: $('#NgaySinh').val(),
        Phone: $('#Phone').val(),
        Passport: $('#Passport').val(),
        GioiTinh: $('#GioiTinh').val(),
    };

    $.ajax({
        url: "/SinhVien/AddSinhVien",
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: JSON.stringify(sv),
        success: function (result) {
            if (result == 1) {
                loadData();
                $('#btnClose').trigger('click');
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}