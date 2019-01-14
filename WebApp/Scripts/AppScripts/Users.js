$(document).ready(function ()
{
    GetAllItems();

    $("#editButton").click(function (event)
    {
        event.preventDefault();
        EditItem();
    });

    $("#addButton").click(function (event)
    {
        event.preventDefault();
        AddItem();
    });

    $("#cancelEdit").click(function (event)
    {
        event.preventDefault();
        CancelEdit();
    });
});

// Get all items with ajax-request
function GetAllItems()
{
    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');

    $.ajax({
        url: '/api/Users',
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
function AddItem()
{
    var item = {
        Name: $('#addName').val(),
    };

    $.ajax({
        url: '/api/Users',
        type: 'POST',
        data: JSON.stringify(item),
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllItems();
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Delete item
function DeleteItem(id)
{
    $.ajax({
        url: '/api/Users/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllItems();
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Edit item
function EditItem()
{
    var id = $('#editId').val()

    var item = {
        Id: $('#editId').val(),
        Name: $('#editName').val(),
    };

    $.ajax({
        url: '/api/Users/' + id,
        type: 'PUT',
        data: JSON.stringify(item),
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllItems();
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Output data to display
function WriteResponse(items)
{
    var strResult = "<table><th width='30px'>ID</th><th width='120px'>Name</th>";

    $.each(items, function (index, item)
    {
        strResult += "<tr><td>" + item.Id + "</td><td> " + item.Name +
            "</td><td><a id='editItem' data-item='" + item.Id + "' onclick='EditItemHundler(this);' >Edit</a>/</td>" +
            "<td><a id='delItem' data-item='" + item.Id + "' onclick='DeleteItemHandler(this);' >Delete</a></td></tr>";
    });

    strResult += "</table>";
    $("#tableBlock").html(strResult);
}

// Delete handler
function DeleteItemHandler(el)
{
    var id = $(el).attr('data-item');
    DeleteItem(id);
}

// Edit handler
function EditItemHundler(el)
{
    var id = $(el).attr('data-item');
    GetItem(id);
}

// Find item for edit
function GetItem(id)
{
    $.ajax({
        url: '/api/Users/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data)
        {
            ShowItem(data);
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Output data edit item
function ShowItem(item)
{
    if (item != null)
    {
        $("#createBlock").css('display', 'none');
        $("#editBlock").css('display', 'block');

        $("#editId").val(item.Id);
        $("#editName").val(item.Name);
    }
    else
    {
        alert("This user is not exist");
    }
}

// Cancel edit
function CancelEdit()
{
    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');
}