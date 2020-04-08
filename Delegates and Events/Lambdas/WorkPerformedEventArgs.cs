using System;
using System.Collections.Generic;
using System.Text;

namespace LambdasAndDelegates
{
	public class WorkPerformedEventArgs: System.EventArgs
	{
		public int Hours { get; set; }
		public WorkType WorkType { get; set; }

		public WorkPerformedEventArgs(int hours, WorkType workType)
		{
			Hours = hours;
			WorkType = workType;
		}
	}
}
