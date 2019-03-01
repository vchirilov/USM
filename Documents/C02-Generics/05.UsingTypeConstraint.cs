//*********************************************************************
//The next two constraints enable you to indicate that a type argument must be either a reference type or a value type. 
// These are useful in the few cases in which the difference between reference and value types is important to generic code.
//*********************************************************************

//Reference type constraint uses this form of the where clause: where T : class
//Value type constraint uses this form of the where clause: where T : struct

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
