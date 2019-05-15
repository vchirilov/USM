/************************************************************************************************************
Model binding is the process of creating .NET objects using the data sent by the browser in an HTTP request.
************************************************************************************************************/
//Create a new MVC project.

//Let's create our model classes in Model folder of the MVC project
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

//Update default Home controller with the code below

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData = {
            new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
            new Person {PersonId = 2, FirstName = "Steven", LastName = "Sanderson", Role = Role.Admin},
            new Person {PersonId = 3, FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
            new Person {PersonId = 4, FirstName = "John", LastName = "Smith", Role = Role.User},
            new Person {PersonId = 5, FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };

        public ActionResult Index(int id)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).First();
            return View(dataItem);
        }
    }
}

//Update the Index view with the code below

@model ModelBinding.Models.Person
@{
    ViewBag.Title = "Index";
}
<h2>Person</h2>
<div><label>ID:</label>@Html.DisplayFor(m => m.PersonId)</div>
<div><label>First Name:</label>@Html.DisplayFor(m => m.FirstName)</div>
<div><label>Last Name:</label>@Html.DisplayFor(m => m.LastName)</div>
<div><label>Role:</label>@Html.DisplayFor(m => m.Role)</div>

//Finally, add some CSS styles to the /Content/Site.css
label { display: inline-block; width: 100px; font-weight:bold; margin: 5px;}
form label { float: left;}
input.text-box { float: left; margin: 5px;}
button[type=submit] { margin-top: 5px; float: left; clear: left;}
form div {clear: both;}

//To see the model binding at work, start the application and navigate to http://localhost:55152/Home/Index/1

//The process by which the URL segment was converted into the int method argument is an example of model binding. 
//There can be multiple model binders in an MVC application, and each binder can be responsible for binding one or more model types.

//Model binders are defined by the IModelBinder interface
namespace System.Web.Mvc
{
	public interface IModelBinder
	{
		object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext);
	}
}

//When the action invoker needs to call an action method, it looks at the parameters that the method defines 
//and finds the responsible model binder for the type of each one.
//In our simple example, the action invoker would examine the Index method and find that it has one
//int parameter. It would then locate the binder responsible for int values and call its BindModel method.

//Default Model Binder. How it works?
//Although an application can define custom model binders, most just rely on the built-in binder class, DefaultModelBinder.

//DefaultModelBinder searches four locations. The search is stopped as soon as a value is found.

//Request.Form 			Values provided by the user in HTML form elements.
//RouteData.Values 		The values obtained using the application routes.
//Request.QueryString 	Data included in the query string portion of the request URL.
//Request.Files 		Files that have been uploaded as part of the request.

//For example, in our simple example, the DefaultModelBinder looks for a value for our id parameter as follows:
1. Request.Form["id"]
2. RouteData.Values["id"]
3. Request.QueryString["id"]
4. Request.Files["id"]

//How DefaultModelBinder convert complex types?

//DefaultModelBinder class uses reflection to obtain the set of public properties and then binds to each of them in turn.

//Let's see how it works with a real example. Create 2 more actions, like below.

public ActionResult CreatePerson()
{
	return View(new Person());
}

[HttpPost]
public ActionResult CreatePerson(Person model)
{
	return View("Index", model);
}

//Create view for CreatePerson action

@model ModelBinding.Models.Person
@{
    ViewBag.Title = "CreatePerson";
}
<h2>Create Person</h2>
@using (Html.BeginForm())
{
    <div>
        @Html.LabelFor(m => m.PersonId)
        @Html.EditorFor(m => m.PersonId)
    </div>
    <div>
        @Html.LabelFor(m => m.FirstName)
        @Html.EditorFor(m => m.FirstName)
    </div>
    <div>
        @Html.LabelFor(m => m.LastName)
        @Html.EditorFor(m => m.LastName)
    </div>
    <div>
        @Html.LabelFor(m => m.Role)
        @Html.EditorFor(m => m.Role)
    </div>
    <div>
        <button type="submit">Submit</button>
    </div>
}

//If you look for property Address it is empty

//Update CreatePerson view by adding this code before Submit button
<div>
	@Html.LabelFor(m => m.HomeAddress.City)
	@Html.EditorFor(m => m.HomeAddress.City)
</div>
<div>
	@Html.LabelFor(m => m.HomeAddress.Country)
	@Html.EditorFor(m => m.HomeAddress.Country)
</div>

//Update Index view by adding this code
<div><label>City:</label>@Html.DisplayFor(m => m.HomeAddress.City)</div>
<div><label>Country:</label>@Html.DisplayFor(m => m.HomeAddress.Country)</div>


//Using Custom Prefixes

//Add new class AddressSummary in Models folder
public class AddressSummary
{
	public string City { get; set; }
	public string Country { get; set; }
}

//Add new action DisplaySummary inb Home controller. This action takes as parameter AddressSummary.
public ActionResult DisplaySummary(AddressSummary summary)
{
	return View(summary);
}

//Create a view for this action
@model ModelBinding.Models.AddressSummary
@{
    ViewBag.Title = "DisplaySummary";
}
<h2>Address Summary</h2>
<div><label>City:</label>@Html.DisplayFor(m => m.City)</div>
<div><label>Country:</label>@Html.DisplayFor(m => m.Country)</div>

//Now, change in the form action (CreatePerson view)
@using(Html.BeginForm("DisplaySummary", "Home"))

//If you run the application, the binding doesn't work, why?

//Add attribute Bind[] in the action DisplaySummary
public ActionResult DisplaySummary([Bind(Prefix="HomeAddress")]AddressSummary summary) {
return View(summary);
}

//It is possible to exclude binding for some of the properties by setting property Exclude in Bind attribute
[Bind(Prefix="HomeAddress", Exclude="Country")]



//Binding to Arrays and Collections

//Add new action 
public ActionResult Names(string[] names)
{
	names = names ?? new string[0]; //pay attention to this operator
	return View(names);
}

//Create view for the above action
@model string[]

@{
    ViewBag.Title = "Names";
}
<h2>Names</h2>
@if (Model.Length == 0)
{
    using (Html.BeginForm())
    {
        for (int i = 0; i < 3; i++)
        {
            <div><label>@(i + 1):</label>@Html.TextBox("names")</div>
        }
        <button type="submit">Submit</button>
    }
}
else
{
    foreach (string str in Model)
    {
        <p>@str</p>
    }
    @Html.ActionLink("Back", "Names");
}

//This view generates this html code

<form action="/Home/Names" method="post">
	<div><label>1:</label><input id="names" name="names" type="text" value="" /></div>
	<div><label>2:</label><input id="names" name="names" type="text" value="" /></div>
	<div><label>3:</label><input id="names" name="names" type="text" value="" /></div>
	<button type="submit">Submit</button>
</form>