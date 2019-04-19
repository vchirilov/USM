//Now, let's submitt our orders to database and save them
//Create a new class ShippingDetails in SportsStore.Models

namespace SportsStore.Models.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        public string Zip { get; set; }
               
        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}

//Now, we need a button for filling up shipping address.
//Add in Views/Cart/Index.cshtml this piece of code

<p align="center" class="actionButtons">
    <a href="@Model.ReturnUrl">Continue shopping</a>
    @Html.ActionLink("Checkout now", "Checkout") // this piece of code only
</p>


//Now, add Checkout action in Cart controller
public ViewResult Checkout()
{
	return View(new ShippingDetails());
}

//Now, add the view for Checkout action
@model SportsStore.Models.Entities.ShippingDetails
@{
    ViewBag.Title = "SportStore: Checkout";
}
<h2>Check out now</h2>
Please enter your details, and we'll ship your goods right away!
@using (Html.BeginForm())
{
    <h3>Ship to</h3>
    <div>Name: @Html.EditorFor(x => x.Name)</div>
    <h3>Address</h3>
    <div>Line 1: @Html.EditorFor(x => x.Line1)</div>
    <div>Line 2: @Html.EditorFor(x => x.Line2)</div>
    <div>Line 3: @Html.EditorFor(x => x.Line3)</div>
    <div>City: @Html.EditorFor(x => x.City)</div>
    <div>State: @Html.EditorFor(x => x.State)</div>
    <div>Zip: @Html.EditorFor(x => x.Zip)</div>
    <div>Country: @Html.EditorFor(x => x.Country)</div>
    <h3>Options</h3>
    <label>
        @Html.EditorFor(x => x.GiftWrap)
        Gift wrap these items
    </label>
    <p align="center">
        <input class="actionButtons" type="submit" value="Complete order" />
    </p>
}

//Displaying Validation Errors.
//Add in Checkout.cshtml view this piece of code.

@model SportsStore.Models.Entities.ShippingDetails
@{
    ViewBag.Title = "SportStore: Checkout";
}
<h2>Check out now</h2>
Please enter your details, and we'll ship your goods right away!
@using (Html.BeginForm())
{
    @Html.ValidationSummary() // this piece of code

    <h3>Ship to</h3>
    <div>Name: @Html.EditorFor(x => x.Name)</div>
    <h3>Address</h3>
    <div>Line 1: @Html.EditorFor(x => x.Line1)</div>
    <div>Line 2: @Html.EditorFor(x => x.Line2)</div>
    <div>Line 3: @Html.EditorFor(x => x.Line3)</div>
    <div>City: @Html.EditorFor(x => x.City)</div>
    <div>State: @Html.EditorFor(x => x.State)</div>
    <div>Zip: @Html.EditorFor(x => x.Zip)</div>
    <div>Country: @Html.EditorFor(x => x.Country)</div>
    <h3>Options</h3>
    <label>
        @Html.EditorFor(x => x.GiftWrap)
        Gift wrap these items
    </label>
    <p align="center">
        <input class="actionButtons" type="submit" value="Complete order" />
    </p>
}

//Added Checkout [HttpPost] action.
[HttpPost]
public ViewResult Checkout(ShippingDetails details)
{
	if (ModelState.IsValid)
	{
		//Save to database
	}
	else
	{
		return View(details);
	}

	return View("Thanks");
}
		
//Add CSS in Content/Site.css
.input-validation-error {
    border: 1px solid #f00;
    background-color: #fee;
}

//Add a view in Views/Cart called Thanks
@{
    ViewBag.Title = "Thanks";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Thank you.</h2>


//Saving the order to database as homework.