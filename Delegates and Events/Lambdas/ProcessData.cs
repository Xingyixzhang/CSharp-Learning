using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LambdasAndDelegates
{
    class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessAction(int x, int y, Action<int, int> action) // Action<T> can take many parameters.
        {
            // var result = action(x, y);   <-- Invalid, action is void.
            action(x, y);
            Console.WriteLine("Action has been processed.");
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }
    }
}
