using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C02.Generics
{
    public class Gen<T>
    {
        T ob; // declare a variable of type T

        // Notice that this constructor has a parameter of type T.
        public Gen(T o)
        {
            ob = o;
        }
        // Return ob, which is of type T.
        public T GetOb()
        {
            return ob;
        }
        // Show type of T.
        public void ShowType()
        {
            Console.WriteLine("Type of T is " + typeof(T));
        }
    }

    public class SimpleGenericsClass
    {
        public static void Start()
        {
            // Create a Gen reference for int.
            Gen<int> obj;

            // Create a Gen<int> object and assign its reference to iOb.
            obj = new Gen<int>(102);

            // Show the type of data used by iOb.
            obj.ShowType();

            // Get the value in iOb.
            int value = obj.GetOb();
            Console.WriteLine("value: " + value);
            Console.WriteLine();

            // Create a Gen object for strings.
            Gen<string> strOb = new Gen<string>("Generics is something cool.");

            // Show the type of data stored in strOb.
            strOb.ShowType();

            // Get the value in strOb.
            string str = strOb.GetOb();
            Console.WriteLine("value: " + str);
        }
    }
}
