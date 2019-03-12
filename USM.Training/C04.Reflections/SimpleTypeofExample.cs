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
