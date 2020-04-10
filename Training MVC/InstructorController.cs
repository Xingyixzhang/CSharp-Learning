using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // To let the controller derive from the base Controller class.
using MSSA_Web_App.Services;

namespace MSSA_Web_App.Controllers
{
    public class InstructorController : Controller
    {
        private IMyAwesomeService MyService;    // Create an instance of the Service
        public InstructorController(IMyAwesomeService myService)    // Injection: Pass the service in to constructor.
        {
            MyService = myService;
        }
        public IActionResult Index()
        {
            MyService.FoodId = 1;
            MyService.FoodName = "Noodles";
            return View();
        }
    }
}