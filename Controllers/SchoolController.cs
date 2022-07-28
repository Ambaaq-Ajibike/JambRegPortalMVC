using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JambRegistrationMVC.Models;
using JambRegistrationMVC.Dtos;
using JambRegistrationMVC.Interfaces.Services;
namespace JambRegistrationMVC.Controllers
{
    public class SchoolController : Controller
    {
        ICourseService _courseService;
        ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService, ICourseService courseService)
        {
            _schoolService = schoolService;
            _courseService = courseService;
        }
         public IActionResult Index()
        {
            var schools = _schoolService.GetAllSchools();
            return View(schools.Data);
        }
        public IActionResult CreateSchool()
        {            
             var course = _courseService.GetAllCourses();
            ViewData["Courses"] = new SelectList(course.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateSchool(SchoolRequestModel school)
        {
            var createSchool = _schoolService.AddSchool(school);
            if(createSchool == null)
            {
                return RedirectToAction("School with this name and address already exist");
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateSchool(int id)
        {     
            
            var school = _schoolService.GetSchool(id);
            return View(school);
        }
        [HttpPost]
        public IActionResult UpdateSchool(SchoolRequestModel school, int id)
        {
           var updateschool =  _schoolService.EditSchool(school, id);
            if (!updateschool.Status)
            {
                ViewBag.Message = updateschool.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetSchool(int id)
        {
            var school = _schoolService.GetSchool(id);
            return View(school);
        }
        public IActionResult Delete(int id)
        {
            var school = _schoolService.GetSchool(id);
            return View(school);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteSchool(int id)
        {
            _schoolService.DeleteSchool(id);
            return RedirectToAction("Index");
        }
        public IActionResult GetCoursesBySchoolId(int schoolid)
       {
           ViewBag.Id = schoolid;
            var school = _schoolService.GetCoursesBySchoolId(schoolid);
           if(school == null)
           {
               return NotFound($"School with id {schoolid} does not exist");
           }
           return View(school.Data);
       }
       public IActionResult DeleteCourseFromSchool(int schoolCourseid)
       {
           var delete = _schoolService.DeleteCourseFromSchool(schoolCourseid);
           return RedirectToAction("Index");
       }
       public IActionResult AddNewCourseToSchool()
       {
            var course = _courseService.GetAllCourses();
            ViewData["Courses"] = new SelectList(course.Data, "Id", "Name");
            return View();
       }
       [HttpPost]
        public IActionResult AddNewCourseToSchool(SchoolRequestModel schoolrequest, int id)
        {
            var createSchool = _schoolService.AddNewCourseToSchool(schoolrequest, id);
            return RedirectToAction("Index");
        }
    }
}