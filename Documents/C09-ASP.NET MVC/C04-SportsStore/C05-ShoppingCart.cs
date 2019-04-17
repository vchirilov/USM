/****************************************************************************
In this lesson we'll create a shopping cart as you would probably have seen in internet markets
*****************************************************************************/

//Add new class CartLinein project sportsstore.Models

public class CartLine
{
	public Product Product { get; set; }
	public int Quantity { get; set; }
}

public class Cart
{
	private List<CartLine> goods = new List<CartLine>();

	public void AddItem(Product product, int quantity)
	{
		CartLine line = goods.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

		if (line == null)
		{
			goods.Add(new CartLine {Product = product, Quantity = quantity});
		}
		else
		{
			line.Quantity += quantity;
		}
	}
	public void RemoveLine(Product product)
	{
		goods.RemoveAll(l => l.Product.ProductID == product.ProductID);
	}
	public decimal ComputeTotalValue()
	{
		return goods.Sum(e => e.Product.Price * e.Quantity);
	}
	public void Clear()
	{
		goods.Clear();
	}
	public IEnumerable<CartLine> Lines
	{
		get { return goods; }
	}
}

//We need to edit the Views/Shared/ProductSummary.cshtml

@model SportsStore.Models.Entities.Product
<div class="item">
    <h3>@Model.Name</h3>
    @Model.Description
	
    @using (Html.BeginForm("AddToCart", "Cart"))
    {
        @Html.HiddenFor(x => x.ProductID)
        @Html.Hidden("returnUrl", Request.Url.PathAndQuery)
        <input type="submit" value="+ Add to cart" />
    }
	
    <h4>@Model.Price.ToString("c")</h4>
</div>

//Run the application

//Append styles to Content/Site.css
FORM {
    margin: 0;
    padding: 0;
}

DIV.item FORM {
    float: right;
}

DIV.item INPUT {
    color: White;
    background-color: #333;
    border: 1px solid black;
    cursor: pointer;
}

//Run the application

//Implementing the Cart controller. Add new controller called Cart

public class CartController : Controller
{
	private IProductRepository repository;
	public CartController(IProductRepository repository)
	{
		this.repository = repository;
	}

	public RedirectToRouteResult AddToCart(int productId, string returnUrl)
	{
		Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

		if (product != null)
		{
			GetCart().AddItem(product, 1);
		}
		return RedirectToAction("Index", new { returnUrl });
	}

	public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
	{
		Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

		if (product != null)
		{
			GetCart().RemoveLine(product);
		}
		return RedirectToAction("Index", new { returnUrl });
	}

	private Cart GetCart()
	{
		Cart cart = (Cart)Session["Cart"]; //Session object is used for keeping session state

		if (cart == null)
		{
			cart = new Cart();
			Session["Cart"] = cart;
		}

		return cart;
	}
}
	
//Displaying the Contents of the Cart. Before it we need a model class CartIndexViewModel that will be used by Index action.

namespace SportsStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}

//Add Index action in Cart controller

public ViewResult Index(string returnUrl)
{
	return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
}

//Now, add the view for Index action, created above
@model SportsStore.WebUI.Models.CartIndexViewModel
@{
    ViewBag.Title = "Sports Store: Your Cart";
}
<h2>Your cart</h2>
<table width="60%" align="center">
    <thead>
        <tr>
            <th align="left">Quantity</th>
            <th align="left">Item</th>
            <th align="right">Price</th>
            <th align="right">Subtotal</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var line in Model.Cart.Lines)
        {
            <tr>
                <td align="left">@line.Quantity</td>
                <td align="left">@line.Product.Name</td>
                <td align="right">@line.Product.Price.ToString("c")</td>
                <td align="right">@((line.Quantity * line.Product.Price).ToString("c"))</td>
        </tr>
    }
    </tbody>
    <tfoot>
        <tr>
            <td colspan="3" align="right">Total:</td>
            <td align="right">
                @Model.Cart.ComputeTotalValue().ToString("c")
            </td>
        </tr>
    </tfoot>
</table>
<p align="center" class="actionButtons">
    <a href="@Model.ReturnUrl">Continue shopping</a>
</p>

//And the last action is to style the content. Append this piece of styling to Content/Site.css
H2 {
    margin-top: 0.3em
}

TFOOT TD {
    border-top: 1px dotted gray;
    font-weight: bold;
}

.actionButtons A, INPUT.actionButtons {
    font: .8em Arial;
    color: White;
    margin: .5em;
    text-decoration: none;
    padding: .15em 1.5em .2em 1.5em;
    background-color: #353535;
    border: 1px solid black;
}