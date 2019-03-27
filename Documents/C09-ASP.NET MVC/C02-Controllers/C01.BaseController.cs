/****************************************************************************
Every request that comes to your application is handled by a controller.
Controllers are responsible for processing incoming requests, performing operations on the domain model, and selecting views to render to the user.
*****************************************************************************/

//The simplest MVC controller would be a class that implements interface IController

using System.Web.Mvc;
using System.Web.Routing;
namespace USM.Controllers
{
    public class BasicController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];
			
            requestContext.HttpContext.Response.Write(string.Format("Controller: {0}, Action: {1}", controller, action));
        }
    }
}

