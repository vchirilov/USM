/*************************************************************************************************************
This is a client-side validation technique that invokes an action method on the server to perform validation.
*************************************************************************************************************/

//Let's create a remote validation example.
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

//Decorate ClientName field from Appointment calss with Remote attrhibute like below

public class Appointment
{
	[Required]
	[Remote("ValidateClientName", "RemoteValidator")] // this piece of code
	public string ClientName { get; set; }
	...	
}