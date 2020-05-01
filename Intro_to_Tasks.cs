using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Intro_to_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task task1 = new Task(new Action(SayHello));
            Task task1 = new Task(() => SayHello());
            Task<string> task2 = new Task<string>(() => { return "Hello MSSA!"; });
            task1.Start();
            task2.Start();
            task1.Wait();   // Without waiting for task1 to finish, the Console may or may NOT have the hello message AFTER done.
            // task2.Wait();    UNCESSARY when using task.Result.
            Console.WriteLine(task2.Result);
            Console.WriteLine("Done.");

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            //Task task3 = new Task(() => LongRunningTask(ct, "Task 3"));
            //task3.Start();

            //Thread.Sleep(5000); // Cancel task3 after 5 seconds.
            //cts.Cancel();
            //try
            //{
            //    task3.Wait();
            //}
            //catch (AggregateException e)
            //{
            //    foreach (var innerExc in e.InnerExceptions)
            //    {
            //        if (innerExc is TaskCanceledException)
            //        {
            //            Console.WriteLine("Task 3 was cancelled");
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //}
            // Console.WriteLine("Task 3 Status: \n" + task3.Status);

            Task task4 = Task.Run(() => LongRunningTask(ct, "Task 4"), ct);
            task4.Start();

            Thread.Sleep(5000); // Cancel task3 after 5 seconds.
            cts.Cancel();
            try
            {
                task4.Wait();
            }
            catch (AggregateException e)
            {
                foreach (var innerExc in e.InnerExceptions)
                {
                    if (innerExc is TaskCanceledException)
                    {
                        Console.WriteLine("Task 4 was cancelled");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            task4.Wait();
            Console.WriteLine("Task 4 Status: \n" + task4.Status);


            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            Console.WriteLine("============================ Parallel.For ================================");
            Parallel.For(0, nums.Length, (i) => { Console.Write(nums[i] * nums[i] + "\t"); });
            Console.WriteLine("\n\n============================ Parallel.Foreach ================================");
            Parallel.ForEach(nums, (item) => { Console.Write(item * item + "\t"); });
            Console.WriteLine("\n");


        }

        static void SayHello()
        {
            Console.WriteLine("Hello Xingyi!!");
        }
        static void LongRunningTask(CancellationToken ct, string tasknum)
        {
            Console.WriteLine($"======================================= This is {tasknum} ==========================================");
            for (int i = 0; i < 1000; i++)
            {
                ct.ThrowIfCancellationRequested();
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }
}
