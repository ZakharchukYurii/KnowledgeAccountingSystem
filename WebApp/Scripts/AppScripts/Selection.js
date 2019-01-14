$(document).ready(function ()
{
    $("#makeSelection").click(function (event)
    {
        event.preventDefault();
        SearchItems();
    });
})

function SearchItems()
{
    var item = {
        Knowledge: $("#knowledgeName").val(),
        Rate: $("#rate").val()
    }

    $.ajax({
        url: "/api/Selection/" + item.Knowledge + "/" + item.Rate,
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

function WriteResponse(items)
{
    var strResult = "<table><th width='auto'>User</th><th width='auto'>Knowledge</th><th width='40px'>Rate</th>";

    $.each(items, function (index, item)
    {
        strResult += "<tr><td>" + item.User + " (Id:" + item.UserId + ")</td> " +
            "<td>" + item.Knowledge + " (Id:" + item.KnowledgeId + ")</td> " +
            "<td style='text-align:center'> " + item.Rate + "</td>";
    });

    strResult += "</table>";
    $("#resultBlock").html(strResult);
}
