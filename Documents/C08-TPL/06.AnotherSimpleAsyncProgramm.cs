using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08.AsynchronousProgramming
{
    class AnotherSimpleAsyncProgramm
    {
        static async void ReadWriteAsync()
        {
            string s = "Hello world! One step at a time";

            using (StreamWriter writer = new StreamWriter("hello.txt", false))
            {
                await writer.WriteLineAsync(s);  // asynch writing in file
            }
            using (StreamReader reader = new StreamReader("hello.txt"))
            {
                string result = await reader.ReadToEndAsync();  // asynch reading from file
                Console.WriteLine(result);
            }
        }
        public static void Start()
        {
            ReadWriteAsync();
            Console.WriteLine("Work is done.");
        }
    }
}
