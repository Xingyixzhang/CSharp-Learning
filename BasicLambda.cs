using System;

namespace BasicLambda
{
    public delegate int MyDelegate(int x);
    public delegate void MyDelegate2(int x, string prefix);
    public delegate bool ExprDelegate(int x);
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate foo = (x) => x * x;
            Console.WriteLine("The result of foo is: {0}", foo(5));

            // Dynamically change the delegate to something else
            foo = (x) => x * 10;
            Console.WriteLine("The result of bar is: {0}", foo(5));

            // Create a delegate that takes multiple arguments
            MyDelegate2 bar = (x, y) =>
            {
                Console.WriteLine("The two-arg lambda: {1}, {0}", x * 10, y);
            };
            bar(25, "Some String");

            // Define an expression delegate
            ExprDelegate baz = (x) => x > 10;
            Console.WriteLine("Calling baz with 5: {0}", baz(5));
            Console.WriteLine("Calling baz with 15: {0}", baz(15));

            Console.WriteLine("\nPress Enter to continue...");
            Console.WriteLine();
        }
    }
}

// Demo: Use lambda functions to implement EventHandlers
//       Just like how you would anonymous delegates or named functions.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LambdaDelegates
{
    public delegate void myEventHandler(string value);

    class MyClass
    {
        private string theVal;
        public event myEventHandler valueChanged;

        public string Val
        {
            set
            {
                this.theVal = value;
                // When the value changes, fire the event:
                this.valueChanged(theVal);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();

            obj.valueChanged += (x) =>
            {
                Console.WriteLine("The value has changed to: {0}", x);
            };

            string str;
            do
            {
                str = Console.ReadLine();
                if (!str.Equals("exit")) { obj.Val = str; }
            } while (!str.Equals("exit"));

            Console.WriteLine("\nPress Enter to continue...");
        }
    }
}
