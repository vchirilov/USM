using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C08.AsynchronousProgramming
{
    class DemoLambdaTask
    {
        public static void Start()
        {
            Console.WriteLine("Main thread starting.");

            //The following uses a lambda expression to define a task. 
            //Task.Factory.StartNew is used to create and start the task in one go.

            Task tsk = Task.Factory.StartNew(() => {
                Console.WriteLine("Task starting");
                for (int count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Task count is " + count);
                }
                Console.WriteLine("Task terminating");
            });


            // Wait until tsk finishes.
            tsk.Wait();

            // Dispose of tsk.
            tsk.Dispose();

            Console.WriteLine("Main thread ending.");
        }
    }



    class TaskThatHasResult
    {
        // A trivial method that returns a result and takes no arguments.
        static bool MyTask()
        {
            return true;
        }
        // This method returns the summation of a positive integer
        // which is passed to it.
        static int SumIt(object v)
        {
            int x = (int)v;
            int sum = 0;
            for (; x > 0; x--)
                sum += x;
            return sum;
        }
        public static void Start()
        {
            Console.WriteLine("Main thread starting.");

            // Construct the first task.
            Task<bool> tsk = Task<bool>.Factory.StartNew(MyTask);
            Console.WriteLine("After running MyTask. The result is " +  tsk.Result);

            // Construct the second task.
            Task<int> tsk2 = Task<int>.Factory.StartNew(SumIt, 3);
            Console.WriteLine("After running SumIt. The result is " + tsk2.Result);

            tsk.Dispose();
            tsk2.Dispose();

            Console.WriteLine("Main thread ending.");
        }
    }
}
