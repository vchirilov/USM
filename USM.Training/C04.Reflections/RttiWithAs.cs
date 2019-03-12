using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C04.Reflections_nm02
{
    class A { }

    class B : A { }

    class RttiWithAs
    {
        public static void Start()
        {
            A a = new A();
            B b = new B();

            b = a as B; 

            if (b == null)
                Console.WriteLine("The cast in b = (B) a is NOT allowed.");
            else
                Console.WriteLine("The cast in b = (B) a is allowed");

            A a1 = new A();
            B b1 = new B();

            var c = b1 as A; //use pattern matching

            if (c == null)
                Console.WriteLine("Object b cannot be casted to A");
            else
                Console.WriteLine("Object b casted to A succesfully");
        }
    }
}
