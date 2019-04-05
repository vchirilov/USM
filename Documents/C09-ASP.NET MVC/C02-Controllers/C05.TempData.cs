/****************************************************************************
A redirection causes the browser to submit an entirely new HTTP request, which means that you do not have
access to the details of the original request. If you want to pass data from one request to the next, you can
use the Temp Data feature
*****************************************************************************/

public RedirectToRouteResult UsingTempData()
{
	ViewBag.Text = "Hi via ViewBag";
	
	TempData["Message"] = "Hello";
	TempData["Date"] = DateTime.Now;
	
	return RedirectToAction("Index");
}


<p>The value is @ViewBag.Text</p>

<h2>UsingTempData</h2>
The day is: @(((DateTime)TempData["Date"]).DayOfWeek)
<p />
The message is: @TempData["Message"]