/***********************************************************************************
As you see all of the products in the database are displayed on a single page.
Let's add pagination.
***********************************************************************************/
public int PageSize = 4;

public ViewResult List(int page = 1)
{
	return View(repository.Products
		.OrderBy(p => p.ProductID)
		.Skip((page - 1) * PageSize).Take(PageSize));
}

//You can access products by page using this URL: http://localhost:59058/Product/List?page=2

//This kind of pagination is not very usefull for users, so let's do some improvements.
//Add PagingInfo class into WebUI.Models folder

public class PagingInfo
{
	public int TotalItems { get; set; }
	public int ItemsPerPage { get; set; }
	public int CurrentPage { get; set; }
	public int TotalPages
	{
		get
		{
			return (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
		}
	}
}

//Add new folder called HtmlHelpers into WebUI and inside this folder a new class PagingHelpers
//which is actually an extension to class HtmlHelper.

 public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
{
	StringBuilder result = new StringBuilder();

	for (int i = 1; i <= pagingInfo.TotalPages; i++)
	{
		TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag

		tag.MergeAttribute("href", pageUrl(i));

		tag.InnerHtml = i.ToString();

		if (i == pagingInfo.CurrentPage)
			tag.AddCssClass("selected");

		result.Append(tag.ToString());
	}
	return MvcHtmlString.Create(result.ToString());
}

//Currently product object plays the role of data model for the view List. 
//However we need to send also PagingInfo object into the view if we want to use PageLinks. 
//It can be done by embedding these two objects in one class, let's say ProductsListViewModel.

//Create a new class ProductsListViewModel in WebUI.Models folder
public class ProductsListViewModel
{
	public IEnumerable<Product> Products { get; set; }
	public PagingInfo PagingInfo { get; set; }
}

//Now update the action List as indicated below
public ViewResult List(int page = 1)
{
	ProductsListViewModel model = new ProductsListViewModel
	{
		Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),

		PagingInfo = new PagingInfo
		{
			CurrentPage = page,
			ItemsPerPage = PageSize,
			TotalItems = repository.Products.Count()
		}
	};

	return View(model);
}

//Now we can use pagination in our view. Apply these changes to view List

@using SportsStore.WebUI.HtmlHelpers
@model SportsStore.WebUI.Models.ProductsListViewModel
@{
    ViewBag.Title = "Products";
}
@foreach (var p in Model.Products)
{
    <div class="item">
        <h3>@p.Name</h3>
        @p.Description
        <h4>@p.Price.ToString("c")</h4>
    </div>
}
<div class="pager">
    @Html.PageLinks(Model.PagingInfo, x => Url.Action("List", new { page = x }))
</div>


//Now you can run application and see how it looks like.
//http://localhost:59058/Product/List

//Improving the URLs
//URLs looks like this http://localhost/?page=2, however we can meke them look like http://localhost/Page2
//Go to RouteConfig file and add this route

routes.MapRoute(
	name: null,
	url: "Page{page}",
	defaults: new { Controller = "Product", action = "List" }
	);


//Now we can access by this URL: http://localhost:59058/Page2

//Styling the Content

//Apply new content for Layout page (file _Layout.cshtml)

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
        We will put something useful here later
    </div>
    <div id="content">
        @RenderBody()
    </div>
</body>
</html>

//Append to Site.css file this stylesheet
BODY { font-family: Cambria, Georgia, "Times New Roman"; margin: 0; }
DIV#header DIV.title, DIV.item H3, DIV.item H4, DIV.pager A {
font: bold 1em "Arial Narrow", "Franklin Gothic Medium", Arial;
}
DIV#header { background-color: #444; border-bottom: 2px solid #111; color: White; }
DIV#header DIV.title { font-size: 2em; padding: .6em; }
DIV#content { border-left: 2px solid gray; margin-left: 9em; padding: 1em; }
DIV#categories { float: left; width: 8em; padding: .3em; }
DIV.item { border-top: 1px dotted gray; padding-top: .7em; margin-bottom: .7em; }
DIV.item:first-child { border-top:none; padding-top: 0; }
DIV.item H3 { font-size: 1.3em; margin: 0 0 .25em 0; }
DIV.item H4 { font-size: 1.1em; margin:.4em 0 0 0; }
DIV.pager { text-align:right; border-top: 2px solid silver;
padding: .5em 0 0 0; margin-top: 1em; }
DIV.pager A { font-size: 1.1em; color: #666; text-decoration: none;
padding: 0 .4em 0 .4em; }
DIV.pager A:hover { background-color: Silver; }
DIV.pager A.selected { background-color: #353535; color: White; }

//Refresh the page (short-key Ctrl+F5)


//Creating a Partial View

//Let's create a partial view, which is a fragment of content that is embedded in anotherview. 
//Partial views are contained within their own files and are reusable across multiple views, which can help reduce duplication
//To add the partial view, right-click the /Views/Shared folder in the SportsStore.WebUI project and select Add View from the pop-up menu
//Set the name of the view to ProductSummary and add code below

@model SportsStore.Models.Entities.Product

<div class="item">
    <h3>@Model.Name</h3>
    @Model.Description
    <h4>@Model.Price.ToString("c")</h4>
</div>


//Now we need to update Views/Products/List.cshtml so that it uses the partial view.






