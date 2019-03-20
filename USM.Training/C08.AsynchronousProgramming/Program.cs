using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C08.AsynchronousProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleAsyncProgramm.Start();
            //AnotherSimpleAsyncProgramm.Start();
            //AsyncWithResult.Start();

            //AsyncWithResultVoid.Start();
            //AsyncWithResultTask.Start();

            //Call_AsyncWithResultTaskT_Start1();
            //AsyncWithResultTaskT.Start2();
            AsyncWithResultTaskT.Start3();

            Console.ReadKey();
        }

        static async void Call_AsyncWithResultTaskT_Start1()
        {
            await AsyncWithResultTaskT.Start1();
        }
    }
}
