using NUnit.Framework;
using NUnitDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
