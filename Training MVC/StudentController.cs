using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MSSA_Web_App.Models;
using MSSA_Web_App.Services;

namespace MSSA_Web_App.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplaySchoolYear(int id)  // id needs to match the name in routing.
        {
            // return View("View", id); // Then the view has to expect the int.
            ViewBag.year = id;
            ViewData["year"] = id;
            return View("Index");
        }

        [Route("MSSAAddStudent")]
        [HttpGet]   // Can only be called via a post request. In this case, only called after submit button.
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveStudent(Student st)
        {
            if (!ModelState.IsValid) {
                return View("AddStudent", st);
            }
            else
            {
                // Save Student st to a file if valid.
                return View(st);
            }
        }
    }
}