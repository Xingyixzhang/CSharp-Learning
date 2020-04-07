# Lambdas, Action<T> and Func<T, TResult>
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
    int result = ad(1,1); //result = 2.
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
## Using Action<T>

## Using Func<T, TResult>
