using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01.Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = x / 0;
            Console.WriteLine($"Result {y}");
            Console.WriteLine("End of the program");
            Console.Read();
        }
    }
}
