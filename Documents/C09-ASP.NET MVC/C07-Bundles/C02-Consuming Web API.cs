//Create a javascript file in /Scripts/Home/Index.js

function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}
function getData() {
    $.ajax({
        type: "GET",
        url: "/api/reservation",
        success: function (data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody').append('<tr><td><input id="id" name="id" type="radio"'
                    + 'value="' + data[i].ReservationId + '" /></td>'
                    + '<td>' + data[i].ClientName + '</td>'
                    + '<td>' + data[i].Location + '</td></tr>');
            }
            $('input:radio')[0].checked = "checked";
            selectView("summary");
        }
    });
}
$(document).ready(function () {
    selectView("summary");
    getData();
    $("button").click(function (e) {
        var selectedRadio = $('input:radio:checked')
        switch (e.target.id) {
            case "refresh":
                getData();
                break;
            case "delete":
                break;
            case "add":
                selectView("add");
                break;
            case "edit":
                selectView("edit");
                break;
            case "submitEdit":
                break;
        }
    });
});




//Add reference to this script in our Index.cshtml file
@section scripts {
    <script src="~/Scripts/jquery.unobtrusive-ajax.js"></script>
    <script src="~/Scripts/Home/Index.js"></script> //this piece of code
} 


//For Add feature, update Index.cshtml with this piece of code
...
AjaxOptions addAjaxOpts = new AjaxOptions
{
	OnSuccess = "getData",
	Url = "/api/reservation"
};
...