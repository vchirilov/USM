using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


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
    }
}
