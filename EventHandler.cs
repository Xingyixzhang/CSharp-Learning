using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Event
{
    public delegate void myEventHandler(string value);

    class EventPublisher    // broadcast the message whenever its private string variable changes.
    {
        private string theVal;

        public event myEventHandler valueChanged;
        public event EventHandler<ObjChangeEventArgs> objChanged;   // based on .NET framework.

        public string Val
        {
            set
            {
                this.theVal = value;
                // when the value changes, fire the event
                this.valueChanged(theVal);
                this.objChanged(this, new ObjChangeEventArgs() { propChanged = "val" });
            }
        }
    }
    class ObjChangeEventArgs: EventArgs
    {
        public string propChanged;  // not the value but the name of the changed property itself.
    }
    class Program
    {
        static void Main(string[] args)
        {
            EventPublisher obj = new EventPublisher();
            // obj.valueChanged += obj_valueChanged;
            obj.valueChanged += changeListener1;
            obj.valueChanged += changeListener2;

            // Use an anonymous delegate as the event handler.
            obj.valueChanged += delegate (string val)
            {
                Console.WriteLine("This came from the anonymous handler! I got {0}", val);
            };

            obj.objChanged += delegate (object sender, ObjChangeEventArgs e)
            {
                Console.WriteLine("'{0}' had the '{1}' property changed", sender.GetType(), e.propChanged);
                // sender.GetType(): return type of the object. then write out the string of what property changed.
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

        static void changeListener1(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }
        static void changeListener2(string value)
        {
            Console.WriteLine("I also listen to the event, and got {0}", value);
        }
    }
}