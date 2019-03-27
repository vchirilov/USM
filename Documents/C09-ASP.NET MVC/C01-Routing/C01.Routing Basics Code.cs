[Adding Dynamic Output]
===================================================================================================
public class HomeController : Controller
{
	public ViewResult Index()
	{
		int hour = DateTime.Now.Hour;
		ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
		return View();
	}
}




@{
    Layout = null;
}
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <div>
        @ViewBag.Greeting World (from the view)
    </div>
</body>
</html>


[Reading Custom Segment Variables]
===================================================================================================

public class HomeController : Controller
{
	public ActionResult CustomVariable()
	{
		ViewBag.Controller = "Home";
		ViewBag.Action = "CustomVariable";
		ViewBag.CustomVariable = RouteData.Values["id"];
		return View();
	}
}




@{
    Layout = null;
}
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Custom Variable</title>
</head>
<body>
    <div>The controller is: @ViewBag.Controller</div>
    <div>The action is: @ViewBag.Action</div>
    <div>The custom variable is: @ViewBag.CustomVariable</div>
</body>
</html>


[Using Custom Variables as Action Method Parameters]
===================================================================================================


public class HomeController : Controller
{
	 public ActionResult CustomVariable(string id)
	 {
		ViewBag.Controller = "Home";
		ViewBag.Action = "CustomVariable";
		ViewBag.CustomVariable = id;
		return View();
	 }
}

//The view remain the same.
		