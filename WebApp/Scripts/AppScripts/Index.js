$(document).ready(function ()
{
    $("#showUserButton").click(function (event)
    {
        event.preventDefault();
        FindUser();
    });

    $("#showAddBlockButton").click(function (event)
    {
        event.preventDefault();
        ShowAddKnowledgeBlock();
    });

    $("#addKnowledgeButton").click(function (event)
    {
        event.preventDefault();
        AddKnowledge();
    });

    $("#editKnowledgeButton").click(function (event)
    {
        event.preventDefault();
        EditKnowledge();
    });

    $("#cancelAddButton").click(function (event)
    {
        event.preventDefault();
        CancelAddKnowledges();
    });

    $("#cancelEditButton").click(function (event)
    {
        event.preventDefault();
        CancelEditKnowledges();
    });

    $("#showEditUserMenu").click(function (event)
    {
        event.preventDefault();
        ShowEditUserMenu();
    });

    $("#cancelEditUser").click(function (event)
    {
        event.preventDefault();
        EndEditUser();
    });

    $("#editUser").click(function (event)
    {
        event.preventDefault();
        EditUser();
    });
});

// Get user by id
function FindUser()
{
    var id = $('#inputUserId').val();

    $.ajax({
        url: '/api/Users/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data)
        {
            ShowUser(data);
        },
        error: function ()
        {
            alert("Error");
        }
    });
}

// Show user data
function ShowUser(data)
{
    if (data != null)
    {
        $("#userName").text(data.Name);
        $("#userId").text(data.Id);
        $("#userFullName").html(data.FullName);
        $("#userEMail").html(data.EMail);

        $("#hidenUserId").val(data.Id);
        $("#inputUserName").val(data.Name);
        $("#inputUserFullName").val(data.FullName);
        $("#inputUserEMail").val(data.EMail);

        $("#userBox").css('display', 'block');
        $("#showAddBlock").css('display', 'block');
        $("#showAddBlockButton").css('display', 'block');
        $("#showEditUserMenu").css('display', 'block');

        GetAllKnowledges(data.Id);
    }
    else
    {
        alert("This user is not exist");
    }
}

// Get knowledge data 
function GetAllKnowledges(id)
{
    $.ajax({
        url: '/api/UserRates/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data)
        {
            WriteResponse(data);
        },
        error: function ()
        {
            alert("Error");
        }
    });
}

// Display knowledge data
function WriteResponse(items)
{
    var strResult = "<table><th width='30px'>Id</th><th width='120px'>Knowledge</th><th width='40px'>Rate</th>";

    $.each(items, function (index, item)
    {
        strResult += "<tr><td> " + item.Id + "</td><td> " + item.Knowledge + " (Id:" + item.KnowledgeId + ")</td>" +
            "<td style='text - align: center'> " + item.Rate +
            "</td><td><a id='editItem' data-item='" + item.Id + "' onclick='ShowEditBlock(this);' >Edit</a>/</td>" +
            "<td><a id='delItem' data-item='" + item.Id + "' onclick='DeleteKnowledge(this);' >Delete</a></td></tr>";
    });

    strResult += "</table>";
    $("#knowledgeBlock").html(strResult);
}

function AddKnowledge()
{
    var userId = $('#hidenUserId').val();

    var item = {
        Rate: $('#addRate').val(),
        UserId: userId,
        KnowledgeId: $('#addKnowledgeId').val(),
    };

    $.ajax({
        url: '/api/Rates',
        type: 'POST',
        data: JSON.stringify(item),
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllKnowledges(userId);
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Edit Knowledge handler
function ShowEditBlock(el)
{
    var id = $(el).attr('data-item');
    GetKnowledge(id);
}

function GetKnowledge(id)
{
    $.ajax({
        url: '/api/Rates/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data)
        {
            ShowEditKnowledge(data);
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

function ShowEditKnowledge(item)
{
    if (item != null)
    {
        $("#addKnowledge").css('display', 'none');
        $("#editKnowledge").css('display', 'block');

        $("#editId").val(item.Id);
        $('#editRate').val(item.Rate);
        $('#editKnowledgeId').val(item.KnowledgeId);
    }
    else
    {
        alert("This item is not exist");
    }
}

function EditKnowledge()
{
    var id = $('#editId').val();
    var userId = $('#hidenUserId').val();

    var item = {
        Rate: $('#editRate').val(),
        UserId: userId,
        KnowledgeId: $('#editKnowledgeId').val(),
    };

    $.ajax({
        url: '/api/Rates/' + id,
        type: 'PUT',
        data: JSON.stringify(item),
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllKnowledges(userId);
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Delete knowledge
function DeleteKnowledge(el)
{
    var id = $(el).attr('data-item');
    var userId = $('#hidenUserId').val();

    $.ajax({
        url: '/api/Rates/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            GetAllKnowledges(userId);
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}

// Show AddKnowledge block
function ShowAddKnowledgeBlock()
{
    $("#addKnowledge").css('display', 'block');
    $("#editKnowledge").css('display', 'none');
}

// Hide Edit block
function CancelAddKnowledges()
{
    $("#addKnowledge").css('display', 'none');
}

// Hide Add block
function CancelEditKnowledges()
{
    $("#editKnowledge").css('display', 'none');
}

function ShowEditUserMenu()
{
    $("#showEditUserMenu").css('display', 'none');
    $("#editUser").css('display', 'block');
    $("#cancelEditUser").css('display', 'block');

    $("#inputUserName").css('display', 'block');
    $("#inputUserFullName").css('display', 'block');
    $("#inputUserEMail").css('display', 'block');
}

function EndEditUser()
{
    $("#showEditUserMenu").css('display', 'block');
    $("#editUser").css('display', 'none');
    $("#cancelEditUser").css('display', 'none');

    $("#inputUserName").css('display', 'none');
    $("#inputUserFullName").css('display', 'none');
    $("#inputUserEMail").css('display', 'none');
}

function EditUser()
{
    var userId = $("#hidenUserId").val();

    var item = {
        Name: $("#inputUserName").val(),
        FullName: $("#inputUserFullName").val(),
        EMail: $("#inputUserEMail").val(),
    };

    $.ajax({
        url: '/api/Users/' + userId,
        type: 'PUT',
        data: JSON.stringify(item),
        contentType: "application/json;charset=utf-8",
        success: function (data)
        {
            FindUser();
        },
        error: function (x, y, z)
        {
            alert(x + '\n' + y + '\n' + z);
        }
    });

    EndEditUser();
}