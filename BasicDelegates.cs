using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

/*
    Delegate is based on a MulticaseDelegate base class.
    
    A delegate is a specialized class functioning as a pipeline between event and event handler.
    Event ======================= Delegate (Pipeline) ========================> Event Handler
    
    ** Multicast Delegate:
    1. Can refernce >= 1 function
    2. Tracks delegate references using an invocation list
    3. Delegates in the list are invoked sequentially
*/

namespace Delegates
{
    // One way pipeline without any return type. Indicates that the methods (event handlers are void as well)
    public delegate void WorkPerformedHandler(int hours, WorkType workType);
    // Declare the delegate type:
    public delegate string MyDelegate(int arg1, int arg2);
    
    public enum WorkType{
        MakeCoffee,
        GoToMeetings,
        Golf,
        GenerateReports,
        WriteMemo
    }
    /*
    To define an event:
        <public + keyword: event + delegate + event name;>
        public event WorkPerformedHandler WorkPerformed;
    */
    // Besides using static class functions, you can also use 
    // instance methods of classes as delegates to implement delegates.
    class MyClass
    {
        public string instanceMethod1(int arg1, int arg2)
        {
            return ((arg1 + arg2) * arg1).ToString();
        }
    }
    class Program
    {
        // Insert delegates: 
        static string func1(int a, int b)
        {
            return (a + b).ToString();
        }

        static string func2(int a, int b)
        {
            return (a * b).ToString();
        }
        // Handlers:
        static void WorkPerformed1 (int hours, WorkType wType){
            Console.WriteLine("WorkPerformed1 called.");
        }
        static void WorkPerformed2 (int hours, WorkType wType){
            Console.WriteLine("WorkPerformed2 called.");
        }
        static void Main(string[] args)
        {
            // Delegate Instances:
            WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            
            // Adding to Invocation List:
            del1 += del2;
            del1(5, WorkType.GoToMeetings);
            
            MyDelegate f = func1;
            Console.WriteLine("The number is: " + f(10, 20));   // output is 30.

            // Reassign the function f:
            f = func2;
            Console.WriteLine("The number is: " + f(10, 20));   // output is 200.

            // To use the instanceMethod of class to implement delegates:

            // First create an instance of the class MyClass, then assign 
            // the delegate variable to the instance method.
            MyClass mc = new MyClass();
            f = mc.instanceMethod1;
            Console.WriteLine("The number is: " + f(10, 20));   // output is 300.

            //Anonymous Delegates:
            MyDelegate AnonyF = delegate (int arg1, int arg2)
            {
                return (arg2 / arg1).ToString();
            };
            Console.WriteLine("The number is: " + AnonyF(10, 20));   // output: 2.

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
