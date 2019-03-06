//*********************************************************************
//It is possible to pass one or more arguments to an anonymous method
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03.Delegates_Events.nm05
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