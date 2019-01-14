$(document).ready(function ()
{
    GetAllAreas();

    $("#editArea").click(function (event)
    {
        event.preventDefault();
        EditArea();
    });

    $("#addArea").click(function (event)
    {
        event.preventDefault();
        AddArea();
    });

    $("#cancelEdit").click(function (event)
    {
        event.preventDefault();
        CancelEdit();
    });
});

// Get all items with ajax-request
function GetAllAreas()
{
    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');

    $.ajax({
        url: '/api/Areas',
        type: 'GET',
        dataType: 'json',
        success: function (data)
        {
            WriteResponse(data);
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Add new item
function AddArea()
{
    var area = {
        Name: $('#addName').val(),
    };

    $.ajax({
        url: '/api/Areas',
        type: 'POST',
        data: JSON.stringify(area),
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllAreas();
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Delete item
function DeleteArea(id)
{
    $.ajax({
        url: '/api/Areas/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllAreas();
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Edit item
function EditArea()
{
    var id = $('#editId').val()

    var area = {
        Id: $('#editId').val(),
        Name: $('#editName').val(),
    };

    $.ajax({
        url: '/api/Areas/' + id,
        type: 'PUT',
        data: JSON.stringify(area),
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllAreas();
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Output data to display
function WriteResponse(areas)
{
    var strResult = "<table><th width='30px'>ID</th><th width='120px'>Name</th>";

    $.each(areas, function (index, area)
    {
        strResult += "<tr><td>" + area.Id + "</td><td> " + area.Name + "</td><td>" +
            "</td><td><a id='editItem' data-item='" + area.Id + "' onclick='EditItem(this);' >Edit</a>/</td>" +
            "<td><a id='delItem' data-item='" + area.Id + "' onclick='DeleteItem(this);' >Delete</a></td></tr>";
    });

    strResult += "</table>";
    $("#tableBlock").html(strResult);
}

// Delete handler
function DeleteItem(el)
{
    var id = $(el).attr('data-item');
    DeleteArea(id);
}

// Edit handler
function EditItem(el)
{
    var id = $(el).attr('data-item');
    GetArea(id);
}

// Cancel edit
function CancelEdit(el)
{
    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');
}

// Uotput data edit item
function ShowArea(area)
{
    if (area != null)
    {
        $("#createBlock").css('display', 'none');
        $("#editBlock").css('display', 'block');
        $("#editId").val(area.Id);
        $("#editName").val(area.Name);
    }
    else
    {
        alert("This area is not exist");
    }
}

// Find item for edit
function GetArea(id)
{
    $.ajax({
        url: '/api/Areas/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data)
        {
            ShowArea(data);
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}