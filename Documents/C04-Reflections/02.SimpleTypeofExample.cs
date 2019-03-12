//******************************************************************************************
//In order to obtain information about a type use typeof operator.
//typeof(type) return an object of type System.Type 
//The Type object returned encapsulates the information associated with type.
//Type is a large class with many members like FullName, IsClass, and IsAbstract
//******************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C04.Reflections_nm03
{
    class SimpleTypeofExample
    {
        public static void Start()
        {
            Type t = typeof(StreamReader);

            Console.WriteLine(t.FullName);

            if (t.IsClass)
                Console.WriteLine("Is a class.");

            if (t.IsAbstract)
                Console.WriteLine("Is abstract.");

            else Console.WriteLine("Is concrete.");
        }
    }
}
