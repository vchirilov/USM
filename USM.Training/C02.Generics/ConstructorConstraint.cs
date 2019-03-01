using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C02.Generics
{
    class MyClass
    {
        public MyClass()
        {
            // ...
        }
    }

    class Sister<T> where T : new()
    {
        T obj;
        public Sister()
        {
            // This works because of the new() constraint.
            obj = new T(); // create a T object
        }
    }
    class ConstructorConstraint
    {
        public static void Start()
        {
            Sister<MyClass> x = new Sister<MyClass>();
        }
    }
}