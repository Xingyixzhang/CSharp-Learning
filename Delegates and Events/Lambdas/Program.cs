using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace LambdasAndDelegates
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer {City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer {City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500},
                new Customer {City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer {City = "Phoenix", FirstName = "Abriel", LastName = "Lindsy", ID = 45},
                new Customer {City = "NYC", FirstName = "Michelle", LastName = "Smith", ID = 4}
            };

            var phxCustomers = customers
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);  // using System.Linq to query objects

            foreach (var customer in phxCustomers)
            {
                Console.WriteLine(customer.FirstName + " is from " + customer.City);
            }

            var data = new ProcessData();
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            data.Process(2, 3, multiplyDel);

            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultiplyDel = (x, y) => x * y;
            data.ProcessFunc(4,5,funcAddDel);

            Action<int, int> addAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> multiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, addAction);
            data.ProcessAction(2, 3, multiplyAction);

            var worker = new Worker();
            worker.DoWork(7, WorkType.GenerateReports);

            /*
            // Delegate Inference:
            worker.WorkPerformed += worker_WorkPerformed;
            worker.WorkCompleted += worker_WorkCompleted;

            worker.DoWork(8, WorkType.GenerateReports);

            static void worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
            {
                Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            }
            static void worker_WorkCompleted(object sender, EventArgs e)
            {
                Console.WriteLine("Work is done");
            }
            */

            // Lambda Approach for the code above:
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            };
            worker.WorkCompleted += (s,e) => Console.WriteLine("Work is done");

            Console.Read();
        }
    }
}
