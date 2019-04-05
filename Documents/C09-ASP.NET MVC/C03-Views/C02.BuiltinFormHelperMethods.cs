/****************************************************************************
The MVC Framework includes a selection of built-in helper methods that help you manage the creating of
HTML form elements.
*****************************************************************************/

//Create a below classes in Model folder

public class Person
{
	public int PersonId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }
	public Address HomeAddress { get; set; }
	public bool IsApproved { get; set; }
	public Role Role { get; set; }
}

public class Address
{
	public string Line1 { get; set; }
	public string Line2 { get; set; }
	public string City { get; set; }
	public string PostalCode { get; set; }
	public string Country { get; set; }
}

public enum Role
{
	Admin,
	User,
	Guest
}

//Update Home controller, action Index with this code and add 2 more actions CreatePerson.
public class HomeController : Controller
{
	public ActionResult Index()
	{
		ViewBag.Fruits = new string[] { "Apple", "Orange", "Pear" };
		ViewBag.Cities = new string[] { "New York", "London", "Paris" };
		string message = "This is an HTML element: <input>";
		return View((object)message);
	}
	public ActionResult CreatePerson()
	{
		return View(new Person());
	}
	[HttpPost]
	public ActionResult CreatePerson(Person person)
	{
		return View(person);
	}
}
	
	
//Creating views

//Create view for [HttpPost]CreatePerson action. 
@model Test.Models.Person
@{
    ViewBag.Title = "CreatePerson";
}
<h2>CreatePerson</h2>
@using (Html.BeginForm())
{
    <div class="dataElem">
        <label>PersonId</label>
        <input name="personId" value="@Model.PersonId" />
    </div>
    <div class="dataElem">
        <label>First Name</label>
        <input name="FirstName" value="@Model.FirstName" />
    </div>
    <div class="dataElem">
        <label>Last Name</label>
        <input name="lastName" value="@Model.LastName" />
    </div>
    <input type="submit" value="Submit" />
}

/****************************************************************************
The name attribute is used by the MVC Framework default model binder to work out which input elements 
contain values for the model type properties when processing a post request and if you omit the name attribute your form will not work properly.
*****************************************************************************/

//Change Layout page

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>@ViewBag.Title</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    <style type="text/css">
        label {
            display: inline-block;
            width: 100px;
        }

        .dataElem {
            margin: 5px;
        }
    </style>
</head>
<body>
    @RenderBody()
</body>
</html>




//Create view for [HttpGet]CreatePerson action.
@model Test.Models.Person

@{
    Layout = null;
}

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>DisplayPerson</title>
</head>
<body>
    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.FirstName)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.LastName)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.BirthDate)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.IsApproved)
            </th>
            <th></th>
        </tr>

        <tr>
            <td>
                @Html.DisplayFor(modelItem => Model.FirstName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => Model.LastName)
            </td>
            <td>
                @Html.DisplayFor(modelItem => Model.BirthDate)
            </td>
            <td>
                @Html.DisplayFor(modelItem => Model.IsApproved)
            </td>
        </tr>


    </table>
</body>
</html>






//Create view for [HttpPost]CreatePerson action using helper methods. 
@model Test.Models.Person
@{
  ViewBag.Title = "CreatePerson";
}
<h2>CreatePerson</h2>
@using (Html.BeginForm())
{
    <div class="dataElem">
        <label>PersonId</label>
        @Html.TextBoxFor(m => m.PersonId)
    </div>
    <div class="dataElem">
        <label>First Name</label>
        @Html.TextBoxFor(m => m.FirstName)
    </div>
    <div class="dataElem">
        <label>Last Name</label>
        @Html.TextBoxFor(m => m.LastName)
    </div>

    <input type="submit" value="Submit" />
}