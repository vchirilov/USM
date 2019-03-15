using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{
    class ComplexFilters
    {
        public static void RunComplexFilter()
        {
            List<User> users = new List<User>{
                new User {Name="Tom", Age=23, Languages = new List<string> {"english", "german" }},
                new User {Name="Boby", Age=27, Languages = new List<string> {"english", "french" }},
                new User {Name="Jhon", Age=29, Languages = new List<string> {"english", "spanish" }},
                new User {Name="Marta", Age=24, Languages = new List<string> {"spanis", "german" }}
            };


            var selectedUsers = from user in users
                                 from lang in user.Languages
                                 where user.Age < 28
                                 where lang == "english"
                                 select user;

            //The same query using extended methods

            var projection = users
                .SelectMany(u => u.Languages, (u, l) => new { User = u, Lang = l })
                .Where(u => u.Lang == "english" && u.User.Age < 28)
                .Select(u => u.User);

            foreach (User user in selectedUsers)
                Console.WriteLine("{0} - {1}", user.Name, user.Age);

        }
    }
}
