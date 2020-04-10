# Oversiew
## Communication Between Components
1. **Mediator** Pattern, working well with events.
```cs
// Create a class called Mediator:
public sealed class Mediator    // Cannot be overwritten.
{
  // Static Members:
    // Make a static read only field, return the instance of Mediator that'll be shared across all components.
    private static readonly Mediator _Instance = new Mediator();
    private Mediator()  { }
    public static Mediator GetInstance(){
        return _Instance;
    }
    
  // Instance Functionality:
    public event EventHandler<JobChangedEventArgs> JobChanged;
    public void OnJobChanged(object sender, Job job){
        var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
        if (jobChangedDelegate != null){
            jobChangedDelegate(sender, new jobChangedEventArgs {Job = job });
        }
    }
}
```
2. Write custom event and delegate, and allow components in a WPF app to communicate with each other.

## Asynchronous Delegates
Delegates that can be used to **spawn background threats**.

## Using BackgroundWorker Event

## The role of delegates with threads
