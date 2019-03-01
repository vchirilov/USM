//*********************************************************************
//The new( ) constructor constraint enables you to instantiate an object of a generic type.
//Normally, you cannot create an instance of a generic type parameter.
//The new( ) constraint changes this because it requires that a type argument supply a public parameterless constructor.
//With the new( ) constraint in place, you can invoke the parameterless constructor to create an object.
//*********************************************************************

//Constructor constraint uses this form of the where clause: where T : new()

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