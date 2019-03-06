using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03.Delegates_Events.nm08
{
    // Declare a delegate type for an event.
    delegate void MyEventHandler();
    // Declare a class that contains an event.
    class MyEvent
    {
        public event MyEventHandler SomeEvent;
        // This is called to raise the event.
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }
    class X
    {
        public void Xhandler()
        {
            Console.WriteLine("Event received by X object");
        }
    }
    class Y
    {
        public void Yhandler()
        {
            Console.WriteLine("Event received by Y object");
        }
    }
    class EventDemo
    {
        static void Handler()
        {
            Console.WriteLine("Event received by EventDemo");
        }
        public static void Start()
        {
            MyEvent evt = new MyEvent();
            X xOb = new X();
            Y yOb = new Y();

            // Add handlers to the event list.
            evt.SomeEvent += Handler;
            evt.SomeEvent += xOb.Xhandler;
            evt.SomeEvent += yOb.Yhandler;

            // Raise the event.
            evt.OnSomeEvent();
            Console.WriteLine();

            // Remove a handler.
            evt.SomeEvent -= xOb.Xhandler;
            evt.OnSomeEvent();
        }
    }
}
