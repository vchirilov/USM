using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{
    class Sorting
    {
        public static void Start()
        {
            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 33 },
                new User { Name = "Bob", Age = 30 },
                new User { Name = "Tom", Age = 21 },
                new User { Name = "Sam", Age = 43 }
            };

            var sortedUsers = from u in users
                              orderby u.Name
                              orderby u.Age
                              select u;

            foreach (User u in sortedUsers)
                Console.WriteLine(u.Name);

            Console.WriteLine("Using extended methods");

            var result = users.OrderBy(u => u.Name).ThenBy(u => u.Age).ThenBy(u => u.Name.Length);

            foreach (User u in sortedUsers)
                Console.WriteLine(u.Name);

        }
    }
}
