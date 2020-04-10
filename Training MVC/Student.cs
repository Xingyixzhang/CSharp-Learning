using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSSA_Web_App.Models
{
    public class Student
    {
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "Student's First Name Required.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Major:")]
        [Required]
        public string Major { get; set; }
        [Display(Name = "GPA:")]
        public double GPA { get; set; }
        public Student(string firstName, string lastName, string major, double gpa)
        {
            FirstName = firstName;
            LastName = lastName;
            Major = major;
            GPA = gpa;
        }
    }
}
