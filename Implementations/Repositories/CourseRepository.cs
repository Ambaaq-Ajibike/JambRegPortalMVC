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
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationContext _context;
        public CourseRepository(ApplicationContext context)
        {
            _context = context;
        }  
        public Course CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;            
        }
        public Course UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return course;            
        }
        public Course GetCourse(int id)
        {
            var course = _context.Courses.Find(id);
            return course;
        }
        public  IList<CourseDto> GetAllCourses()
        {
            var course = _context.Courses.Select(a => new CourseDto
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
            return course;
        }         
        public bool DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return true; 
        }
        public List<Course> GetCoursesByIds(List<int> courseid)
        {
            var course = _context.Courses.Where(c => courseid.Contains(c.Id)).ToList();
            return course;
        }
        public List<SchoolDto> GetSchoolsByCourseId(int courseid)
        {
            var schoolcourse = _context.SchoolCourses.Include(s => s.School).Where(a => a.CourseId == courseid).Select(s => new SchoolDto
            {
                Id = s.SchoolId,
                Name = s.School.Name
            }).ToList();
            return schoolcourse; 
        }
          
        
    }
}