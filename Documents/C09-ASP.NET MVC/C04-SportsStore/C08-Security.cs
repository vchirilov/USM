//In this lesson we'll speak about some security spects used in ASp.NET MVC.

//Authentication is configured in Web.config file. Add this pice of information under section <system.web>

<authentication mode="Forms">
<forms loginUrl="~/Account/Login" timeout="2880">
<credentials passwordFormat="Clear">
<user name="admin" password="secret" />
</credentials>
</forms>
</authentication>

//Add [Authorize] attribute to Admin controller and run the application. 

//Creating the Authentication Provider

//Create a new folder called Security in the Infrastructure folder of the SportsStore.WebUI project and add a new interface called IAuthProvider.

namespace SportsStore.WebUI.Infrastructure.Security
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}

//Create a class called FormsAuthProvider that implements IAuthProvider interface

public class FormsAuthProvider : IAuthProvider
{
	public bool Authenticate(string username, string password)
	{
		bool result = FormsAuthentication.Authenticate(username, password);

		if (result)
		{
			FormsAuthentication.SetAuthCookie(username, false);
		}
		return result;
	}
}

//The final step is to register the FormsAuthProvider in the AddBindings method of the NinjectDependencyResolver

private void AddBindings()
{
	kernel.Bind<IProductRepository>().To<EFProductRepository>();
	kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
}

//Creating the Account Controller

//To get started, we will create a view model class that we will pass between the controller and the view.
namespace SportsStore.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

//Next, create a new controller called AccountController and actions HttpGet, HttpPost
namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}

//Creating the View
@model SportsStore.WebUI.Models.LoginViewModel
@{
    ViewBag.Title = "Admin: Log In";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";
}
<h1>Log In</h1>
<p>Please log in to access the administrative area:</p>
@using (Html.BeginForm())
{
    @Html.ValidationSummary(true)
    @Html.EditorForModel()
    <p><input type="submit" value="Log in" /></p>
}
