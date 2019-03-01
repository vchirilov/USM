using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C02.Generics.TypeConstratint
{
    class MyClass
    {
        //...
    }

    // Use a reference constraint.
    class Test<T> where T : class
    {
        T obj;
        public Test()
        {
            // The following statement is legal only
            // because T is guaranteed to be a reference
            // type, which can be assigned the value null.
            obj = null;
        }
        // ...
    }

    class TypeConstraint
    {
        public static void Start()
        {
            // The following is OK because MyClass is a class.
            Test<MyClass> x = new Test<MyClass>();
            // The next line is in error because int is a value type.
            // Test<int> y = new Test<int>();
        }
    }
}



