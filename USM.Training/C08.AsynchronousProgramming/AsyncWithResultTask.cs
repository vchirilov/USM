using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08.AsynchronousProgramming
{
    class AsyncWithResultTask
    {
        static void Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Factorial equal {result}");
        }

        static async Task FactorialAsync(int n)
        {
            await Task.Run(() => Factorial(n));
        }
        public static async void Start()
        {
            await FactorialAsync(5);
            await FactorialAsync(6);

            Console.WriteLine($"Work is done for {nameof(AsyncWithResultTask)}");
        }
    }
}
