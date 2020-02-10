using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Event
{
    class Program
    {
        public delegate void myEventHandler(string value);

        class EventPublisher    // broadcast the message whenever its private string variable changes.
        {
            private string theVal;

            public event myEventHandler valueChanged;

            public string Val
            {
                set
                {
                    this.theVal = value;
                    // when the value changes, fire the event
                    this.valueChanged(theVal);
                }
            }
        }
        static void Main(string[] args)
        {
            EventPublisher obj = new EventPublisher();
            // obj.valueChanged += obj_valueChanged;
            obj.valueChanged += delegate (string val)
            {
                Console.WriteLine("The value changed to {0}", val);
            };

            string str;
            do
            {
                Console.WriteLine("Enter a value: ");
                str = Console.ReadLine();
                if (!str.Equals("exit"))
                {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));

            Console.WriteLine("\nPress Enter to Continue...");
            Console.ReadKey();
        }

        static void obj_valueChanged(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }
    }
}
