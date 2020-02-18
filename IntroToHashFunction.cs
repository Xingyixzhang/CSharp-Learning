using System;
using System.Collections.Generic;

namespace Hash
{
    public class Student
    {
        int grade;
        int cls;
        string firstName, lastName;

        public Student(int grade, int cls, string first, string last)
        {
            this.grade = grade;
            this.cls = cls;
            this.firstName = first;
            this.lastName = last;
        }

        public override int GetHashCode()
        {
            int B = 31;         // random number, primes better.
            int hash = 0;
            hash = hash * B + grade;
            hash = hash * B + cls;
            hash = hash * B + firstName.ToLower().GetHashCode();
            hash = hash * B + lastName.GetHashCode();
            return hash;
        }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (o == null) return false;
            Student another = (Student)o;
            return this.grade == another.grade &&
                this.cls == another.cls &&
                this.firstName.ToLower().Equals(another.firstName.ToLower()) &&
                this.lastName.ToLower().Equals(another.lastName.ToLower());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 42, b = -42;
            double c = 3.1415926;
            string d = "imooc";
            Console.WriteLine(a.GetHashCode()); // 42
            Console.WriteLine(b.GetHashCode()); // -42
            Console.WriteLine(c.GetHashCode()); // 219937201
            // string "imooc" changes value of its hashcode everytime you run the app.
            Console.WriteLine(d.GetHashCode());

            Student student = new Student( 3, 2, "bobo", "Zhang" );
            Console.WriteLine(student.GetHashCode());

            HashSet<Student> set = new HashSet<Student>();  // HashSet<T> needs System.Collections.Generic;
            set.Add(student);

            // C# uses dictionary not hashmap. Java uses HashMap.
            Dictionary<Student, int> scores = new Dictionary<Student, int>();
            scores.Add(student, 100);

            Student student2 = new Student(3, 2, "Xingyi", "Zhang");
            Console.WriteLine(student2.GetHashCode());
        }
    }
}
