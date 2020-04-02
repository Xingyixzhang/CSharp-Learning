using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
        // About yield return: returns an IEnumerable type for foreach to be valid.
        static IEnumerable Method()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            foreach (var x in arr)
                yield return x;
        }
        static IEnumerable Method2()
        {
            yield return 2;
            yield return 12;
            yield return 4;
            yield return 5;
            yield return 3;
            yield return 7;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Numbers in method (IEnumerable):");
            foreach (var num in Method())
            {
                Console.Write( "{0, -5}", num);
            }

            Console.WriteLine("\n\nNumbers in method2 (IEnumerable, with a stack of yield return numbers):");
            foreach (var num in Method2())
            {
                Console.Write("{0, -5}", num);
            }
            
            Console.WriteLine("\n");
            // Cannot create an instance of an Interface.

            Student myStudent = new Student();
            myStudent.Name = "Alice";

            Instructor myInstructor = new Instructor();
            myInstructor.Name = "Bob";

            MyFancyMethod(myStudent);
            MyFancyMethod(myInstructor);

            ArrayList studentList = new ArrayList();
            studentList.Add(new Student() { Name = "Alice", GPA = 4.0, Major = "Math"});
            studentList.Add(new Student() { Name = "Bob", GPA = 3.67, Major = "English" });
            studentList.Add(new Student() { Name = "David", GPA = 3.44, Major = "Charms" });
            studentList.Add(new Student() { Name = "Jimbo", GPA = 3.98, Major = "History" });
            studentList.Add(new Student() { Name = "Zach", GPA = 3.45, Major = "Oceans" });
            studentList.Add(new Student() { Name = "Stan", GPA = 2.99, Major = "French" });
            studentList.Add(new Student() { Name = "Charlie", GPA = 3.21, Major = "Chinese" });
            studentList.Sort(); // IComparable made it happen.
            // studentList.Sort(new StudentComparerClass());   // IComparer Implemented for this class.
            Console.WriteLine("\nStudents in the Student List (ArrayList):\n");
            foreach (var student in studentList)
                Console.WriteLine(student);

            Course CSC440 = new Course();
            CSC440.CourseName = "Intermediate C#";
            CSC440.AddStudent(new Student() { Name = "Charlie", GPA = 3.21, Major = "Chinese" });
            CSC440.AddStudent(new Student() { Name = "Alice", GPA = 4.0, Major = "Math" });
            CSC440.AddStudent(new Student() { Name = "Bob", GPA = 3.67, Major = "English" });
            CSC440.AddStudent(new Student() { Name = "David", GPA = 3.44, Major = "Charms" });
            CSC440.AddStudent(new Student() { Name = "Jimbo", GPA = 3.98, Major = "History" });
            CSC440.AddStudent(new Student() { Name = "Zach", GPA = 3.45, Major = "Oceans" });
            CSC440.AddStudent(new Student() { Name = "Stan", GPA = 2.99, Major = "French" });
            Console.WriteLine("\nStudents in the CSC440 (Course):\n");
            // In order to iterate through CSC440 usig foreach, must implement IEnumerator for the class.
            foreach (var student in CSC440)
                Console.WriteLine(student);
            //foreach (var student in CSC440.GetEnumerator())
            //{

            //}

            Book myBook = new Book();
            myBook.Author = "Edgar";
            myBook.Genra = "Fiction";
            myBook.Title = "Raven";
            myBook.Page = 492;
            List<Book> bookList = new List<Book>();
            bookList.Add(myBook);
            bookList.Add(new Book() { Author = "Dan Brown", Title = "Lost Symbol", Genra = "Fiction", Page = 637});
            bookList.Add(new Book() { Author = "Perry", Title = "Aliens", Genra = "Fiction", Page = 569 });
            bookList.Add(new Book() { Author = "Hugo", Title = "Les Miserables", Genra = "Fiction", Page = 786 });
            Console.WriteLine("\nBooks in the book list (List<Book>):\n");
            foreach (var book in bookList)
                Console.WriteLine(book);

            Larry<int, Student> myLarry = new Larry<int, Student>();
            myLarry.MyType1Property = 2020;
            myLarry.MyType2Property = new Student() { Name = "Larry", GPA = 4.0, Major = "Chemistry" };
            myLarry.Print();
        }
        /* public void FancyMethod(Student st)
        {
            st.PrintMe();
        }
        public void FancyMethod(Instructor instructor)
        {
            instructor.PrintMe();
        }*/
        public static void MyFancyMethod(ISayHello myObj) // static for main to access it.
        {
            myObj.PrintMe();
        }
        public static void FancyMethod(IMyEmptyInterface obj) // Method can be used for all classes that implement the empty interface.
        {

        }
        public static T FindMin<T>(T num1, T num2) where T : IComparable
        {
            if (num1.CompareTo(num2) <= 0) return num1;
            else return num2;
        }
    }
    public class Larry<Type1, Type2>
    {
        public Type1 MyType1Property { get; set; }
        public Type2 MyType2Property { get; set; }
        public void Print()
        {
            Console.WriteLine(MyType1Property.ToString() + '\t' + MyType2Property);
        }
    }
    public class StudentComparerClass : IComparer // ICompare in >= 1 Way. & Not limited to class. IComparable --> 1 way.
    {
        public int Compare(object x, object y)
        {
            // return ((Student)x).Name.CompareTo(((Student)y).Name);
            Student studentX = (Student)x;
            Student studentY = (Student)y;
            return studentX.Name.CompareTo(studentY);
        }
    }
    interface IMyEmptyInterface // Interfaces define a set of characteristcis and behaviors.
    {
        // All interface members are public.(methods, properties, indexer, ) Signatures only with NO implementation details.
    }
    class CMyInterface
    {

    }
    class NewClass : CMyInterface, IMyEmptyInterface // class before interface inheritance.
    {

    }
    public interface ISayHello
    {
        void PrintMe();
    }
    public class Course: IEnumerable    // To Use the foreach in main.
    {
        List<Student> roster = new List<Student>();
        public string CourseName;
        
        public IEnumerator GetEnumerator()  // The only method (with the return type) in IEnumerable interface.
        {
            foreach (var st in roster)
                yield return st;
        }
        public IEnumerable Backwards()      // IEnumberable (has GetEnumerator method for foreach to work), not IEnumerator. 
        {
            for (int i = roster.Count - 1; i >= 0; i--)
                yield return roster[i];
        }
        public void AddStudent(Student st)
        {
            roster.Add(st);
        }
    }
    public class Student: ISayHello, IComparable
    {
        public string Name { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        public int CompareTo(object obj)
        {
            // return this.Name.CompareTo(((Student)obj).Name); // Instance Method
            return String.Compare(this.Name, ((Student)obj).Name); // Static method
            /*
            if (this.GPA < ((Student)obj).GPA) return -1;
            else if (this.GPA == ((Student)obj).GPA) return 0;
            else return 1;
            */
        }
        public override string ToString() // So the print in foreach can print the name instead of type.
        {
            return String.Format("Name: {0, -15}Major: {1, -15}GPA: {2}", Name, Major, GPA);
        }

        public void PrintMe() // public is needed to implement the ISayHello's method here
        {
            Console.WriteLine("Hello, this is student {0}", Name);
        }
    }
    public class Instructor: ISayHello
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public void PrintMe() // public is needed to implement the ISayHello's method here
        {
            Console.WriteLine("Hello, this is instructor {0}", Name);
        }
    }
    public class Book
    {
        public int Page { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genra { get; set; }
        public override string ToString()
        {
            return String.Format($"{Title, -20}{Author, -20}{Genra, -20}{Page}");
        }
    }
    public class MyList<T>: List<T> 
    {

    }
    public class MyList2: List<int> 
    {

    }

}
