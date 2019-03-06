using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C02.Generics
{
    class BaseCar
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }

    // Class Toyota inherits BaseCar.
    class Toyota : BaseCar { }
    
    // Class C does not inherit BaseCar.
    class Motobyke { }
    
    // Because of the base class constraint, all type arguments
    // passed to Test must have BaseCar as a base class.
    class Test<T> where T : BaseCar
    {
        T obj;
        public Test(T o)
        {
            obj = o;
        }
        public void SayHello()
        {
            // OK to call Hello() because it’s declared
            // by the base class BaseCar.
            obj.Hello();
        }
    }

    class BaseClassConstraint
    {
        public static void Start()
        {
            BaseCar a = new BaseCar();
            Toyota b = new Toyota();
            Motobyke c = new Motobyke();

            // The following is valid because BaseCar is the specified base class.
            Test<BaseCar> t1 = new Test<BaseCar>(a);
            t1.SayHello();
            // The following is valid because Toyota inherits BaseCar.
            Test<Toyota> t2 = new Test<Toyota>(b);

            t2.SayHello();
            //The following is invalid because Motobyke does not inherit BaseCar.
            //Test<Motobyke> t3 = new Test<Motobyke>(c); // Error!
            //t3.SayHello(); // Error!
        }

    }
}
