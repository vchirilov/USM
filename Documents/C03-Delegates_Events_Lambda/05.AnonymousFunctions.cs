//*********************************************************************
//Very often method that is used by delegate is only used inside this delegate
//In such a case, you can avoid the need to create a separate method by using an anonymous function
//An anonymous function is, essentially, an unnamed block of code that is passed to a delegate constructor
//The advantage to using an anonymous function is simplicity.
//Since C# 3.0 defines two types of anonymous functions: anonymous methods and lambda expressions.
// The anonymous method was added by C# 2.0. The lambda expression was added by C# 3.0.
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03.Delegates_Events.nm04
{
    // Declare a delegate type.
    delegate void CountIt();
	
    class AnonymousMethodDemo
    {
        public static void Start()
        {
            CountIt count = delegate {
                // This is the block of code passed to the delegate.
                for (int i = 0; i <= 5; i++)
                    Console.WriteLine(i);
            }; // notice the semicolon
            count();
        }
    }

}

//*********************************************************************
//It is possible to pass one or more arguments to an anonymous method
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03.Delegates_Events.nm04
{
    delegate void CountIt2(int end);
	
    class AnonymousMethodParams
    {
        public static void Start()
        {
            CountIt2 count = delegate (int end) {
                for (int i = 0; i <= end; i++)
                    Console.WriteLine(i);
            };
            count(3);
            Console.WriteLine();
            count(5);
        }
    }
}


