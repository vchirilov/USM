using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08.AsynchronousProgramming
{
    class AsyncWithResultTaskT
    {
        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        static async Task<int> FactorialAsync(int n)
        {
            return await Task.Run(() => Factorial(n));
        }

        public static async Task Start1()
        {
            int n1 = await FactorialAsync(5);
            int n2 = await FactorialAsync(6);

            Console.WriteLine($"n1={n1}  n2={n2}");

            Console.WriteLine($"Work 1 is done for {nameof(AsyncWithResultTaskT)}");
        }

        public static async void Start2()
        {
            int n1 = await FactorialAsync(5);
            int n2 = await FactorialAsync(6);

            Console.WriteLine($"n1={n1}  n2={n2}");

            Console.WriteLine($"Work 2 is done for {nameof(AsyncWithResultTaskT)}");
        }

        public static void Start3()
        {
            int n1 = FactorialAsync(5).Result;
            int n2 = FactorialAsync(6).Result;

            Console.WriteLine($"n1={n1}  n2={n2}");

            Console.WriteLine($"Work 3 is done for {nameof(AsyncWithResultTaskT)}");
        }
    }
}
