/*
 * LINQ allows users to perform querires over all types of data.
 * Parallel Language-integrated query (PLINQ) can be used on objects to potentially turn a sequential query into a parallel query.
 * 
 * Extension methods for using PLINQ are defined in the System.Linq.ParallelEnumerable class. 
 * Parallel versions of LINQ operators (WHERE, SELECT, SELECTMANY, GROUPBY, JOIN, ORDERBY, SKIP, TAKE) can be used.
 */

using System;
using System.Collections.Generic;
using System.Linq;  // Enumerable.Range...
using System.Text;
using System.Threading.Tasks;

namespace IntroPLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Enumerable.Range(0, 20);

            var parallelResult = num.AsParallel()   // type: ParallelQuery<int>.
                .AsOrdered()    // Needed for order.
                .Where(i => i % 2 == 0)
                .ToArray();     // type: int[].

            Console.WriteLine("Numbers in parallelResult int[]:");
            foreach (int i in parallelResult)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine("\n\nNumbers in parallelResult int[], Take 8:");
            foreach (int i in parallelResult.Take(8))
            {
                Console.Write(i + "  ");
            }


            var parallelResult1 = num.AsParallel()
                .AsOrdered()
                .Where(i => i % 2 == 0)
                .AsSequential();    // type: IEnumerable<int>.

            Console.WriteLine("\n\nNumbers in parallelResult IEnumerable<int>, Take 5:");
            foreach (int i in parallelResult1.Take(5))
            {
                Console.Write(i + "  ");
            }


            var parallelResult2 = num.AsParallel()
                .AsOrdered()
                .Where(i => i % 2 == 0);
            // type: ParallelQuery<int>.
            Console.WriteLine("\n\nNumbers in parallelResult ParallelQuery<int>.ForAll()");
            parallelResult2.ForAll(e => Console.WriteLine(e));  // No order even though specified in the object.


            Console.WriteLine("\n\nTry and Catch AggregateExceptions:");
            try
            {
                var parallelResult3 = num.AsParallel()
                    .Where(i => isEven(i));
                parallelResult3.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"There are {e.InnerExceptions.Count} exceptions.");
                foreach (var ex in e.InnerExceptions)
                    Console.WriteLine($"Exception Type: {ex.GetType()}\nDetails: " + ex.ToString() + '\n');
            }

            Console.WriteLine("\n\nPress Any key to continue ...");
            Console.ReadKey();
        }

        public static bool isEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException("i");
            return i % 2 == 0;
        }
    }
}
