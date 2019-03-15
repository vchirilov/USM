using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{
    class Projections
    {
        public static void RunProjectionExample()
        {
            List<User> users = new List<User>();
            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });

            var items = from u in users
                        //projection
                        select new
                        {
                            FirstName = u.Name,
                            DateOfBirth = DateTime.Now.Year - u.Age
                        };

            foreach (var n in items)
                Console.WriteLine("{0} - {1}", n.FirstName, n.DateOfBirth);

            Console.WriteLine("Projections using extended methods");

            items = users.Select(u => new
            {
                FirstName = u.Name,
                DateOfBirth = DateTime.Now.Year - u.Age
            });

            foreach (var n in items)
                Console.WriteLine("{0} - {1}", n.FirstName, n.DateOfBirth);

        }

        public static void RunLetExample()
        {
            List<User> users = new List<User>();
            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });


            var items = from u in users
                         let name = "Mr. " + u.Name
                         let isOld = u.Age > 50 ? true: false
                         select new
                         {
                             Name = name,
                             Age = u.Age,
                             IsOld = isOld
                         };

            foreach (var n in items)
                Console.WriteLine("{0} - {1}. Is old man {2}", n.Name, n.Age, n.IsOld);



        }
    }
}
