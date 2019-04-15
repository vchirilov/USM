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