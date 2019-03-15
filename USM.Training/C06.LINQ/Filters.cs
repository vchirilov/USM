using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{

    class Filter
    {
        public static void RunSimpleFilter()
        {
            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            IEnumerable<int> evens = from i in numbers
                                     where i % 2 == 0 && i > 10 // this is actually the filter criteria
                                     select i;

            foreach (int i in evens)
                Console.WriteLine(i);
        }

        public static void RunFilterComplexObject()
        {
            List<User> users = new List<User>{
                new User {Name="Tom", Age=23, Languages = new List<string> {"english", "german" }},
                new User {Name="Boby", Age=27, Languages = new List<string> {"english", "french" }},
                new User {Name="Jhon", Age=29, Languages = new List<string> {"english", "spanish" }},
                new User {Name="Marta", Age=24, Languages = new List<string> {"spanis", "german" }}
            };

            var selectedUsers = from user in users
                                where user.Age > 25
                                select user;

            //Studentii scrie forma cu extended queries

            foreach (User user in selectedUsers)
                Console.WriteLine("{0} - {1}", user.Name, user.Age);
        }
    }
}






