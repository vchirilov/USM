ALTER TABLE [dbo].[Products] ADD ImageData varbinary(max) NULL;

ALTER TABLE [dbo].[Products] ADD ImageMimeType varchar(50) NULL;

//Enhancing the Domain Model. Add 2 properties to Product class
namespace SportsStore.Models.Entities
{
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

        public byte[] ImageData { get; set; } // this one

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; } //this one
    }
}

//Modify the Views/Admin/Edit.cshtml view

@model SportsStore.Models.Entities.Product
@{
    ViewBag.Title = "Admin: Edit " + @Model.Name;
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
}

<h1>Edit @Model.Name</h1>
@using (Html.BeginForm("Edit", "Admin", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    @Html.EditorForModel()
    <div class="editor-label">Image</div>
    <div class="editor-field">
        @if (Model.ImageData == null)
        {
            @:None
        }
        else
        {
            <img width="150" height="150"
                 src="@Url.Action("GetImage", "Product", new { Model.ProductID })" />
        }
        <div>Upload new image: <input type="file" name="Image" /></div>
    </div>
    <input type="submit" value="Save" />
    @Html.ActionLink("Cancel and return to List", "Index")
}

//Update Edit action from Admin controller
[HttpPost]
public ActionResult Edit(Product product, HttpPostedFileBase image)
{
	if (ModelState.IsValid)
	{
		if (image != null)
		{
			product.ImageMimeType = image.ContentType;
			product.ImageData = new byte[image.ContentLength];
			image.InputStream.Read(product.ImageData, 0, image.ContentLength);
		}
		repository.SaveProduct(product);
		TempData["message"] = string.Format("{0} has been saved", product.Name);
		return RedirectToAction("Index");
	}
	else
	{
		// there is something wrong with the data values
		return View(product);
	}
}

//Update method SaveProduct from EFProductRepository
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
			dbEntry.ImageData = product.ImageData; 			//this piece of code
			dbEntry.ImageMimeType = product.ImageMimeType;	//this piece of code
		}
	}
	context.SaveChanges();
}

//Now, in order to display image we need to extract image from database. In Product controller add a new method 
public FileContentResult GetImage(int productId)
{
	Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
	if (prod != null)
	{
		return File(prod.ImageData, prod.ImageMimeType);
	}
	else
	{
		return null;
	}
}


//All that remains is to display the images alongside the product description in the product catalog. 
//Edit the Views/Shared/ProductSummary.cshtml view
@model SportsStore.Models.Entities.Product
<div class="item">

    <div style="float:left;margin-right:20px">
        <img width="75" height="75" src="@Url.Action("GetImage", "Product", new { Model.ProductID })" />
    </div>


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
