using System;
using System.Reflection;    // Access the assemblies.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Make the program .dll: right click project in solution window, properties -> output type: class library.
namespace Assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student();
            Console.WriteLine(st1);

            Student st2 = new Student("Alice", "Math", 3.98);
            Console.WriteLine(st2);

            var assembly = typeof(Student).Assembly;
            Console.WriteLine(assembly);
            foreach (var t in assembly.GetTypes())
            {
                Console.WriteLine(t);
            }

            var type = assembly.GetType("Assemblies.Student");
            Console.WriteLine("\n\n========== Student Methods ========");
            // var methods = type.GetMethods();
            foreach (var method in type.GetMethods())
                Console.WriteLine(method);

            Console.WriteLine("\n\n========== Student Fields ========");
            // var fields = type.GetFields();
            foreach (var field in type.GetFields())
                Console.WriteLine(field);

            Console.WriteLine("\n\n========== Student Constructors ========");
            // var ctors = type.GetConstructors();
            foreach (var ctor in type.GetConstructors())
                Console.WriteLine(ctor);

            Console.WriteLine("\n\n========== Student Properties ========");
            // var properties = type.GetProperties();
            foreach (var prop in type.GetProperties())
                Console.WriteLine(prop);

            //var assembly2 = Assembly.ReflectionOnlyLoadFrom("search-ms:displayname=Search%20Results%20in%20Windows&crumb=location:C%3A%5CWindows\amd64_netfx4-filetrackerui_dll_ln_b03f5f7f11d50a3a_4.0.15788.0_none_b4d93ad6ac44535f");
            //foreach (var t in assembly2.GetTypes()) { Console.WriteLine(t); }
            //Console.WriteLine("\n\n");
            //foreach (var m in assembly2.GetType().GetMethods("AnyMethodIndll"))
            //    Console.WriteLine(m);

            ConstructorInfo firstCtor = (type.GetConstructors())[0];  // since GetConstructors method returns an array of results.
            Console.WriteLine("\n\nThe first constructor is: " + firstCtor);

            Console.ReadKey();
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

    class Student: User
    {
        class SubClass
        {

        }
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

        //public new void MSSAMethod()      new: method appears twice in Student class.
        //{
        //}
    }
}
