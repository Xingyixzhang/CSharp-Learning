using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNameSpace;

namespace ClassHierarchyByInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student();
            st1.UserName = "Alice";

            /*
             * Abstract class cannot be instantiated.
             * If you inherit from an abstract class, you must provide implementations for all abstract members.
                User u1 = new User();  <-- would not compile.
                u1.UserName = "Bob";
                Admin u2 = new User(); <-- would not compile.
            */
            User u1 = new Admin();
            // u1.Department = "MSSA"; <-- would not compile.
            ((Admin)u1).Department = "MSSA";
        
            User userAdmin = new Admin();

            // When using the non-virtual method Hello():       calls the method in Base class.
            userAdmin.Hello();      // "Hello from the Users"

            // When using the virtual method HelloWorld():      calls the method in Derived class.
            userAdmin.HelloWorld(); // "Hello world from the Users"  -- if you used base.HelloWorld(); in your override method.
                                    // "Hello world From the Admins"

            var myList = new List<int>();
            myList.Add(2020);
            myList.Add(1893);
            myList.Add(2039);

            myIntListClass myList1 = new myIntListClass();
            myList1.Add(2);
            myList1.Add(5);
            myList1.Add(3);

            myListClass<int> myList2 = new myListClass<int>();
            myList2.Add(7);
            myList2.Add(5);
            myList2.Add(3);
            myList2.Add(-8);
            myList2.Add(7);
            myList2.Add(-5);
            myList2.Add(3);
            myList2.RemoveDups();
            myList2.MyProperty = "MSSA";
            foreach (int num in myList2)
            {
                Console.Write(myList2.MyProperty + num + " ");
            }
            Console.WriteLine("\n");
            
            myListClass<Admin> myList3 = new myListClass<Admin>();
            myList3.Add(new Admin("MSSA", "Michael", "Pa$$w0rd"));

            //myStringClass str = null;
            //str.myMethod();

            // An extension method is a type of static method.
            // To create an extension method, you create a static method within a static class. 
            string str = "MSSA is a great program.";
            str.MyMethod(45);
            Console.WriteLine();
            str.DisplayEverOtherChar();
            Console.WriteLine("\n");
            str.Normalize();    // Doesn't call the extension since String already has the Normalize() method.
            str.myNormalize();
            Console.WriteLine();

            MyDerivedClass dc = new MyDerivedClass();   // Base Default is called + Derived Default is called.
            Console.WriteLine();
            MyBaseClass bc = new MyBaseClass();         // Base Default is called.
            Console.WriteLine();
            MyBaseClass bcdc = new MyDerivedClass();    // Base Default is called + Derived Default is called.
            Console.WriteLine();
            // MyDerivedClass dcbc = new MyBaseClass(); <-- Not valid.
            MyBaseClass bcdc1 = new MyDerivedClass("MSSA");// Base Default is called + Derived non-default is called.
            Console.WriteLine();
            MyDerivedClass dc1 = new MyDerivedClass("MSSA"); // Base Default is called + Derived non-default is called.
        }
    }
    /*
     * An abstract class can contain both abstract and non-abstract  
     * */
    abstract class User
    {
        public string UserName { get; set; }
        public string  Password { get; set; }
        private int MyPrivateProperty { get; set; }         // Can only be accessed in User class, not derived classes nor anywhere else.
        protected int MyProtectedProperty { get; set; }     // protected can be accessed in User class and all derived classes. Not in class Program.

        public abstract void MyMethod();    // Force derived classes to override the method. No need to define method body.
        public void Hello()                 // Not marked virtual, cannot be override.
        {                                                                               
            Console.WriteLine("Hello from the Users!");
        }
        public virtual void HelloWorld()    // virtual: enables later override operations. Has a method body then allow override.
        {
            Console.WriteLine("Hello world from the Users!");
        }
        public User()                       // You may not override a constructor. No virtual shall be marked here.
        {

        }
        public User(string newUser, string newPassword)
        {
            UserName = newUser;
            Password = newPassword;
        }
    }

    class Admin: User
    {
        public string  Department { get; set; }
        public override void MyMethod() 
        {
            Console.WriteLine("Hello from the Admins!");
        }
        public new void Hello()     // override EXTENDS the base class method; new HIDES the base class method. When called, both call the method in derived class.
        {
            Console.WriteLine("Admin now has 2 Hello() methods. Not wrong but not best practice.");
        }
        public sealed override void HelloWorld()   // sealed modifier can only be applied if the member is an override member.
        {
            base.HelloWorld();      // You don't need this, use only if you want the original and just add up to it.
            Console.WriteLine("Hello world from the Admins!");  // Add this on top of base method.
            //base.Hello();         <-- Valid.
            //base.HelloWorld();    <-- Valid.
            // In java, Calling base method: super(...); and has to be the first line in override method to implement.
        }

        public Admin()
        {

        }

        public Admin(string newDepartment, string newUser, string newPass): base(newUser, newPass)  // Call the base constructor.
        {
            Department = newDepartment;

            // In case the base class does more like validation. Best Practice is to call the base constructor.
            //UserName = newUser;
            //Password = newPass;
        }
    }

    class Student : User
    {
        public string Major { get; set; }
        public override void MyMethod()
        {
            Console.WriteLine("Hello from the Students!");
        }
    }
    /*
     *  public sealed class...: cannot have derived classes.
     *  static class is sealed class. You may not inherit from static classes.
     *  sealed method is implemented so that no other class can overthrow it and implement its own method.
     *  
     *  Main purpose of  the sealed class is to withdraw the inheritance attribute from the user 
     *  so that they can't attain a class from a sealed class. 
     *  
     *  Sealed classes are used best when you have a class with static members.
     * */

    public class myIntListClass : List<int>     // Non generic class, uses int for T in List<T>.
    {

    }

    public class myListClass<T>: List<T>       // Generic class, T type.
    {
        // now, myListClass<T> = List<T> + RemoveDups method.
        public void RemoveDups()
        {
            base.Sort();
            for (int i = this.Count - 1; i > 0; i--)
            {
                if (this[i].Equals(this[i - 1])) this.RemoveAt(i);
            }
        }

        // now, myListClass<T> = List<T> + RemoveDups method + MyProperty.
        public string MyProperty { get; set; }

        public void myMethod()
        {
            throw new myExceptionClass();
            throw new myExceptionClass("myExceptionClass is called.");
            throw new myExceptionClass("myExceptionClass is called.", new Exception("and by the way ..."));
            throw new NotImplementedException("myMethod has not yet been implemented.");
        }
    }

    class myExceptionClass: Exception
    {
        // Highly recommend: always have at least the following three constructors when creating you custom exception class.
        public myExceptionClass()
        {

        }
        public myExceptionClass(string message)// :base(message)  -- best practice
        {

        }
        public myExceptionClass(string message, Exception inner)// :base(message, inner) -- best practice
        {

        }
    }

    //class myStringClass: String       // would be invalid. String is a sealed class.
    //{
    //    public void myMethod()
    //    {

    //    }
    //}

    public class MyBaseClass
    {
        public MyBaseClass()    // if base class has only non-default constructor(s), Derived class default class would be invalid. 
        {                       // Since when not specified, derived class automatically look for and calls the base default constructor.
            Console.WriteLine("Base default constructor is called.");
        }
        public MyBaseClass(string str)
        {
            Console.WriteLine("Base non-default constructor is called.");
        }
    }
    public class MyDerivedClass: MyBaseClass
    {
        public MyDerivedClass()//:base() automatically implemented when not specified otherwise.
        {
            Console.WriteLine("Derived default constructor is called.");
        }
        public MyDerivedClass(string str)//:base(str) automatically implemented when not specified otherwise.
        {
            Console.WriteLine("Derived non-default constructor is called.");
        }
    }

}
namespace MyNameSpace
{
    public static class MyStaticClass 
    { 
        public static void MyMethod(this string s, int num)
        {
            Console.WriteLine("I called MyMethod \"from\" string! with the value: {0}", num);
        }
        public static void DisplayEverOtherChar(this string s)
        {
            for (int i = 0; i < s.Length; i += 2)
            {
                Console.Write(s[i] + " ");
            }
        }
        public static void Normalize(this string str)
        {
            Console.WriteLine("Normalize");
        }
        public static void myNormalize(this string str)
        {
            Console.WriteLine("myNormalize");
        }
    }
}
