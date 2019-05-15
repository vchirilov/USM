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


//Editing Products
//Now, let's add Edit controller
public ViewResult Edit(int productId)
{
	Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
	return View(product);
}

//Create Edit View. There are several methods for creating Edit view 
//First - By using scaffolding from Visual Studio
//Second - By using special helper method @Html.EditForModel()

@model SportsStore.Models.Entities.Product
@{
    ViewBag.Title = "Admin: Edit " + @Model.Name;
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
}
<h1>Edit @Model.Name</h1>
@using (Html.BeginForm())
{
    @Html.EditorForModel()
    <input type="submit" value="Save" />
    @Html.ActionLink("Cancel and return to List", "Index")
}

//Run the application

//@Html.EditForModel() is handy because it uses a single line of code to generate all elements, however the result is quite ugly 
//and ProductId which should be a hidden field is actually shown.

//You can use "model metadata" in order to generate fields more accuratelly.
 public class Product
{
	[HiddenInput(DisplayValue = false)] //this attribute (this requires package Microsoft.asp.net mvc)
	public int ProductID { get; set; }

	public string Name { get; set; }

	[DataType(DataType.MultilineText)] //this attribute
	public string Description { get; set; }

	public decimal Price { get; set; }

	public string Category { get; set; }
}

//Run the application

//Let'sadd some CSS to Admin.css file to improve appearance

.editor-field { margin-bottom: .8em; }
.editor-label { font-weight: bold; }
.editor-label:after { content: ":" }
.text-box { width: 25em; }
.multi-line { height: 5em; font-family: Segoe UI, Verdana; }

//Updating the Product Repository
//Now, repository has no method for saving new or updated products. Let's add this possibility.

//Update interface IProductRepository
public interface IProductRepository
{
	IQueryable<Product> Products { get; }
	void SaveProduct(Product product); //this piece of code
}

//Add this method to class EFProductRepository 
public void SaveProduct(Product product)
{
	if (product.ProductID == 0)
	{
		context.Products.Add(product);
	}
	else
	{
		Product dbEntry = context.Products.Find(product.ProductID);

		if (dbEntry != null)
		{
			dbEntry.Name = product.Name;
			dbEntry.Description = product.Description;
			dbEntry.Price = product.Price;
			dbEntry.Category = product.Category;
		}
	}
	context.SaveChanges();
}
		
//Now, we have to add [HttpPost] action for Edit in order to finish with Edit.
//Add, new Edit action in controller Admin
[HttpPost]
public ActionResult Edit(Product product)
{
	if (ModelState.IsValid)
	{
		repository.SaveProduct(product);
		
		return RedirectToAction("Index");
	}
	else
	{
		// there is something wrong with the data values
		return View(product);
	}
}

//Adding Model Validation
//Model validation is added in model class. DON'T CONFUSE MODEL VALIDATION ATTRIBUTES WITH MODEL METADATA
public class Product
{
	[HiddenInput(DisplayValue = false)]
	public int ProductID { get; set; }

	[Required(ErrorMessage = "Please enter a product name")]
	public string Name { get; set; }

	[DataType(DataType.MultilineText)]
	[Required(ErrorMessage = "Please enter a description")]
	public string Description { get; set; }

	[Required]
	[Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
	public decimal Price { get; set; }

	[Required(ErrorMessage = "Please specify a category")]
	public string Category { get; set; }
}


//Creating New Products

//Add new action called Create
public ViewResult Create()
{
	return View("Edit", new Product()); //As you see Edit view is reused
}

//Edit view uses @Html.BeginForm() helper method

@model SportsStore.Domain.Model.Product
@{
    ViewBag.Title = "Admin: Edit " + @Model.Name;
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
}
<h1>Edit @Model.Name</h1>
@using (Html.BeginForm("Edit", "Admin")) // this piece of code
{
    @Html.EditorForModel()
    <input type="submit" value="Save" />
    @Html.ActionLink("Cancel and return to List", "Index")
} 

//Deleting Products

//Add new method in interface IProductRepository
public interface IProductRepository
{
	IQueryable<Product> Products { get; }
	void SaveProduct(Product product);
	Product DeleteProduct(int productID);
}

//Add implementation in class EFProductRepository
public Product DeleteProduct(int productID)
{
	Product dbEntry = context.Products.Find(productID);
	
	if (dbEntry != null)
	{
		context.Products.Remove(dbEntry);
		context.SaveChanges();
	}
	return dbEntry;
}

//And, finally add action method Delete
[HttpPost]
public ActionResult Delete(int productId)
{
	Product deletedProduct = repository.DeleteProduct(productId);

	return RedirectToAction("Index");
}













































