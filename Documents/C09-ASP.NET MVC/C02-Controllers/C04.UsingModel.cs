/****************************************************************************
You can send an object to the view by passing it as a parameter to the View method
*****************************************************************************/

public class ViewModelController : Controller
    {
        // GET: ViewModel
        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            return View(date);
        }
    }

//View content
@{
    ViewBag.Title = "Index";
}
<h2>Index</h2>
The day is: @(((DateTime)Model).DayOfWeek)