using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03.Delegates_Events.nm06
{
    delegate int IntOp(int end);
    class StatementLambdaDemo
    {
        public static void Start()
        {
            // A statement lambda that returns the factorial
            // of the value it is passed.
            IntOp fact = n => {
                int r = 1;
                for (int i = 1; i <= n; i++)
                    r = i * r;
                return r;
            };
            Console.WriteLine("The factorial of 3 is " + fact(3));
            Console.WriteLine("The factorial of 5 is " + fact(5));
        }
    }
}
