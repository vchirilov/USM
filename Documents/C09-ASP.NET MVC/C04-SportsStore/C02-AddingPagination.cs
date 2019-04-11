/***********************************************************************************
***********************************************************************************/
public int PageSize = 4;

public ViewResult List(int page = 1)
{
	return View(repository.Products
		.OrderBy(p => p.ProductID)
		.Skip((page - 1) * PageSize).Take(PageSize));
}