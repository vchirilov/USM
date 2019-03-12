//******************************************************************************************
//Using reflection you can call methods dinamically using Invoke() method
//******************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C04.Reflections_nm04
{
    class AnotherClass
    {
        int x;
        int y;
        public AnotherClass(int i, int j)
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
        // Overload set.
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

    class CallingMethodsUsingReflection
    {
       public  static void Start()
        {
            Type t = typeof(AnotherClass);

            AnotherClass reflectOb = new AnotherClass(10, 20);

            int val;
            Console.WriteLine("Invoking methods in " + t.Name);
            Console.WriteLine();

            MethodInfo[] methods = t.GetMethods();

            // Invoke each method.
            foreach (MethodInfo method in methods)
            {
                // Get the parameters.
                ParameterInfo[] parameters = method.GetParameters();

                if (method.Name.Equals("Set", StringComparison.Ordinal) && parameters[0].ParameterType == typeof(int))
                {
                    object[] args = new object[2];
                    args[0] = 9;
                    args[1] = 18;

                    method.Invoke(reflectOb, args);
                }
                else if (method.Name.Equals("Set", StringComparison.Ordinal) && parameters[0].ParameterType == typeof(double))
                {
                    object[] args = new object[2];
                    args[0] = 1.12;
                    args[1] = 23.4;

                    method.Invoke(reflectOb, args);
                }
                else if (method.Name.Equals("Sum", StringComparison.Ordinal))
                {
                    val = (int)method.Invoke(reflectOb, null);
                    Console.WriteLine("sum is " + val);
                }
                else if (method.Name.Equals("IsBetween", StringComparison.Ordinal))
                {
                    object[] args = new object[1];
                    args[0] = 14;

                    if ((bool)method.Invoke(reflectOb, args))
                        Console.WriteLine("14 is between x and y");
                }
                else if (method.Name.Equals("Show", StringComparison.Ordinal))
                {
                    method.Invoke(reflectOb, null);
                }
            }
        }
    }
}
