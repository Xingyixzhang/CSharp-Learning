# Overview

### Delegate is based on a MulticaseDelegate base class.
    
### A delegate is a specialized class functioning as a pipeline between event and event handler.
    Event ======================= Delegate (Pipeline) ========================> Event Handler
    
### Delegate and Handler Method Parameters:
```cs
public delegate void WorkPerformedHandler(int hours, WorkType workType);
public void Manager_WorkPerformed(int workHours, WorkType wType){ // Handler Method
    ... ...
}
```
    
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

### Define an Event:
<public + keyword: event + delegate + event name;>

``` public event WorkPerformedHandler WorkPerformed;```
