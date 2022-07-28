using JambRegistrationMVC.Context;
using System;
using Microsoft.EntityFrameworkCore;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Interfaces.Repositories;
namespace JambRegistrationMVC.Implementations.Repositories
{
    public class SchoolCourseRepository : ISchoolCourseRepository
    {
        private readonly ApplicationContext _context;
        public SchoolCourseRepository(ApplicationContext context)
        {
            _context = context;
        }         
        public bool DeleteCourseFromSchool(SchoolCourse schoolCourse)
        {
             _context.SchoolCourses.Remove(schoolCourse);
            _context.SaveChanges();
            return true; 
        }
        public SchoolCourse AddSchoolCourse(SchoolCourse schoolCourse)
        {
             _context.SchoolCourses.Add(schoolCourse);
            _context.SaveChanges();
            return schoolCourse; 
        }
        public SchoolCourse GetSchoolCourse(int schoolcourseid)
        {
            var schoolCourse = _context.SchoolCourses.Find(schoolcourseid);
            return schoolCourse;
        }
        public bool CheckSchoolCourse(int schoolid, int coursesid)
        {
            
                var schoolCourse = _context.SchoolCourses.Where(s => s.SchoolId == schoolid && s.CourseId == coursesid);
                if (schoolCourse.Count() == 0)
                {
                    return true;
                }                
            
            return false;            
        }
    }
}