using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * Thread class can be found in the System.Threading namespace. 
 * this class enables users to create new threads, manage the priorities, and get the status.
 *               ---------  Thread  ---------
 *           <Extends>                 <Implements>
 *   Thread (class)                             Runnable (Interface)
 *                         <Override>
 *               ---------Run() Method-------
 * 
 * Synchronization: the mechanism of ensuring that 2 threads don't execute a specific resource
 *                  of your program at the same time.
 */
using System.Threading;
using System.Globalization;

namespace IntroThreading
{
    /*
     * A thread is defined as the execution path of a program. Each thread defines a unique flow of control.
     * Threads are lightweight processes.
     * 
     * Thread life cycle:
     * State 1: the instance of thread was created but the start method is not yet called;
     * State 2: The Ready State. When the thread is ready to run and waiting.
     * State 3: Not runnable. the thread is not executable when sleep/wait/blocked by I/O method has been called.
     * State 4: The Dead State: Thread complete execution.
     */
    class Program
    {
        public static void CallNewThread()
        { 
            try
            {
                int sleep = 5000;
                Console.WriteLine("A new Child thread will start soon ... Pausing for {0} seconds.", sleep / 1000);
                Thread.Sleep(sleep);
                Console.WriteLine($"That's {sleep / 1000} seconds for a good nap! I'm done now!");
                
            }
            /*
             * ThreadAbortException is a special exception that can be caught, but it will automatically be raised again at the end of the catch block.
             * 
             * When this exception is raised, the runtime executes all the finally blocks before ending the thread
             * 
             * If you want to wait until the aborted thread has ended, you can call the Thread.
             */
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception.");
            }
            finally
            {
                Console.WriteLine("is not caught by the Thread exception.");
            }
        }
        static void Main(string[] args)
        {
            Thread currThread = Thread.CurrentThread;
            currThread.Name = "This is the Main Thread.";

            CultureInfo currUIcultureInfo = currThread.CurrentUICulture;
            CultureInfo currCultureInfo = currThread.CurrentCulture;

            bool isAlive = currThread.IsAlive;
            bool isBackground = currThread.IsBackground;

            DisplayThreadInfo(currThread);

            ThreadStart child = new ThreadStart(CallNewThread);
            Console.WriteLine("In Main method, a child thread is being created ...");
            Thread childThread = new Thread(child);
            childThread.Start();
            childThread.Name = "The child thread";

            PauseThread(childThread);
            DisplayThreadInfo(childThread);

            Console.ReadKey();
        }

        public static void DisplayThreadInfo(Thread thread)
        {
            Console.WriteLine(thread.Name + '\n');
            Console.WriteLine($"Current UI Culture Info: {thread.CurrentUICulture}");
            Console.WriteLine($"Current Culture Info: {thread.CurrentCulture.ToString()}");
            Console.WriteLine($"Is the current thread executing?: {thread.IsAlive}");
            Console.WriteLine($"is Current thread a background thread?: {thread.IsBackground}");
            Console.WriteLine("=====================================================================\n");
        } 

        public static void PauseThread(Thread thread)
        {
            int sleep = 3000;
            Console.WriteLine($"\n{thread.Name} starts soon ... just sleeping for {sleep/1000} seconds.");
            Thread.Sleep(sleep);
            Console.WriteLine($"That's {sleep / 1000} seconds for a good nap! I'm done now!");
        }
    }
}
