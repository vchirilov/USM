/****************************************************************************
Most of the time developers will create controllers by extending from System.Web.Mvc.Controller

The Controller class provides three key features:
	Action methods
	Action results
	Filters

When you create a controller by deriving from the Controller base class, you get access to 
a set of convenience properties to access informationabout the request. 
These properties include Request, Response, RouteData, HttpContext, and Server

(Analyze in details ControllerContext.png)

*****************************************************************************/

public ActionResult Info()
{
	var queryString = Request.QueryString;
	var cookies = Request.Cookies;

	ViewBag.QueryString = queryString.ToString();
	ViewBag.Cookies = cookies.ToString();

	return View();
}
