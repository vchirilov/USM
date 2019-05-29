//Software testing is a process of executing a program or application with the intent of finding the software bugs.
//Every successful software development is following a lifecycle known as SDLC(Software Development Life Cycle)
//A lot of unit test framework are available for .Net now a day,if we check in Visual studio we have MSTest from Microsoft integrated in Visual Studio.
//Some 3rd party framework are like - NUnit, MbUnit. Out of all these Nunit is the most  used testing Framework.

//Let's go with a simple program that demonstrates unit testing. Create a console application and call it NUnitDemo

//Create a new class EmployeeDetails
public class EmployeeDetails  
    {  
        public int id { get; set; }  
        public string Name { get; set; }  
        public double salary { get; set; }  
        public string Geneder { get; set; }  
    }  
} 


//Add these 3 methods 

public string Login(string UserId, string Password)
{
	if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Password))
	{
		return "Userid or password could not be Empty.";
	}
	else
	{
		if (UserId == "Admin" && Password == "Admin")
		{
			return "Welcome Admin.";
		}
		return "Incorrect UserId or Password.";

	}

}

public List<EmployeeDetails> AllUsers()
{
	List<EmployeeDetails> li = new List<EmployeeDetails>();
	li.Add(new EmployeeDetails { id = 100, Name = "Bharat", Geneder = "male", salary = 40000 });
	li.Add(new EmployeeDetails { id = 101, Name = "sunita", Geneder = "Female", salary = 50000 });
	li.Add(new EmployeeDetails { id = 103, Name = "Karan", Geneder = "male", salary = 40000 });
	li.Add(new EmployeeDetails { id = 104, Name = "Jeetu", Geneder = "male", salary = 23000 });
	li.Add(new EmployeeDetails { id = 105, Name = "Manasi", Geneder = "Female", salary = 80000 });
	li.Add(new EmployeeDetails { id = 106, Name = "Ranjit", Geneder = "male", salary = 670000 });
	return li;

}

public List<EmployeeDetails> getDetails(int id)
{
	List<EmployeeDetails> li1 = new List<EmployeeDetails>();

	var li = AllUsers();

	foreach (var x in li)
	{
		if (x.id == id)
		{
			li1.Add(x);
		}
	}
	return li1;

}

//Add a class library named Test and delete Class1 class.

//Add NUnit framework using NuGet Manager (Search for words NUnit)

//NUnit Test Adapter for Visual Studio: NUnit Test Adapter allows you to run NUnit tests inside Visual Studio (Search for words NUnit3TestAdapter)

//Add reference to NUnitDemo project in Test project.

//Add a new class SimpleTest in Test project called
namespace Test
{
    [TestFixture]
    public class SimpleTest
    {
        List<EmployeeDetails> li;

        [Test]
        public void CheckDetails()
        {
            Program pobj = new Program();
            li = pobj.AllUsers();
            foreach (var x in li)
            {
                Assert.IsNotNull(x.id);
                Assert.IsNotNull(x.Name);
                Assert.IsNotNull(x.salary);
                Assert.IsNotNull(x.Geneder);

            }
        }

        [Test]
        public void TestLogin()
        {
            Program pobj = new Program();

            string x = pobj.Login("Ajit", "1234");
            string y = pobj.Login("", "");
            string z = pobj.Login("Admin", "Admin");

            Assert.AreEqual("Userid or password could not be Empty.", y);
            Assert.AreEqual("Incorrect UserId or Password.", x);
            Assert.AreEqual("Welcome Admin.", z);

        }

        [Test]
        public void GetUserDetails()
        {
            Program pobj = new Program();
            var p = pobj.getDetails(100);

            foreach (var x in p)
            {
                Assert.AreEqual(x.id, 100);
                Assert.AreEqual(x.Name, "Bharat");

            }


        }
    }
}


//TestFixture:-The class that is to be test using Nunit should be decorated with TextFixture.

//Test:-This attribute identify the method to be tested.If we will not write this attribute then we cant be able to identify the test in Testexplorer.