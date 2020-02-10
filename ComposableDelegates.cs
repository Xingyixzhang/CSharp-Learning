using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Delegates
{
    // Declare the delegate type:
    public delegate void MyDelegate(int arg1, int arg2);        // Demo in f1f2
    public delegate string MyDeleString(int arg1, int arg2);    // Demo in f3f4
    public delegate void MyDeleRef(int arg1, ref int arg2);     // Demo in f5f6
   
    class Program
    {
        // Insert delegates: 
        static void func1(int a, int b)
        {
            string result = (a + b).ToString();
            Console.WriteLine("The number is: " + result);
        }

        static void func2(int a, int b)
        {
            string result = (a * b).ToString();
            Console.WriteLine("The number is: " + result);
        }

        static string func3(int a, int b)   // cannot use int since in cannot do WriteLine("...: ", int);
        {
            return (a - b).ToString();
        }

        static string func4(int a, int b)
        {
            return (a % b).ToString();
        }

        static void func5(int a, ref int b)
        {
            string result = (b / a).ToString();
            b += 10;    // b is a ref parameter, so this will change.
            Console.WriteLine("The number is: " + result);
        }

        static void func6(int a, ref int b)
        {
            string result = ((a + b) / b * 10).ToString();
            Console.WriteLine("The number is: " + result);
        }
        static void Main(string[] args)
        {
            MyDelegate f1 = func1;  // no need to specify the parameters at this stage.
            MyDelegate f2 = func2;
            MyDelegate f1f2 = f1 + f2;

            MyDeleString f3 = func3;  
            MyDeleString f4 = func4;
            MyDeleString f3f4 = f3 + f4;

            MyDeleRef f5 = func5;
            MyDeleRef f6 = func6;
            MyDeleRef f5f6 = f5 + f6;

            // call each delegate and then the chain
            Console.WriteLine("Calling the first delegate");
            f1(10, 20);
            Console.WriteLine("Calling the second delegate");
            f2(10, 20);
            Console.WriteLine("Calling the 1+2 chained delegates");
            f1f2(10, 20);

            // Subtract off one of the delegates
            Console.WriteLine("\nCalling the unchained delegates");
            f1f2 -= f1;
            f1f2(20, 20);

            // call each delestring and the chain
            Console.WriteLine("\nCalling the 3rd delegate: " + f3(30, 20));
            Console.WriteLine("Calling the 4th delegate: " + f4(67, 20));
            Console.WriteLine("Calling the 3+4 chained delegates: " + f3f4(73, 20));

            // call each delegate and then the chain
            int a = 10, b = 10;
            Console.WriteLine("printing b:\t{0}", b);
            f5(a, ref b);
            Console.WriteLine("Calling the ref b:\t{0}", b);
            f5(a, ref b);
            Console.WriteLine("Calling the 5+6 including ref b chained delegates\t");
            f5f6(a, ref b);

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
