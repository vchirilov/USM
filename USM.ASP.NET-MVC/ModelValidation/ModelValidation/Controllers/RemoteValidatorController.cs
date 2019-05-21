using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
    public class RemoteValidatorController : Controller
    {
        // GET: RemoteValidator
        public JsonResult ValidateClientName(string ClientName)
        {
            if (ClientName.Length < 3)
                return Json("ClientName is too small", JsonRequestBehavior.AllowGet);

            if (ClientName.Length > 6)
                return Json("ClientName is too large", JsonRequestBehavior.AllowGet);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}