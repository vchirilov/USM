using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            //[Using Static URL Segments]

            //routes.MapRoute(
            //    name: "Default1",
            //    url: "Public/{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index" }
            //    );

            //routes.MapRoute(
            //    name: "Default2",
            //    url: "X{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);

        }
    }
}
