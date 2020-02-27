using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            User Alice = new User("Alice");
            Alice.Hello();
            // Object Alice = new User();
            // ((User) Alice).Hello();

            Console.WriteLine(Alice);
            Console.WriteLine(Alice.ToString());    // When base clas is not specified, User : Object.
            // Therefore, .ToString can be used on the User class.
            Console.WriteLine(Alice);

            Student Bob = new Student();

            MagicList<int> myList = new MagicList<int>();
            myList.Add(10);
            myList.Add(20);
            myList.Add(30);
            myList.Add(40);
            Console.WriteLine(myList.chooseRandom());

            User st1 = new User(); st1.UserName = "st1";
            User st2 = new User(); st2.UserName = "st2";
            User st3 = new User(); st3.UserName = "st3";
            User st4 = new User(); st4.UserName = "st4";
            User st5 = new User(); st5.UserName = "st5";
            User st6 = new User(); st6.UserName = "st6";
            MagicList<User> magicUsers = new MagicList<User>();
            magicUsers.Add(st1);
            magicUsers.Add(st2);
            magicUsers.Add(st3);
            magicUsers.Add(st4);
            magicUsers.Add(st5);
            magicUsers.Add(st6);
            Console.WriteLine(magicUsers.chooseRandom());
            Console.WriteLine(magicUsers[3]); // Setting the index will return the item at the index. lose random function.

            Console.WriteLine();
            Console.WriteLine("\nPress Enter to exit...");
        }
    }
    class User
    {
        public string UserName { get; set; } 
        protected string Password { get; set; } // protected so the student class can access the variables.
        public virtual void Hello() // virtual allows subclasses to override the method.
        {
            Console.WriteLine($"Hello {UserName}"); // this.UserName.
        }
        public User(string newName)
        {
            UserName = newName;
            Password = "password";
        }
        public User()
        {
            UserName = "New User";
            Password = "password";
        }
        public override string ToString()
        {
            // return base.ToString();
            return UserName;
        }
    }
    class Student : User
    {
        protected string StudentName;
        public override void Hello()
        {
            Console.WriteLine($"Hello Student: {StudentName}");
        }
    }
    class MagicList<T> : List<T> // T is a place holder, standing for type, can be replaced with anything.
    {
        public T chooseRandom()
        {
            Random randGenerator = new Random();
            return this[randGenerator.Next(0, Count)]; // bracket operator
        }
    }
    class Basse
    {
        public int myProperty1 { get; set; }
        protected int myProperty2 { get; set; }
        private int myProperty3 { get; set; }
        void Method()
        {
            myProperty1 = 10;
            myProperty2 = 10;
            myProperty3 = 10;
        }
    }
    class Derivedd : Basse
    {
        void Method()
        {
            myProperty1 = 20;
            myProperty2 = 20;
            // myProperty3 = 20;
        }
    }
    class Unrelated
    {
        void Method()
        {
            Basse inst = new Basse();
            inst.myProperty1 = 30;
            // inst.myProperty2 = 30;
        }
    }
}
