/****************************************************************************
1. Create solution with name SportsStore
2. Add an ASP.NET MVC Web Application project (Basic template) called SportsStore.WebUI
3. Add a new class library project called SportsStore.Domains
4. Add an unit test project called SportsStore.UnitTests
5. Add references between projects
*****************************************************************************/

//Add Dependency Injection using Ninject.
//Select Tools Library Package Manager Manage NuGet Packages for Solution to open the NuGet packages dialog. Serach for Ninject and add it.
//Creating the Dependency Resolver (Branch=Step02-CreateDependencyResolver)

//Create a new folder Infrastructure and add NinjectDependencyResolver.cs
	
public class NinjectDependencyResolver: IDependencyResolver
{
	private IKernel kernel;
	public NinjectDependencyResolver()
	{
		kernel = new StandardKernel();
		AddBindings();
	}
	public object GetService(Type serviceType)
	{
		return kernel.TryGet(serviceType);
	}

	public IEnumerable<object> GetServices(Type serviceType)
	{
		return kernel.GetAll(serviceType);
	}
	private void AddBindings()
	{
		//kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
	}
}

//Register the Dependency Resolver
//We have to tell the MVC Framework that we want to use our own dependency resolver, which we do by modifying the Global.asax.cs file

protected void Application_Start()
{
	AreaRegistration.RegisterAllAreas();
	FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
	RouteConfig.RegisterRoutes(RouteTable.Routes);
	BundleConfig.RegisterBundles(BundleTable.Bundles);
	
	DependencyResolver.SetResolver(new NinjectDependencyResolver()); // this code to be added
}

//Creating Repository (Branch=Step03-CreateRepository)

//In enterprise solutions models is better to move out in a separate project which in our case is SportsStore.Domains

//Create a folder Entities and class Product in SportsStore.Domains

public class Product
{
	public int ProductID { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public string Category { get; set; }
}

//Creating Repository

//Create a folder Abstract and interface IProductRepository in SportsStore.Domains
public interface IProductRepository
{
	IQueryable<Product> Products { get; }
}

//Create class ProductRepository that implements interface IProductRepository
public class ProductRepository : IProductRepository
{
	public IQueryable<Product> Products => new List<Product> {
		new Product { Name = "Football", Price = 25 },
		new Product { Name = "Surf board", Price = 179 },
		new Product { Name = "Running shoes", Price = 95 }
		}.AsQueryable();
}
	
//Adding Product Controller

public class ProductController : Controller
{
	public ActionResult Index()
	{
		return View();
	}
}

//Add dependency by IProductRepository in controller ProductController and remove Index action (a new action will be created later)
//This will allow Ninject to inject the dependency for the product repository when it instantiates the controller class.

public class ProductController : Controller
{
	private IProductRepository repository;
	public ProductController(IProductRepository productRepository)
	{
		this.repository = productRepository;
	}
}

//Add binding for IProductRepository in AddBindings()

private void AddBindings()
{
	kernel.Bind<IProductRepository>().To<ProductRepository>();
}

//Add action method, called List, which will render a view showing the complete list of products

 public ViewResult List()
{
	return View(repository.Products);
}


//Adding List view
@model IEnumerable<SportsStore.Models.Entities.Product>
@{
    ViewBag.Title = "Products";
}
@foreach (var p in Model)
{
    <div class="item">
        <h3>@p.Name</h3>
        @p.Description
        <h4>@p.Price.ToString("c")</h4>
    </div>
}


//Setting the Default Route
public static void RegisterRoutes(RouteCollection routes)
{
	routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

	routes.MapRoute(
		name: "Default",
		url: "{controller}/{action}/{id}",
		defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
	);
}

//Create Database (Branch = Step04-CreateDatabase)
//Using SQL Management Studio create a new database with name SportsStore

//Create table dbo.Products

CREATE TABLE Products
(
	[ProductID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	[Category] NVARCHAR(50) NOT NULL,
	[Price] DECIMAL(16, 2) NOT NULL
)


Insert Into dbo.Products (Name, Description, Category,Price) Values ('Kayak','A boat for one person','Watersports',280.00)
Insert Into dbo.Products (Name, Description, Category,Price) Values ('Lifejacket','Protective and fashionable','Watersports',48.95)
Insert Into dbo.Products (Name, Description, Category,Price) Values ('Soccer Ball','FIFA-approved size and weight','Soccer',19.50)
Insert Into dbo.Products (Name, Description, Category,Price) Values ('Corner Flags','Give your playing field a professional touch','Soccer',34.95)
Insert Into dbo.Products (Name, Description, Category,Price) Values ('Stadium','Flat-packed 35,000 seat-stadium','Soccer',80000.50)
Insert Into dbo.Products (Name, Description, Category,Price) Values ('Thinking Cap','Improve your brain efficiency by 80%','Chees',16.00)
Insert Into dbo.Products (Name, Description, Category,Price) Values ('Unsteady Chair','Secretly give your opponent a disadvantage','Chees',29.95)
Insert Into dbo.Products (Name, Description, Category,Price) Values ('Human Chees Boad','A fan game for the family','Chees',86.23)
Insert Into dbo.Products (Name, Description, Category,Price) Values ('Bling-Bling King','Gold-plated, dimaond-studdied King','Chees',1200.82)


//Add EntityFramework package
//Crea database context class in SportsStore.Models

namespace SportsStore.Models
{
    public class SportsStoreContext
    {
        public DbSet<Product> Products { get; set; }
    }
}

//Add connection string in Web.config file
<connectionStrings>
<add name="SportsStoreContext" connectionString="Data Source=(localdb)\v11.0;Initial Catalog=SportsStore;Integrated Security=True" providerName="System.Data.SqlClient"/>
</connectionStrings> 

