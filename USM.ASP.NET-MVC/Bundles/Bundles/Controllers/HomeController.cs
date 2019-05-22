using Bundles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bundles.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MakeBooking(Appointment appt)
        {
            return Json(appt, JsonRequestBehavior.AllowGet);
        }
    }
}