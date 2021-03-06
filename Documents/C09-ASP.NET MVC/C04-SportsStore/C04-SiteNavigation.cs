/****************************************************************************
The SportsStore application will be a lot more usable if we let customers navigate products by category.
*****************************************************************************/

//Add into the ProductsListViewModel, this piece of code

namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; } // this piece of code to be added
    }
}

//The next step is to update the ProductControllerclass so that the List action method will filter 
//Product objects by category and use the new property we added to the view model to indicate which category has been selected.

public ViewResult List(string category, int page = 1)
{
	ProductsListViewModel viewModel = new ProductsListViewModel
	{
	Products = repository.Products
	.Where(p => category == null || p.Category == category) // this piece of code to be added
	.OrderBy(p => p.ProductID)
	.Skip((page - 1) * PageSize)
	.Take(PageSize),
		PagingInfo = new PagingInfo
		{
			CurrentPage = page,
			ItemsPerPage = PageSize,
			TotalItems = repository.Products.Where(p => category == null || p.Category == category).Count() // this piece of code to be added
		},
		CurrentCategory = category // this piece of code to be added
	};
	return View(viewModel);
}

//Run the application with this URL http://localhost:59058?category=Soccer

//Using query parameters is not very good option for end user, so let's add some routing improvements.

public class RouteConfig
{
	public static void RegisterRoutes(RouteCollection routes)
	{
		routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

		routes.MapRoute(
			null,
			"",
			new {controller = "Product", action = "List", category = (string)null, page = 1}
			);

		routes.MapRoute(
			null,
			"Page{page}",
			new { controller = "Product", action = "List", category = (string)null },
			new { page = @"\d+" }
			);

		routes.MapRoute(
			null,
			"{category}",
			new { controller = "Product", action = "List", page = 1 }
			);

		routes.MapRoute(
			null,
			"{category}/Page{page}",
			new { controller = "Product", action = "List" },
			new { page = @"\d+" }
			);

		routes.MapRoute(null, "{controller}/{action}");
	}
}


//Now, update @Html.PageLinks from List view.

@using SportsStore.WebUI.HtmlHelpers

@model SportsStore.WebUI.Models.ProductsListViewModel

@{
    ViewBag.Title = "Products";
}
@foreach (var p in Model.Products)
{
    Html.RenderPartial("ProductSummary", p);
}
<div class="pager">
    @Html.PageLinks(Model.PagingInfo, x => Url.Action("List", new {page = x, category = Model.CurrentCategory})) // this piece of code updated.
</div>

//Now run the application with these URLs: 
//http://localhost:59058/Page1
//http://localhost:59058//Chees/Page1


//Building a Category Navigation Menu

//The ASP.NET MVC Framework has the concept of child actions. A child action relies on the HTML helper method called RenderAction, 
//which lets you include the output from an arbitrary action method in the current view.

//Create a new controller called NavController


namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        public string Menu()
        {
            return "Hello from NavController";
        }
    }
}

//An action can be triggered from the view by using helper method @Html.RenderAction()
//Let's update layout page like this

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>@ViewBag.Title</title>
    <link href="~/Content/Site.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <div id="header">
        <div class="title">SPORTS STORE</div>
    </div>
    <div id="categories">
        @{ Html.RenderAction("Menu", "Nav"); } // this piece of code
    </div>
    <div id="content">
        @RenderBody()
    </div>
</body>
</html> 

//Now, update NavController with the code below

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}

//Now, create a partial view for action Menu
@model IEnumerable<string>

@Html.ActionLink("Home", "List", "Product")

@foreach (var item in Model)
{
    @Html.RouteLink(item, new { controller = "Product", action = "List", category = item, page = 1 })
}

//Run the application. The links we generate looks pretty ugly isn't it?
//Append the styles below to /Content/Site.css

DIV#categories A {
    font: bold 1.1em "Arial Narrow","Franklin Gothic Medium",Arial;
    display: block;
    text-decoration: none;
    padding: .6em;
    color: Black;
    border-bottom: 1px solid silver;
}

    DIV#categories A.selected {
        background-color: #666;
        color: White;
    }

    DIV#categories A:hover {
        background-color: #CCC;
    }

    DIV#categories A.selected:hover {
        background-color: #666;
    }
	
//Now, let's highlight selected category in the side bar menu.
//Update Menu action with this code
 public PartialViewResult Menu(string category = null)
{
	IEnumerable<string> categories = repository.Products
	.Select(x => x.Category)
	.Distinct()
	.OrderBy(x => x);

	ViewBag.SelectedCategory = category; // this piece of code

	return PartialView(categories);
}

//Update Menu partial view
@model IEnumerable<string>

@Html.ActionLink("Home", "List", "Product")

@foreach (var item in Model)
{
    @Html.RouteLink(
    item, 
    new { controller = "Product", action = "List", category = item, page = 1 }, 
    new { @class = item == ViewBag.SelectedCategory ? "selected" : null })   
}


//Run the application.



