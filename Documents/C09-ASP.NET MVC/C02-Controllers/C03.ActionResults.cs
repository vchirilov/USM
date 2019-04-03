/****************************************************************************
Instead of working directly with the Response object, we return an object derived from the
ActionResult class that describes what we want the response from our controller to be, such as rendering
a view or redirecting to another URL or action method.

The MVC Framework contains a number of built-in action result types

(Analyze in details ActionResults1.png and ActionResults2.png)
*****************************************************************************/

//The most common kind of response from an action method is to generate HTML and send it to the browser.

//Returning HTML via views, i.e. method View()

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

/****************************************************************************

The view is searched using this algorithm

As soon as the MVC Framework finds a file, then the search stops, and the view that has been found is used to render the response to the client.

• /Views/<ControllerName>/<ViewName>.aspx
• /Views/<ControllerName>/<ViewName>.ascx
• /Views/Shared/<ViewName>.aspx
• /Views/Shared/<ViewName>.ascx
• /Views/<ControllerName>/<ViewName>.cshtml
• /Views/<ControllerName>/<ViewName>.vbhtml
• /Views/Shared/<ViewName>.cshtml
• /Views/Shared/<ViewName>.vbhtml
*****************************************************************************/


//Specifying a view by its path

public class DerivedController : Controller
{
	public ActionResult CustomPath()
	{		
		return View("~/Views/Other/Index.cshtml");
	}
}

//Using redirection

public class ResultController : Controller
    {
        public ViewResult Index()
        {
            return View("~/Views/FolderWithCustomViews/CustomView.cshtml"); 
        }

        public RedirectResult RedirectAction()
        {
            return Redirect("/Home/About");
        }

        public RedirectToRouteResult RedirectActionOnly()
        {
            return RedirectToAction("Contact", "Home");
        }

        public RedirectToRouteResult RedirectRoute()
        {
            return RedirectToRoute(new {controller = "Home", action = "Contact", ID = "MyID"});
        }


    }