using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C04.Reflections_nm04
{
    class SomeClass
    {
        int x;
        int y;
        public SomeClass(int i)
        {
            Console.WriteLine("Constructing MyClass(int, int). ");
            x = y = i;
        }
        public SomeClass(int i, int j)
        {
            Console.WriteLine("Constructing MyClass(int, int). ");
            x = i;
            y = j;
            Show();
        }
        public int Sum()
        {
            return x + y;
        }
        public bool IsBetween(int i)
        {
            if ((x < i) && (i < y)) return true;
            else return false;
        }
        public void Set(int a, int b)
        {
            Console.Write("Inside Set(int, int). ");
            x = a;
            y = b;
            Show();
        }
        // Overload Set.
        public void Set(double a, double b)
        {
            Console.Write("Inside Set(double, double). ");
            x = (int)a;
            y = (int)b;
            Show();
        }
        public void Show()
        {
            Console.WriteLine("Values are x: {0}, y: {1}", x, y);
        }
    }
    class TypeConstructors
    {
        public static void Start()
        {
            Type t = typeof(SomeClass);
            int val;

            // Get constructor info.
            ConstructorInfo[] constructors = t.GetConstructors();

            Console.WriteLine("Available constructors: ");

            foreach (ConstructorInfo constructor in constructors)
            {
                // Display return type and name.
                Console.Write(" " + t.Name + "(");

                // Display parameters.
                ParameterInfo[] constrParameters = constructor.GetParameters();

                for (int i = 0; i < constrParameters.Length; i++)
                {
                    Console.Write(constrParameters[i].ParameterType.Name + " " + constrParameters[i].Name);

                    if (i + 1 < constrParameters.Length)
                        Console.Write(", ");
                }

                Console.WriteLine(")");
            }

            Console.WriteLine();

            // Find matching constructor.
            int x;

            for (x = 0; x < constructors.Length; x++)
            {
                ParameterInfo[] pi = constructors[x].GetParameters();

                if (pi.Length == 2)
                    break;
            }

            if (x == constructors.Length)
            {
                Console.WriteLine("No matching constructor found.");
                return;
            }
            else
                Console.WriteLine("Two-parameter constructor found.\n");

            // Construct the object.
            object[] constructorArguments = new object[2];
            constructorArguments[0] = 10;
            constructorArguments[1] = 20;

            object dynamicObject = constructors[x].Invoke(constructorArguments); //Here the object is created dynamically

            Console.WriteLine("\nInvoking methods on reflectOb.");
            Console.WriteLine();

            MethodInfo[] methods = t.GetMethods();

            // Invoke each method.
            foreach (MethodInfo method in methods)
            {
                // Get the parameters.
                ParameterInfo[] parameters = method.GetParameters();

                if (method.Name.Equals("Set", StringComparison.Ordinal) && parameters[0].ParameterType == typeof(int))
                {
                    // This is Set(int, int).
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 18;

                    method.Invoke(dynamicObject, args);
                }
                else if (method.Name.Equals("Set", StringComparison.Ordinal) && parameters[0].ParameterType == typeof(double))
                {
                    // This is Set(double, double).
                    object[] args = new object[2];
                    args[0] = 1.12;
                    args[1] = 23.4;

                    method.Invoke(dynamicObject, args);
                }
                else if (method.Name.Equals("Sum", StringComparison.Ordinal))
                {
                    val = (int)method.Invoke(dynamicObject, null);
                    Console.WriteLine("sum is " + val);
                }
                else if (method.Name.Equals("IsBetween", StringComparison.Ordinal))
                {
                    object[] args = new object[1];
                    args[0] = 14;
                    if ((bool)method.Invoke(dynamicObject, args))
                        Console.WriteLine("14 is between x and y");
                }
                else if (method.Name.Equals("Show"))
                {
                    method.Invoke(dynamicObject, null);
                }
            }
        }
    }
}
