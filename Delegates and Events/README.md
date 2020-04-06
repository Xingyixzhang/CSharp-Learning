# Overview

### Delegate is based on a MulticaseDelegate base class.
    
### A delegate is a specialized class functioning as a pipeline between event and event handler.
    Event ======================= Delegate (Pipeline) ========================> Event Handler
***
## 1. Creating Delegates, Events, and EventHandlers
### Delegate and Handler Method Parameters:
```cs
public delegate void WorkPerformedHandler(int hours, WorkType workType);
public void Manager_WorkPerformed(int workHours, WorkType wType){ // Handler Method
    ... ...
}
```

### Define an Event:
<public + keyword: event + delegate + event name;>

``` public event WorkPerformedHandler WorkPerformed;```

### Multicast Delegate:
1. Can refernce >= 1 function
2. Tracks delegate references using an invocation list
3. Delegates in the list are invoked sequentially
```cs
// Delegate Instances:
WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            
// Adding to Invocation List:
del1 += del2;
del1(5, WorkType.GoToMeetings);

// Handlers:
static void WorkPerformed1 (int hours, WorkType wType){
    Console.WriteLine("WorkPerformed1 called.");
}
static void WorkPerformed2 (int hours, WorkType wType){
    Console.WriteLine("WorkPerformed2 called.");
}
```

### Exposing and Raising Events:
```cs
public delegate void WorkPerformedHandler(int hours, WorkType workType);
public class Workers{
    public event WorkPerformedHandler WorkPerformed;    // Event Definition
    public event EventHandler WorkCompleted;
        
    public virtual void DoWork(int hours, WorkType workType){
        // Do work here and notify customers that work has been performed.
            OnWorkPerformed(hours, workType);   // "On" is commonly used when Raising an event in .NET framework.
        OnWorkCompleted():
    }
        
    // "protected virtual" instead of "private": Allow method override for later.
    protected virtual void OnWorkPerformed(int hours, WorkType workType){
        // Preferred Approach 
        WorkPerformedHandler del = WorkPerformed as WorkPerformedHandler;
        if (del != null){
            del(hours, workType);       // Raise Event
        }
            
        //Diff Approach
        if (WorkPerformed != null){
            WorkPerformed(hours, workType);
        }
    }
    
    protected virtual void OnWorkCompleted(object sender, EventArgs e){    
        // Preferred Approach 
        EventHandler del = WorkCompleted as EventHandler;
        if (del != null){
            del(this, EventArgs.Empty);       // Raise Event
        }
        
        //Diff Approach:
        if (WorkCompleted != null){
            WorkCompleted(this, EventArgs.Empty);
        }
    }
```

### Create an EventArgs class
Use the EventArgs to send the data from the event raiser over the pipeline. When custom data needs to be passes, the EventArgs class can be extended.

```cs
public class WorkPerformedEventArgs: System.EventArgs
{
	public int Hours { get; set; }
	public WorkType WorkType { get; set; }
	
	public WorkPerformedEventArgs(int hours, WorkType workType){
		Hours = hours;
		WorkType = workType;
	}
}

// To use the custom EventArgs class, the delegate must reference the class in its signature:
public delegate void WorkPerformedHandler(object sender, WorkPerformedEventArgs e);

/* 
	Since .NET includes a generic EventHandler<T> class, it can be used instead of a custom delegate.
	The above code may be deleted when we use the generic feature of .NET EventHandler:
	(Choose when you only need the event without needing the delegate stand on its own.)
*/
public event EventHandler<WorkPerformedEventArgs> WorkPerformed; // Compiler will generate the delegate 

// To Raise the event:
protected virtual void OnWorkPerformed(int hours, WorkType workType){
        // When not using the generic feature:
        WorkPerformedHandler del = WorkPerformed as WorkPerformedHandler;
	// When using the generic feature:
	WorkPerformedHandler del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
	
        if (del != null){
            del(this, new WorkPerformedEventArgs(hours, workType));       // Raise Event
        }
}
```
***
## 2. Handling Events
### Instantiating delegates and Handling events
```cs
var worker = new Worker();

// the += operator: Attach an event to an event handler:
worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker_WorkPerformed);
worker.WorkCompleted += new EventHandler(worker_WorkCompleted);

worker.DoWork(8, WorkType.GenerateReports);
```
```cs
static void worker_WorkPerformed(object sender, WorkPerformedEventArgs e){
	Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
}
static void worker_WorkCompleted(object sender, EventArgs e){
	Console.WriteLine("Work is done");
}
```
### Delegate Inference
Replace the 2nd above code with:
```cs
var worker = new Worker();

// the compiler will "infer" the delegate behind the scenes:
worker.WorkPerformed += worker_WorkPerformed;
worker.WorkCompleted += worker_WorkCompleted;

// delegate inference also works for dettaching event handlers:
worker.WorkCompleted -= worker_WorkCompleted;
```
### Using Anonymous Methods
