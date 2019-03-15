//*******************************************************************************************
//Use keyword join to join several data-sets
//*******************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{
    class Phone
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Joins
    {
        public static void RunSimpleJoin()
        {
            List<Client> users = new List<Client>()
            {
                new Client { Id = 100, Name = "Sam", Age = 43 },
                new Client { Id = 101, Name = "Tom", Age = 33 }
            };

            List<Phone> phones = new List<Phone>()
            {
                new Phone {ClientId = 100, Name="Lumia 630", Company="Microsoft" },
                new Phone {ClientId = 200, Name="iPhone 6", Company="Apple"},
            };

            var people = from user in users
                         join phone in phones on user.Id equals phone.ClientId
                         select new { Name = user.Name, Phone = phone.Name };

            foreach (var p in people)
                Console.WriteLine("{0} - {1}", p.Name, p.Phone);
        }
    }
}
