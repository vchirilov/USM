/****************************************************************************
Instead of working directly with the Response object, we return an object derived from the
ActionResult class that describes what we want the response from our controller to be, such as rendering
a view or redirecting to another URL or action method.

The MVC Framework contains a number of built-in action result types

(Analyze in details ActionResults1.png and ActionResults2.png)

As soon as the MVC Framework finds a file, then the search stops, and the view that has been found is used to render the response to the client.

The view is searched using this algorithm

• /Views/<ControllerName>/<ViewName>.aspx
• /Views/<ControllerName>/<ViewName>.ascx
• /Views/Shared/<ViewName>.aspx
• /Views/Shared/<ViewName>.ascx
• /Views/<ControllerName>/<ViewName>.cshtml
• /Views/<ControllerName>/<ViewName>.vbhtml
• /Views/Shared/<ViewName>.cshtml
• /Views/Shared/<ViewName>.vbhtml
*****************************************************************************/


public class DerivedController : Controller
{
	public ActionResult Index()
	{
		ViewBag.Message = "Hello from the DerivedController Index method";
		//In this case the view name would be the same as action name
		//return View(); 
		
		//In this case the view name is specified
		return View("MyView");
	}
}

//Specifying a view by its path

public class DerivedController : Controller
{
	public ActionResult CustomPath()
	{		
		return View("~/Views/HRDepartment/Index.cshtml");
	}
}

//Using redirection
public class HomeController : Controller
{

	//Redirecting to a Literal URL
	public RedirectResult RedirectToLiteral()
	{
		return Redirect("/Home/About");
	}

	//Redirecting to an Action Method
	public RedirectToRouteResult RedirectToAction()
	{
		return RedirectToAction("Contact", "Home");
	}

	//Redirecting to a Routing System URL
	public RedirectToRouteResult RedirectToRoute()
	{
		return RedirectToRoute(new {controller = "Home", action = "Contact", ID = "MyID"});
	}
}