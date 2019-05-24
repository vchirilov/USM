/***************************************************************************************************************
Web API is part of the core ASP.NET platform. It allows you to quickly and easily create Web services 
that provide an API to HTTP clients, known as Web APIs.

The Web API feature is based on adding a special kind of controller to an MVC Framework application.
This kind of controller, called an API Controller, has two distinctive characteristics:

1. Action methods return model, rather than ActionResult, objects
2. Action methods selected based on the HTTP method used in the request

API controller can support any Web-enabled client, but the most frequent use is to service Ajax
requests from Web applications.

***************************************************************************************************************/

//Creating the Web API Application

//Create a new model class Reservation
namespace WebServices.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
    }
}

//We are going to apply repository pattern, so create in the same folder a new interface IReservationRepository
namespace WebServices.Models
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation Get(int id);
        Reservation Add(Reservation item);
        void Remove(int id);
        bool Update(Reservation item);
    }
}

//Create a class ReservationRepository that implements above interface
public class ReservationRepository : IReservationRepository
{
	private List<Reservation> data = new List<Reservation> {
		new Reservation {ReservationId = 1, ClientName = "Adam", Location = "London"},
		new Reservation {ReservationId = 2, ClientName = "Steve", Location = "New York"},
		new Reservation {ReservationId = 3, ClientName = "Jacqui", Location = "Paris"},
		};

	private static ReservationRepository repo = new ReservationRepository();

	public static IReservationRepository getRepository()
	{
		return repo;
	}

	public IEnumerable<Reservation> GetAll()
	{
		return data;
	}

	public Reservation Get(int id)
	{
		var matches = data.Where(r => r.ReservationId == id);
		return matches.Count() > 0 ? matches.First() : null;
	}

	public Reservation Add(Reservation item)
	{
		item.ReservationId = data.Count + 1;
		data.Add(item);
		return item;
	}

	public void Remove(int id)
	{
		Reservation item = Get(id);
		if (item != null)
		{
			data.Remove(item);
		}
	}

	public bool Update(Reservation item)
	{
		Reservation storedItem = Get(item.ReservationId);
		if (storedItem != null)
		{
			storedItem.ClientName = item.ClientName;
			storedItem.Location = item.Location;
			return true;
		}
		else
		{
			return false;
		}
	}
}

//There is no persistence of changes in this repository. Adding persistance through EntityFramework would be a homework.

//Now, let's add a normal MVC controller just for default page of the application. Let's use existing one which is Home
public class HomeController : Controller
{
	public ActionResult Index()
	{
		ViewBag.Title = "Home Page";

		return View();
	}
}

//Add view for Index action.
@{ ViewBag.Title = "Index";}

@section scripts {
    <script src="~/Scripts/jquery.unobtrusive-ajax.js"></script>
}
<div id="summaryDisplay" class="display">
    <h4>Reservations</h4>
    <table>
        <thead>
            <tr>
                <th class="selectCol"></th>
                <th class="nameCol">Name</th>
                <th class="locationCol">Location</th>
            </tr>
        </thead>
        <tbody id="tableBody">
            <tr><td colspan="3">The data is loading</td></tr>
        </tbody>
    </table>
    <div id="buttonContainer">
        <button id="refresh">Refresh</button>
        <button id="add">Add</button>
        <button id="edit">Edit</button>
        <button id="delete">Delete</button>
    </div>
</div>
<div id="addDisplay" class="display">
    <h4>Add New Reservation</h4>
    @{
        AjaxOptions addAjaxOpts = new AjaxOptions
        {
            // options will go here
        };
    }
    @using (Ajax.BeginForm(addAjaxOpts))
    {
        @Html.Hidden("ReservationId", 0)
        <p><label>Name:</label>@Html.Editor("ClientName")</p>
        <p><label>Location:</label>@Html.Editor("Location")</p>
        <button type="submit">Submit</button>
    }
</div>
<div id="editDisplay" class="display">
    <h4>Edit Reservation</h4>
    <form id="editForm">
        <input id="editReservationId" type="hidden" name="ReservationId" />
        <p><label>Name:</label><input id="editClientName" name="ClientName" /></p>
        <p><label>Location:</label><input id="editLocation" name="Location" /></p>
    </form>
    <button id="submitEdit" type="submit">Save</button>
</div>

//Add some CSS updates to make the page a bit more pretty. Go to Content/Site.css and add these piece of CSS
table {
    margin: 10px 0;
}

th {
    text-align: left;
}

.nameCol {
    width: 100px;
}

.locationCol {
    width: 100px;
}

.selectCol {
    width: 30px;
}

.display {
    float: left;
    border: thin solid black;
    margin: 10px;
    padding: 10px;
}

.display label {
	display: inline-block;
	width: 100px;
}

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	