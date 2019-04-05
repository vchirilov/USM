/****************************************************************************

*****************************************************************************/

public ActionResult Index()
{
	ViewBag.Fruits = new string[] { "Apple", "Orange", "Pear" };
	ViewBag.Cities = new string[] { "New York", "London", "Paris" };
	string message = "This is an HTML element: <input>";
	return View((object)message);
}



@model string
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
        Here are the fruits:
        @foreach (string str in (string[])ViewBag.Fruits)
        {
            <b>@str </b>
        }
    </div>
    <div>
        Here are the cities:
        @foreach (string str in (string[])ViewBag.Cities)
        {
            <b>@str </b>
        }
    </div>
    <div>
        Here is the message:
        <p>@Model</p>
    </div>
</body>
</html>