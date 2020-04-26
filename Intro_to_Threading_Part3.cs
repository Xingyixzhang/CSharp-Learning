using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   // Parallel.
using System.Threading;
using System.Net.Http;

namespace IntroThreading3
{
    class Program
    {
        /*
         * Parallel Class
         * 
         * Parallelism involves taking a certain task and splitting it into a set of 
         * related tasks that can be executed concurrently.
         * 
         * Note that ONLY USE the parallel class when the code does not have to be executed sequentially.
         */
        static void Main(string[] args)
        {
            // using Parallel.For:
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("Now on number {0}", i);
                Thread.Sleep(1000);
            });

            // using Parallel.Foreach:
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Console.WriteLine("Now on number {0}", i);
                Thread.Sleep(1000);
            });

            // using Parallel.Break:
            ParallelLoopResult result = Parallel.For(0, 20, (int i, ParallelLoopState loopState) =>
            {
                if (i == 10)
                {
                    Console.WriteLine("Breaking loop");
                    loopState.Break();
                }
                return;
            });


            /* Async & Await:
             * 
             * ASYNC a a keyword to mark a method for asynchronous operations,
             * that way the compiler gets signaled sth asynchronous is going to happen.
             * 
             * The compiler responds by transforming code into a state machine.
             * 
             * A method marked with async just starts running synchronously on and only on the current thread.
             * 
             * AWAIT keyword makes the compiler generate code that'll see if the async operation has finished.
             *      if yes, method continues running asyncly;
             *      if not, the state machine hook up a continuation method that should run when the task completes.
             *              your method yields control to the calling thread,
             *              and this thread can be used to do other work.
             *              
             * NOTE: 1. Never have a method marked async without any await statements.
             *       2. Always avoid returning void from an async method EXCEPT when it's an event handler.
             */

            string res = DownloadContent().Result;
            Console.WriteLine(res);
        }

        public static async Task<string> DownloadContent() {
            using (HttpClient client = new HttpClient()) {
                string res = await client.GetStringAsync("http://www.microsoft.com");
                return res;
            }
        }
    }
}
