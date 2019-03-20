using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C08.AsynchronousProgramming
{
    class WaitingTask
    {
        // A method to be run as a task.
        static void MyTask()
        {
            Console.WriteLine("MyTask() #" + Task.CurrentId + " starting");
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In MyTask() #" + Task.CurrentId +
                ", count is " + count);
            }
            Console.WriteLine("MyTask #" + Task.CurrentId + " terminating");
        }

        public static void Start()
        {
            Console.WriteLine("Main thread starting.");

            // Construct two tasks.
            Task tsk = new Task(MyTask);
            Task tsk2 = new Task(MyTask);

            // Run the tasks.
            tsk.Start();
            tsk2.Start();

            Console.WriteLine("Task ID for tsk is " + tsk.Id);
            Console.WriteLine("Task ID for tsk2 is " + tsk2.Id);

            // Suspend Main() until both tsk and tsk2 finish.
            tsk.Wait();
            tsk2.Wait();

            //Task.WaitAll(tsk, tsk2);

            Console.WriteLine("Main thread ending.");
        }
    }
}
