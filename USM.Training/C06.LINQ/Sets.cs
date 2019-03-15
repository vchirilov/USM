using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C06.LINQ
{
    class Sets
    {
        public static void RunExcept()
        {
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };
                        
            var result = soft.Except(hard);

            foreach (string s in result)
                Console.WriteLine(s);
        }

        public static void RunIntersect()
        {
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            var result = soft.Intersect(hard);

            foreach (string s in result)
                Console.WriteLine(s);
        }

        public static void RunUnion()
        {
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            var result = soft.Union(hard);

            foreach (string s in result)
                Console.WriteLine(s);
        }

        public static void RunDistinct()
        {
            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            var cont = soft.Concat(hard);

            foreach (string s in cont)
                Console.WriteLine(s);

            var dist = cont.Distinct();

            Console.WriteLine("Distnct function returns only distinct values");


            foreach (string s in dist)
                Console.WriteLine(s);
        }
    }
}
