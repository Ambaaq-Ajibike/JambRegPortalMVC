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
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        public IActionResult Index()
        {
            var subjects = _subjectService.GetAllSubjects();
            return View(subjects.Data);
        }
        public IActionResult CreateSubject()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult CreateSubject(SubjectRequestModel subject)
        {
            var createSubject = _subjectService.AddSubject(subject);
            if(!createSubject.Status)
            {
                ViewBag.Message = createSubject.Message;
                return View();                 
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateSubject(int id)
        {
            var subject = _subjectService.GetSubject(id);
            return View(subject);
        }
        [HttpPost]
        public IActionResult UpdateSubject(SubjectRequestModel subject, int id)
        {
            _subjectService.EditSubject(subject, id);
            return RedirectToAction("Index");
        }
        public IActionResult GetSubject(int id)
        {
            var Subject = _subjectService.GetSubject(id);
            return View(Subject);
        }
        public IActionResult Delete(int id)
        {
            var subject = _subjectService.GetSubject(id);
            return View(subject);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteSubject(int id)
        {
            _subjectService.DeleteSubject(id);
            return RedirectToAction("Index");
        }
    }
    
}
       
         