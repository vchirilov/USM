/****************************************************************************
In this class we'll immerse into administration. Grant and Revoke right to do some actions.
Let's create add CRUD (create, read, update, delete) operations for products.
*****************************************************************************/

//Add new controller called Admin
public class AdminController : Controller
{
	private IProductRepository repository;
	public AdminController(IProductRepository repo)
	{
		repository = repo;
	}
	public ViewResult Index()
	{
		return View(repository.Products);
	}
}

//Now, let's create a separate layout page for Administration page
//Go to Views/Shared, right click and Add New Item, select "MVC 5 Layout Page (Razor)" and name _AdminLayout

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <link href="~/Content/Admin.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <div>
        @RenderBody()
    </div>
</body>
</html>


//Add Admin.css file for styling. Add to Content folder a new css file called Admin.
BODY, TD { font-family: Segoe UI, Verdana }
H1 { padding: .5em; padding-top: 0; font-weight: bold;
font-size: 1.5em; border-bottom: 2px solid gray; }
DIV#content { padding: .9em; }
TABLE.Grid TD, TABLE.Grid TH { border-bottom: 1px dotted gray; text-align:left; }
TABLE.Grid { border-collapse: collapse; width:100%; }
TABLE.Grid TH.NumericCol, Table.Grid TD.NumericCol {
text-align: right; padding-right: 1em; }
FORM {margin-bottom: 0px; }
DIV.Message { background: gray; color:White; padding: .2em; margin-top:.25em; }
.field-validation-error { color: red; display: block; }
.field-validation-valid { display: none; }
.input-validation-error { border: 1px solid red; background-color: #ffeeee; }
.validation-summary-errors { font-weight: bold; color: red; }
.validation-summary-valid { display: none; }

//Create Index action for Admin controller added earlier (see image 01-Admin-Index-View.jpg)
@model IEnumerable<SportsStore.Models.Entities.Product>

@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
}

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Price)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Category)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Description)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Price)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Category)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.ProductID }) |
            @Html.ActionLink("Details", "Details", new { id=item.ProductID }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.ProductID })
        </td>
    </tr>
}

</table>

//Run the application and go to this URL http://localhost:59058/Admin/Index

//Let's modify little bit the view contant and apply css classes created above. Update Index view with the piece of code below
@model IEnumerable<SportsStore.Models.Entities.Product>
@{
    ViewBag.Title = "Admin: All Products";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
}
<h1>All Products</h1>
<table class="Grid">
    <tr>
        <th>ID</th>
        <th>Name</th>
        <th class="NumericCol">Price</th>
        <th>Actions</th>
    </tr>
    @foreach (var item in Model)
    {
        <tr>
            <td>@item.ProductID</td>
            <td>@Html.ActionLink(item.Name, "Edit", new { item.ProductID })</td>
            <td class="NumericCol">@item.Price.ToString("c")</td>
            <td>
                @using (Html.BeginForm("Delete", "Admin"))
                {
                    @Html.Hidden("ProductID", item.ProductID)
                    <input type="submit" value="Delete" />
                }
            </td>
        </tr>
    }
</table>
<p>@Html.ActionLink("Add a new product", "Create")</p>


//As you see we have all operations in place as add new product, get details and delete a product.