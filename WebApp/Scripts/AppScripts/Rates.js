$(document).ready(function ()
{
    GetAllItems();

    $("#editItemButton").click(function (event)
    {
        event.preventDefault();
        EditItem();
    });

    $("#addItemButton").click(function (event)
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
        url: '/api/Rates',
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
        Rate: $('#addRate').val(),
        UserId: $('#addUserId').val(),
        UserName: $('#addUserName').val(),
        KnowledgeId: $('#addKnowledgeId').val(),
        KnowledgeName: $('#addKnowledgeName').val(),
    };

    $.ajax({
        url: '/api/Rates',
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
        url: '/api/Rates/' + id,
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
        Rate: $('#editRate').val(),
        UserId: $('#editUserId').val(),
        KnowledgeId: $('#editKnowledgeId').val(),
    };

    $.ajax({
        url: '/api/Rates/' + id,
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
    var strResult = "<table><th width='30px'>Id</th><th width='30px'>KnowId</th><th width='120px'>Knowledge</th>" +
        "<th width='30px'>UserID</th><th width='120px'>User</th><th width='40px'>Rate</th>";

    $.each(items, function (index, item)
    {
        strResult += "<tr><td>" + item.Id + "</td><td> " + item.KnowledgeId + "</td><td> " + item.Knowledge +
            "</td><td> " + item.UserId + "</td><td> " + item.User + "</td><td> " + item.Rate +
            "</td><td><a id='editItem' data-item='" + item.Id + "' onclick='EditItemHandler(this);' >Edit</a>/</td>" +
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
function EditItemHandler(el)
{
    var id = $(el).attr('data-item');
    GetItem(id);
}

// Output data for edit item
function ShowItem(item)
{
    if (item != null)
    {
        $("#createBlock").css('display', 'none');
        $("#editBlock").css('display', 'block');

        $('#editId').val(item.Id);
        $('#editRate').val(item.Rate);
        $('#editUserId').val(item.UserId);
        $('#editKnowledgeId').val(item.KnowledgeId);
    }
    else
    {
        alert("This item is not exist");
    }
}

// Find item for edit
function GetItem(id)
{
    $.ajax({
        url: '/api/Rates/' + id,
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

// Cancel edit
function CancelEdit(el)
{
    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');
}