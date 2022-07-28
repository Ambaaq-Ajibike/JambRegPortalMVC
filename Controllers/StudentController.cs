using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using JambRegistrationMVC.Models;
using JambRegistrationMVC.Dtos;
using JambRegistrationMVC.Interfaces.Services;
namespace JambRegistrationMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly ICenterService _centerService;
        private readonly ISchoolService _schoolService;
        private readonly ICourseService _courseService;
        public StudentController(IStudentService studentService, ICourseService courseService, ISchoolService schoolService, ISubjectService subjectService, ICenterService studentCenter)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _centerService = studentCenter;
            _schoolService = schoolService;            
            _courseService = courseService;            
        }
        public IActionResult Index()
        {
            var Students = _studentService.GetAllStudents();
            return View(Students.Data);
        }
        public IActionResult CreateStudent()
        {            
             var subject = _subjectService.GetAllSubjects();
            ViewData["Subjects"] = new SelectList(subject.Data, "Id", "Name");
             var center = _centerService.GetAllCenters();
            ViewData["Centers"] = new SelectList(center.Data, "Id", "Name");
             var schools = _schoolService.GetAllSchools();
            ViewData["Schools"] = new SelectList(schools.Data, "Id", "Name");            
             var courses = _courseService.GetAllCourses();
            ViewData["Courses"] = new SelectList(courses.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentRequestModel Student)
        {
            var createStudent = _studentService.AddStudent(Student);            
            return RedirectToAction("UserLogin", "Login");
        }
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudent(id);
            return View(student);
        }
        // public IActionResult UpdateStudent(int id)
        // {
        //     var Student = _StudentService.GetStudent(id);
        //     return View(Student);
        // }
        // [HttpPost]
        // public IActionResult UpdateStudent(StudentRequestModel Student, int id)
        // {
        //     _StudentService.EditStudent(Student, id);
        //     return RedirectToAction("Index");
        // }
        // public IActionResult GetStudent(int id)
        // {
        //     var Student = _StudentService.GetStudent(id);
        //     return View(Student);
        // }
        public IActionResult Delete(int id)
        {
            var Student = _studentService.GetStudent(id);
            return View(Student);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
    
}