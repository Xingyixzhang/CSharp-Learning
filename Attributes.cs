using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    enum FontType
    {
        Italic,
        Bold,
        Normal,
        Underline
    }

    [AttributeUsage(AttributeTargets.All)]
    class MSSAAttribute : Attribute
    {
        public int MSSAProperty { get; set; }
        public MSSAAttribute(string message)
        {
            Console.WriteLine(message + ". The property is: " + MSSAProperty);  
            // property is going to be 0 regardless of what you set it to be.
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    class ClassAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    class PropertyAttribute : Attribute
    {
        public int Property { get; set; }
        public PropertyAttribute(string message)
        {
            Console.WriteLine(message);
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    class MethodOrFieldAttribute : Attribute
    {

    }

    [Class]
    class Program
    {
        //[Class] / [MSSA]
        [MethodOrField]
        static void Main(string[] args)
        {
            Student myStudent = new Student();
            Console.WriteLine(myStudent + "\n");

            var type = typeof(Student);
            //var method = type.GetMethod("public override string ToString()");

            Console.WriteLine(type.GetCustomAttributes(true));
            Console.WriteLine("\n");
            //Console.WriteLine(method.GetCustomAttributes());
            //Console.WriteLine("\n");

            foreach (var p in type.GetProperties())   
                Console.WriteLine(p);
            Console.WriteLine("\n");

            Console.WriteLine(FontType.Bold | FontType.Italic);
            Console.WriteLine(FontType.Normal + "\n");

            FontType custom = FontType.Italic;
            custom = FontType.Bold;
            Console.WriteLine(custom + "\n");

            custom = FontType.Normal | FontType.Underline;
            Console.WriteLine(custom + "\n");
        }
    }

    class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool Login()
        {
            return false;
        }

        public virtual void MSSAMethod()
        {

        }
    }

    [MSSA("Class Student: User", MSSAProperty = 2020)]
    class Student : User
    {
        class SubClass
        {

        }

        [Property("Student Full Name")]
        public string Name { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        public override string ToString()
        {
            return Name + ": " + Major + " = " + GPA;
        }

        public Student()
        {
            Name = "No Name";
            Major = "Undecided";
        }

        public Student(string name, string major, double gpa)
        {
            Name = name;
            Major = major;
            GPA = gpa;
        }

        public override void MSSAMethod()
        {
            // base.MSSAMethod();
        }
    }
    }
