using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C08.AsynchronousProgramming
{

    class SimpleAsyncProgramm
    {
        private static void Factorial()
        {
            int result = 1;

            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }

            Thread.Sleep(8000);

            Console.WriteLine($"Factorial equal to {result}");
        }

        // Async method
        private static async void FactorialAsync()
        {
            Console.WriteLine("Start method FactorialAsync"); 
            await Task.Run(() => Factorial());                 
            Console.WriteLine("End of method FactorialAsync");  
        }

        public static void Start()
        {
            FactorialAsync();   // async call

            Console.WriteLine("Type a number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Result is {n * n}");
        }
    }
}
