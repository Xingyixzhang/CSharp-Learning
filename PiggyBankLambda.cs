using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Event
{
    // defines the signature of the event handler.
    public delegate void balanceEventHandler(int theValue);

    class PiggyBank // broadcast changes in the balance.
    {
        public int myBalance;
        public event balanceEventHandler balanceChanged;

        public int Balance
        {
            set
            {
                myBalance = value;
                balanceChanged(value);  // event triggered and change sent to all listeners.
            }
            get
            {
                return myBalance;
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            PiggyBank pb = new PiggyBank();

            // Using lambda to implement the previous two delegations,
            // Note that we do NOT have to specify the data type of total. Compiler figures out.
            pb.balanceChanged += (total) => Console.WriteLine("The balance total is: {0}", total);
            pb.balanceChanged += (int total) => { if (total >= 500) Console.WriteLine("You've reached your goal! " +
                "Your balance is now: {0}", total); };

            string str = "";
            while (str != "exit")
            {
                Console.Write("How much to deposit?\t");
                str = Console.ReadLine();
                if (str != "exit")
                {
                    int value = int.Parse(str);
                    pb.Balance += value;
                } 
            }

            Console.WriteLine("\nPress Enter to continue...");
        }
    }
}
