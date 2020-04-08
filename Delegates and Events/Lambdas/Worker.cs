using System;
using System.Collections.Generic;
using System.Text;

namespace LambdasAndDelegates
{
    // public delegate void WorkPerformedHandler(int hours, WorkType workType);
    // public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e); // valid after WorkPerformanceEventArgs created.
    
    class Worker
    {
        /*
            public event WorkPerformedHandler WorkPerformed;
            public event EventHandler WorkCompleted;

            in program.cs:

        */
        // To allow delegate inference:
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;    // Eliminate line 8.
        public event EventHandler WorkCompleted;


        public virtual void DoWork(int hours, WorkType workType)
        {
            // Do work here and notify customers that work has been performed.
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i+1, workType);   // "On" is commonly used when Raising an event in .NET framework.
            }
            OnWorkCompleted();
        }

        // "protected virtual" instead of "private": Allow method override for later.
        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            // Preferred Approach 
            // var del = WorkPerformed as WorkPerformedHandler;
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                // del(hours, workType);       // Raise Event
                del(this, new WorkPerformedEventArgs(hours, workType));
            }

            //Diff Approach
            /*
            if (WorkPerformed != null)
            {
                WorkPerformed(hours, workType);
            }
            */
        }
        
        protected virtual void OnWorkCompleted()
        {
            // Preferred Approach 
            EventHandler del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);       // Raise Event
            }

            //Diff Approach:
            if (WorkCompleted != null)
            {
                WorkCompleted(this, EventArgs.Empty);
            }
        }
    }
}
