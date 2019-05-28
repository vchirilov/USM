//Routing by Action Name
//With the default routing template, Web API uses the HTTP verb to select the action. However, you can also create a route where the action name is included in the URI:

routes.MapHttpRoute(
    name: "ActionApi",
    routeTemplate: "api/{controller}/{action}/{id}",
    defaults: new { id = RouteParameter.Optional }
);

//This style of routing is similar to ASP.NET MVC, and may be appropriate for an RPC-style API.

//Web API 2 Routing

//Web API 2 supports a new type of routing, called attribute routing. Attribute routing gives you more control over the URIs in your web API.
//The earlier style of routing is called convention-based routing, is still fully supported. You can combine both techniques in the same project.
//Convention-based routing makes it hard to support certain URI patterns that are common in RESTful APIs.


//Enabling Attribute Routing
using System.Web.Http;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Other Web API configuration not shown.
        }
    }
}

//Attribute routing can be combined with convention-based routing, like below

public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Attribute routing.
        config.MapHttpAttributeRoutes();

        // Convention-based routing.
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}

//AND

protected void Application_Start()
{
    // Pass a delegate to the Configure method.
    GlobalConfiguration.Configure(WebApiConfig.Register);
}

//As you see these setting already setup in our project...

//Let's create a new API controller that is using routing attributes

namespace WebServices.Controllers
{
    public class NewReservationController : ApiController
    {
    }
}

//Add new action method GetAllReservations() like below

[Route("reservations/all")]
public IEnumerable<Reservation> GetAllReservations()
{
	return repo.GetAll();
}

//Add new action method GetReservation() like below

[Route("reservations/{reservationId}")]
public Reservation GetReservation(int reservationId)
{
	return repo.Get(reservationId);
}

//It is possible to define URI constraints 
[Route("get/{id:int}")]
public Reservation GetById(int Id)
{
	return repo.Get(Id);
}

//Route Prefixes. 

//In case you don't want to repease word "reservations" for each action, it is possible to decorate controller with RoutePrefix() attribute
[RoutePrefix("reservations")]
public class NewReservationController : ApiController
{
	IReservationRepository repo = ReservationRepository.getRepository();

	[Route("")]
	public IEnumerable<Reservation> GetAllReservations()
	{
		return repo.GetAll();
	}

	[Route("{reservationId}")]
	public Reservation GetReservation(int reservationId)
	{
		return repo.Get(reservationId);
	}

	[Route("get/{id:int}")]
	public Reservation GetById(int Id)
	{
		return repo.Get(Id);
	}

}


