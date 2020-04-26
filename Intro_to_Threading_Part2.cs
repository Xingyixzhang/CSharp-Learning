using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IntroThreading2
{
    class Program
    {
        public static int counter;

        /*
         * Thread Local allows us to store local data in a thread and initialize it.
         */
        public static ThreadLocal<int> local = new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });

        static void myThreadToStart()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Thread Process: {i}");
                Thread.Sleep(0);
            }
        }

        static void myParaThreadToStart(object o)
        {
            for (int i = 0; i < Convert.ToInt32(o); i++)
            {
                Console.WriteLine($"Thread Process: {i}");
                Thread.Sleep(0);
            }
        }

        static void Main(string[] args)
        {
            Thread myThread = new Thread(new ThreadStart(myThreadToStart));
            myThread.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"This is the main thread: {i}");
                Thread.Sleep(0);
            }
            myThread.Join();    // wait till the other finishes. Piority management.



            /*
             * Foreground Threads VS Background Threads:
             * Foreground threads keep an application alive as long as they are running, 
             *      while background threads do not.
             * when you close applications, all background threads are automatically terminated.
             */

            // Foreground/ Backgound thread:
            Thread myThread2 = new Thread(new ThreadStart(myThreadToStart));
            myThread2.IsBackground = true;  // Background thread
            Console.WriteLine("=========================================================" +
                "my second thread starts: \n"); // Appear after 20 outputs.
            myThread2.Start();

            Thread myThread3 = new Thread(new ThreadStart(myThreadToStart));
            myThread3.IsBackground = false; // Foreground thread
            Console.WriteLine("=========================================================" +
                 "my third thread starts: \n"); // Appear Before 20 outputs.
            myThread3.Start();



            // ParameterizedThreadStart. Pass in the parameter (object!!) when calling the Start() function.
            
            Thread myParaThread = new Thread(new ParameterizedThreadStart(myParaThreadToStart));
            Console.WriteLine("=========================================================" +
                 "my third thread starts: \n");
            myParaThread.Start(5);  // To see the nice output, comment out previous code.
            myParaThread.Join();


            // Stopping threads:
            bool stop = false;

            Thread myThread4 = new Thread(new ParameterizedThreadStart((n) =>
            {
                int num = Convert.ToInt32(n);
                while (num >= 0 && !stop)
                {
                    num--;
                    Thread.Sleep(2000);
                    Console.WriteLine($"Thread is Running ... Counting down: {num+1}");
                }
            }));

            myThread4.Start(5);
            myThread4.Join();
            Console.WriteLine("Press any key to exit ...");

            Console.ReadKey();
            stop = true;
            myThread4.Join();


            // ThreadStatic Attributes:
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    counter++;
                    Console.WriteLine($"Thread 1: {counter}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    counter++;
                    Console.WriteLine($"Thread 2: {counter}");
                }
            }).Start();


            // Use the Local Thread:
            new Thread(() =>
            {
                for (int i = 0; i < local.Value; i++)
                {
                    Console.WriteLine($"Thread 3 (the use of local thread): {i}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < local.Value; i++)
                {
                    Console.WriteLine($"Thread 4 (the use of local thread): {i}");
                }
            }).Start();


            /* Thread Pools:
             * A thread pool is a collection of worker threads that efficiently execute asynchronous callbacks on behalf of the application. 
             * The thread pool is primarily used to reduce the number of application threads and provide management of the worker threads.
             * 
             * A thread pool is a software design pattern for achieving concurrency of execution in a computer program
             * 
             * A thread pool is created to reuse( ** Only reuse their local state**) the threads, ~= database connection pooling.
             * Instead of letting a thread die, send it back to the pool where it can be used whenever a request comes in.
             */

            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool right here ...");
            });


            /*
             * Using Tasks:
             * 
             * Queuing a work item to a thread pool has no built-in way to know when the operation has finished and 
             *                     what the return value is.
             * Task is an object representing some work that should be done. it can tell the user if the work is completed and if the operation
             *          returns a result. The task gives the user the results.
             *          
             * Tasks make apps more responsive. By default, the Task Scheduler uses threads from the thread pool to execute the Task.
             */

            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine('%');
                }
            });
            task.Wait();
            Console.WriteLine();

            // Adding a continuation:
            Task<int> task2 = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });
            Console.WriteLine(task2.Result);        // output: 84.

            //Attaching child tasks to a parent task:
            Task<int[]> parent = Task.Run(() =>
            {
                var results = new int[3];

                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });
            var finalTask = parent.ContinueWith(parentTask =>
           {
               foreach (int i in parentTask.Result)
                   Console.WriteLine(i);
           });

            finalTask.Wait();

            /*
             * Exceptions in Child tasks:
             * 
             * If a detached child task throws an exception, 
             *      that exception must be observed or handled directly in the parent task just as with any non-nested task. 
             * If an attached child task throws an exception, 
             *      the exception is automatically propagated to the parent task and back to the thread that waits or tries to access the task's Task<TResult>.Result property. 
             * Therefore, by using attached child tasks, you can handle all exceptions at just one point in the call to Task.Wait on the calling thread.
             */

            Console.WriteLine("Press Any Key to Exit ...");
            Console.ReadKey();
        }
    }
}
