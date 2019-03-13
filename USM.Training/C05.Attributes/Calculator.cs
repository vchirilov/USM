using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C05.Attributes
{
    [Remark("Applied to a class")]
    class Calculator
    {
        int x;
        int y;
        public Calculator(int i)
        {
            Console.WriteLine("Constructing MyClass(int, int). ");
            x = y = i;
        }
        [Remark("Applied to a constructor")]
        public Calculator(int i, int j)
        {
            Console.WriteLine("Constructing MyClass(int, int). ");
            x = i;
            y = j;
            Show();
        }

        [Remark("Applied to a method")]
        public int Sum()
        {
            return x + y;
        }
        [Metadata("positional parameter", Supplement = "named parameter")]
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
}
