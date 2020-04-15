using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student st = new Student();
            //st.GPA = 4.0;
            //st.FirstName = "Alice";

            //Console.WriteLine("Hello World!");
            FourthCoffeeEntities myDBContext = new FourthCoffeeEntities();
            foreach(Employee item in myDBContext.Employees)
            {
                Console.WriteLine(item.FirstName);
                Console.WriteLine(item.LastName);
                Console.WriteLine(item.JobTitle);
                Console.WriteLine("====================");
                
            }

            foreach (var item in myDBContext.JobTitles)
            {
                Console.WriteLine(item.Job);
                Console.WriteLine(item.JobTitleId);
                Console.WriteLine("====================");
            }


            var employeeToChange = myDBContext.Employees.First(emp => emp.LastName == "Adams");
            if (employeeToChange != null)
            {
                employeeToChange.FirstName = "Xingyi";
                employeeToChange.LastName = "Zhang";
                myDBContext.SaveChanges();
            }

            //using linq            --->  //select * from JobTitles
            IQueryable<JobTitle> allJobRows = from jt in myDBContext.JobTitles 
                                                select jt;

            //using linq            --->  //select Job from JobTitles
            IQueryable<string> allJobTitles = from jt in myDBContext.JobTitles
                                                select jt.Job;

            //using linq            --->  //select JobTitleId from JobTitles
            IQueryable<int> allJobIDs = from jt in myDBContext.JobTitles
                                              select jt.JobTitleId;
            //display the  jobIDS:
            Console.WriteLine("job IDs found in the table");
            foreach(var jobId in allJobIDs)
                Console.WriteLine(jobId);


            //myDBContext.Employees.Add(new Employee() {FirstName="Alex", LastName="Logan", EmployeeID =2020  });
            //myDBContext.SaveChanges();

            IQueryable<Employee> myself = from emp in myDBContext.Employees
                                     where emp.FirstName=="Alex"
                                     select emp;
            Console.WriteLine("all employees with first name alex:");
            foreach(var emp in myself)
                Console.WriteLine(emp.FirstName + " " + emp.LastName);


            IQueryable<TwoColumns> selectSomeColumns = from emp in myDBContext.Employees
                                          select new TwoColumns() { DOB = emp.DateOfBirth, FirstName = emp.FirstName };
            foreach(var item in selectSomeColumns)
                Console.WriteLine(item.DOB + " " + item.FirstName);


            //anonymous type
            var selectSomeColumns2 = from emp in myDBContext.Employees
                                     select new { DOB3 = emp.DateOfBirth,  emp.FirstName };
            /////////////////////////////////////////////////////////
            foreach (var item in selectSomeColumns2)
                Console.WriteLine(item.DOB3 + " " + item.FirstName);


            int numberOfEmployees = (from emp in myDBContext.Employees
                                         select emp).Count();

        }
    }

    class TwoColumns
    {
        public DateTime? DOB{ get; set; }
        public String FirstName { get; set; }

    }
    public partial class Student
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
       
    }

    public partial class Student
    {
        
        public string Major { get; set; }
        public double GPA { get; set; }
    }


    public partial class Branch
    {
        public int MyNewProperty { get; set; }
    }

}
