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

    class BalanceLogger // logs the balance.
    {
        public void balanceLog(int total)   // int matches the signature of the event handler delegate.
        {
            Console.WriteLine("The balance amount is: {0}", total);
        }
    }

    class BalanceWatcher    // if we have met the saving goal.
    {
        public void balanceWatch(int total) // int matches the signature of the event handler delegate.
        {
            if (total > 500) Console.WriteLine("You've met your savings goal! Now you have ${0}.", total);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PiggyBank pb = new PiggyBank();
            BalanceLogger bl = new BalanceLogger();
            BalanceWatcher bw = new BalanceWatcher();

            pb.balanceChanged += bl.balanceLog;
            pb.balanceChanged += bw.balanceWatch;

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
