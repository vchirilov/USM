/**********************************************************************************************************************
Bundles, allows us to organize and optimize the CSS and JavaScript files that our views and layouts cause the browser 
to request from the server.
**********************************************************************************************************************/

//Let's go with a real example

//Create in Model folder a new class Appointment
public class Appointment
{
	[Required]
	public string ClientName { get; set; }

	[DataType(DataType.Date)]
	public DateTime Date { get; set; }

	public bool TermsAccepted { get; set; }
}

//In Home controller add 2 actions 
public class HomeController : Controller
{
	public ViewResult MakeBooking()
	{
		return View();
	}
	[HttpPost]
	public JsonResult MakeBooking(Appointment appt)
	{
		return Json(appt, JsonRequestBehavior.AllowGet);
	}
}

//Change routing configuration
public static void RegisterRoutes(RouteCollection routes)
{
	routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

	routes.MapRoute(
		name: "Default",
		url: "{controller}/{action}/{id}",
		defaults: new { controller = "Home", action = "MakeBooking", id = UrlParameter.Optional }
	);
}

//Add the view for MakeBooking GET action.
@model Bundles.Models.Appointment
@{
    ViewBag.Title = "Make A Booking";

    AjaxOptions ajaxOpts = new AjaxOptions
    {
        OnSuccess = "processResponse"
    };
}
<h4>Book an Appointment</h4>

<link rel="stylesheet" href="~/Content/CustomStyles.css" />

<script src="~/Scripts/jquery-3.3.1.min.js"></script>
<script src="~/Scripts/jquery.validate.js"></script>
<script src="~/Scripts/jquery.validate.unobtrusive.js"></script>
<script src="~/Scripts/jquery.unobtrusive-ajax.js"></script>

<script type="text/javascript">
    function processResponse(appt) {
        $('#successClientName').text(appt.ClientName);
        $('#successDate').text(processDate(appt.Date));
        switchViews();
    }
    function processDate(dateString) {
        return new Date(parseInt(dateString.substr(6,
            dateString.length - 8))).toDateString();
    }
    function switchViews() {
        var hidden = $('.hidden');
        var visible = $('.visible');
        hidden.removeClass("hidden").addClass("visible");
        visible.removeClass("visible").addClass("hidden");
    }
    $(document).ready(function () {
        $('#backButton').click(function (e) {
            switchViews();
        });
    });
</script>

<div id="formDiv" class="visible">
    @using (Ajax.BeginForm(ajaxOpts))
    {
        @Html.ValidationSummary(true)

        <p>@Html.ValidationMessageFor(m => m.ClientName)</p>
        <p>Your name: @Html.EditorFor(m => m.ClientName)</p>

        <p>@Html.ValidationMessageFor(m => m.Date)</p>
        <p>Appointment Date: @Html.EditorFor(m => m.Date)</p>

        <p>@Html.ValidationMessageFor(m => m.TermsAccepted)</p>
        <p>@Html.EditorFor(m => m.TermsAccepted) I accept the terms & conditions</p>

        <input type="submit" value="Make Booking" />
    }
</div>
<div id="successDiv" class="hidden">
    <h4>Your appointment is confirmed</h4>
    <p>Your name is: <b id="successClientName"></b></p>
    <p>The date of your appointment is: <b id="successDate"></b></p>
    <button id="backButton">Back</button>
</div>

//Add CustomStyle.css file in Content folder
div.hidden {
    display: none;
}

div.visible {
    display: block;
}

//Add package Microsoft.jQuery.Unobtrusive.Ajax
Install-Package Microsoft.jQuery.Unobtrusive.Ajax -Version 3.2.6


//Using Script and Style Bundles

//Bundles are defined in the /App_Start/BundleConfig.cs file

//We can create bundles for script files and for style sheets and it is important that we keep these types of file separate 
//because the MVC Framework optimizes the files differently.

//Applying Bundles


//Let' create a folder called Home in folder Scripts and javascript file MakeBooking.js
function processResponse(appt) {
    $('#successClientName').text(appt.ClientName);
    $('#successDate').text(processDate(appt.Date));
    switchViews();
}
function processDate(dateString) {
    return new Date(parseInt(dateString.substr(6,
        dateString.length - 8))).toDateString();
}
function switchViews() {
    var hidden = $('.hidden');
    var visible = $('.visible');
    hidden.removeClass("hidden").addClass("visible");
    visible.removeClass("visible").addClass("hidden");
}

$(document).ready(function () {
    $('#backButton').click(function (e) {
        switchViews();
    });
});

//Now, remove javascript code from MakeBooking view and replace with this piece of code
<script src="~/Scripts/Home/MakeBooking.js" type="text/javascript"></script>

//Update BundleConfig.cs file aas below
...
bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
			"~/Scripts/jquery-{version}.js"));

bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
			"~/Scripts/jquery.unobtrusive-ajax.js"));
...

//Remove script tags from MakeBooking view 

<script src="~/Scripts/jquery-3.3.1.min.js"></script> 				//remove
<script src="~/Scripts/jquery.validate.js"></script> 				//remove
<script src="~/Scripts/jquery.validate.unobtrusive.js"></script> 	//remove
<script src="~/Scripts/jquery.unobtrusive-ajax.js"></script> 		//remove

//Bundles are created usually for group of files and called from layout pages. Bundles are added using the @Scripts.Render and @Styles.Render helper methods.

//Create a new lyout page called CustomLayout.cshtml
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>@ViewBag.Title</title>
    @Styles.Render("~/Content/css")
</head>
<body>
    @RenderBody()

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/ajax")

    @RenderSection("scripts", required: false)
</body>
</html>


//Now, add in MakeBooking view layout page as CustomLayout
Layout = "~/Views/Shared/_CustomLayout.cshtml";

//At the end use this statement
@section scripts {
<script src="~/Scripts/Home/MakeBooking.js" type="text/javascript"></script>
}

//Run the application (and test with CSS how the page changes).

//Creating the API Controller
public class ReservationController : ApiController
{
	IReservationRepository repo = ReservationRepository.getRepository();
	
	public IEnumerable<Reservation> GetAllReservations()
	{
		return repo.GetAll();
	}
	public Reservation GetReservation(int id)
	{
		return repo.Get(id);
	}
	public Reservation PostReservation(Reservation item)
	{
		return repo.Add(item);
	}
	public bool PutReservation(Reservation item)
	{
		return repo.Update(item);
	}
	public void DeleteReservation(int id)
	{
		repo.Remove(id);
	}
}

//Run the application by typing in URL \api\values, \api\reservation

//Understanding How the API Controller Works
//Routing configuration is kept in a separate configuration file /App_Start/WebApiConfig.cs