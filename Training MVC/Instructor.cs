using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSA_Web_App.Models
{
    public class Instructor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public int NumberofClasses { get; set; }
        public bool IsTenured { get; set; }
    }
}
