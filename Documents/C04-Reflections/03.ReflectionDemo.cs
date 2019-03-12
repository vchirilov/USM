using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C04.Reflections_nm03
{
    class TestClass
    {
        int x;
        int y;
        public TestClass(int i, int j)
        {
            x = i;
            y = j;
        }
        public int Sum()
        {
            return x + y;
        }
        public bool IsBetween(int i)
        {
            if (x < i && i < y) return true;
            else return false;
        }
        public void Set(int a, int b)
        {
            x = a;
            y = b;
        }
        public void Set(double a, double b)
        {
            x = (int)a;
            y = (int)b;
        }
        public void Show()
        {
            Console.WriteLine(" x: {0}, y: {1}", x, y);
        }
    }

    class ReflectionDemo
    {
        public static void Start()
        {
            Type t = typeof(TestClass); // get a Type object representing TestClass

            Console.WriteLine("Analyzing methods in " + t.Name);
            Console.WriteLine();
            Console.WriteLine("Methods supported: ");

            MethodInfo[] methods = t.GetMethods();

            // Display methods supported by TestClass.
            foreach (MethodInfo method in methods)
            {
                // Display return type and name.
                Console.Write(" " + method.ReturnType.Name + " " + method.Name + "(");

                // Display parameters.
                ParameterInfo[] pi = method.GetParameters();

                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);

                    if (i + 1 < pi.Length)
                        Console.Write(", ");
                }
                Console.WriteLine(")");
                Console.WriteLine();
            }
        }
    }
}
