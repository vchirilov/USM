ausing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{
    class Agregations
    {
        public static void RunSum()
        {
            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            int sum1 = numbers.Sum();

            decimal sum2 = users.Sum(n => n.Age);

            Console.WriteLine($"Sum1 = {sum1}");
            Console.WriteLine($"Sum2 = {sum2}");
        }

        public static void RunMinMaxAvg()
        {
            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            int min1 = numbers.Min();
            int min2 = users.Min(n => n.Age); 

            int max1 = numbers.Max();
            int max2 = users.Max(n => n.Age); 

            double avr1 = numbers.Average();
            double avr2 = users.Average(n => n.Age);

            Console.WriteLine($"min1={min1}, min2 = {min2}, max1 = {max1}, max2 = {max2}, avr1 = {avr1}, avr2 = {avr2}");
        }
    }
}
