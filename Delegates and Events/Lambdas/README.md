# Lambdas, Action\<T> and Func<T, TResult>
## Lambdas and Delegates
1. Compare an Anonymous Method and a Lambda Expression:
```cs
// Anonymous Methods in Action:
SubmitButton.Click += delegate(object sender, EventArgs e){
    MessageBox.Show("Button Clicked");
};
```
```cs
// Understand Lambda Expressions:
/*
Explanation of code:
1. (s, e): Inline Method Parameters. No need to define types, the compiler will figure it out.
2. =>: Lambda operator.
3. Right side of the operator is the method body.
*/
SubmitButton.Click += (s, e) => MessageBox.Show("Button Clicked");
```
2. Lambda expressions can be assigned to any delegate:
```cs
// Case 1: Handling delegates with Parameters:

delegate int AddDelegate(int a, int b);
static void Main(string[] args){
    AddDelegate ad = (a, b) => a + b;   // Compiler take care of the return part.
    int result = ad(1,1);   //result = 2.
}

// Case 2: Handling Empty Parameters:

delegate bool LogDelete();
static void Main(string[] args){
    LogDelegate ld = () =>
    {
        UpdateDatabase();   WriteToEventLog();
        return true;
    };
    bool status = ld();
}
```
See it in Code:
```cs
public class ProcessData{
    // pass in a delegate parameter, allowing the user to pass in the rules for how to process x and y.
    public void Process(int x, int y, BizRulesDelegate del){    // Avoid Hardcoding BizRules.
        var result = del(x, y);
        Console.WriteLine(result);
    }
}
```
```cs
public delegate int BizRulesDelegate(int x, int y);
class Program{
    static void Main(string[] args){
        BizRulesDelegate addDel = (x, y) => x + y;
        BizRulesDelegate multiplyDel = (x, y) => x * y;
        
        var data = new ProcessData();
        data.Process(2, 3, addDel); // Process is going to perform addition, it doesn't know till runtime.
        data.Process(2, 3, multiplyDel);
    }
}
```
***
### Built-In Delegates in .NET:
1. The .NET framework provides several different delegates that provide flexible options. Most Common:
2. Action\<T\>: Accepts a **single** parameter of type T and returns **no value**. (ONE WAY PIPELINE)
3. Func\<T, TResult\>: Accepts a **single** parameter of type T and return a **value of type TResult**.
***
```cs
// var myLambda = (x) => x + x;
Func<string> returnsHello = () => "Hello World!";

Action displayHello = () => { Console.WriteLine("Hello"); };
Action<string> sayHello = (name) => { Console.WriteLine("Hello {0}", name); };


```
## Using Action<T>
Action\<T\> saves you the time of writing: delegate void, \<name of delegate\>.
```cs
public static void Main(string[] args){
    Action<string> messageTarget;
    // Dynamically assign an action (ShowWindowMessage / Console.WriteLine (that can take the string as a parameter):
    if (args.Length > 1)    messageTarget = ShowWindowsMessage;
    else    messageTarget = Console.WriteLine;
    messageTarget("Invoking Action!");
}
    
private static void ShowWindowsMessage(string message){
    MessageBox.Show(message);
}
```
## Using Func<T, TResult>
1. Func<T, TResult> supports a single parameter (T) and returns a value (TResult):
```cs
public static void Main(string[] args){
    Func<string, bool> logFunc;
    if (args[0] == "EventLog") logFunc = LogToEventLog;
    else    logFunc = LogToFile;
    bool status = logFunc("Log Message");
}

private static bool LogToEventLog(string message)   { /* log */ }
private static bool LogToFile(string message)       { /* log */ }
```
