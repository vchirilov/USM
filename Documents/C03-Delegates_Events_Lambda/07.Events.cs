//*********************************************************************
//Events are built upon the foundation of delegates
//Events are members of a class and are declared using the event keyword.
//declaration of an event is like "event delegate-type event-name";
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03.Delegates_Events.nm08
{
    // Declare a delegate type for an event.
    delegate void DelegateForEvent();
    // Declare a class that contains an event.
    class ClassWithAnEvent
    {
        public event DelegateForEvent SomeEvent;

        // This is called to raise the event.
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }
    class EventDemo
    {
        // An event handler.
        static void Handler()
        {
            Console.WriteLine("Event occurred");
        }

        public static void Start()
        {
            ClassWithAnEvent evt = new ClassWithAnEvent();
            // Add Handler() to the event list.
            evt.SomeEvent += Handler;
            // Raise the event.
            evt.OnSomeEvent();
        }
    }
}
