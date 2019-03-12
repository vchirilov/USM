using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C04.Reflections
{
    class A { }
    class B : A { }
    class RttiWithIs
    {
        public static void Start()
        {
            A a = new A();
            B b = new B();

            if (a is A)
                Console.WriteLine("a is an A");

            if (b is A)
                Console.WriteLine("b is an A because it is derived from A");

            if (a is B)
                Console.WriteLine("This won’t display -- a not derived from B");

            if (b is B)
                Console.WriteLine("b is a B");

            if (a is object)
                Console.WriteLine("a is an object");
        }
    }
}
