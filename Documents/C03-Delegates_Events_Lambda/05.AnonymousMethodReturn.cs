//*********************************************************************
//It is possible to return values from anonymous method
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03.Delegates_Events.nm05
{
    using System;
    // This delegate returns a value.
    delegate int CountIt3(int end);
    class AnonymousMethodReturn
    {
        public static void Start()
        {
            int result;

            CountIt3 count = delegate (int end) {
                int sum = 0;
                for (int i = 0; i <= end; i++)
                {
                    Console.WriteLine(i);
                    sum += i;
                }
                return sum; // return a value from an anonymous method
            };
            result = count(3);
            Console.WriteLine("Summation of 3 is " + result);

            Console.WriteLine();
            result = count(5);

            Console.WriteLine("Summation of 5 is " + result);
        }
    }
}
