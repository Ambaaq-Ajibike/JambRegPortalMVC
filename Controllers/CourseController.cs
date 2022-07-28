using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JambRegistrationMVC.Models;
using JambRegistrationMVC.Dtos;
using JambRegistrationMVC.Interfaces.Services;
namespace JambRegistrationMVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ISchoolService _schoolService;

        public CourseController(ICourseService courseService, ISchoolService schoolService)
        {
            _courseService = courseService;
            _schoolService = schoolService;
        }
        public IActionResult Index()
        {
            var courses = _courseService.GetAllCourses();
            return View(courses.Data);
        }
        public IActionResult CreateCourse()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(CourseRequestModel course)
        {
            var createCourse = _courseService.AddCourse(course);
            if(createCourse == null)
            {
                return RedirectToAction("Course with this name already exist");
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCourse(int id)
        {
            var Course = _courseService.GetCourse(id);
            return View(Course);
        }
        [HttpPost]
        public IActionResult UpdateCourse(CourseRequestModel course, int id)
        {
            _courseService.EditCourse(course, id);
            return RedirectToAction("Index");
        }
        public IActionResult GetCourse(int id)
        {
            var Course = _courseService.GetCourse(id);
            return View(Course);
        }
        public IActionResult Delete(int id)
        {
            var course = _courseService.GetCourse(id);
            return View(course);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction("Index");
        }        
        public IActionResult GetSchoolsByCourseId(int courseid)
       {
            var school = _courseService.GetSchoolsByCourseId(courseid);
           if(school == null)
           {
               return NotFound($"School with id {courseid} does not exist");
           }
           return View(school.Data);
       }
      
    }
    
}
       
         