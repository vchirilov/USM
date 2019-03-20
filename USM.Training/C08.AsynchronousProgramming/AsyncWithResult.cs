using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C08.AsynchronousProgramming
{
    class AsyncWithResult
    {
        static int Factorial(int n)
        {
            int result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            Thread.Sleep(5000);

            return result;
        }

        static async void FactorialAsync(int n)
        {
            Console.WriteLine($"Entered into {nameof(FactorialAsync)}");

            int x = await Task.Run(() => Factorial(n)); //We'll discuss return in more detail later

            Console.WriteLine($"Factorial for {n} is equal {x}");
        }

        public static void Start()
        {
            FactorialAsync(5);
            Thread.Sleep(3000);
            FactorialAsync(6);
        }
    }
}
