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
    public class SchoolRepository : ISchoolRepository
    {
        private readonly ApplicationContext _context;
        public SchoolRepository(ApplicationContext context)
        {
            _context = context;
        }  
        public School CreateSchool(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
            return school;            
        }
        public School UpdateSchool(School school)
        {
            _context.Schools.Update(school);
            _context.SaveChanges();
            return school;            
        }
        public School GetSchool(int id)
        {
            var school = _context.Schools.Find(id);
            return school;
        }
        public  IList<SchoolDto> GetAllSchools()
        {
            var school = _context.Schools.Select(c => new SchoolDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
            }).ToList();
            return school;
        }         
        public bool DeleteSchool(int id)
        {
            var school = _context.Schools.Find(id);
            _context.Schools.Remove(school);
            _context.SaveChanges();
            return true; 
        }
        public  IList<CourseDto> GetCoursesBySchoolId(int schoolid)
        {
            var schoolcourse = _context.SchoolCourses.Include(s => s.Course).Where(a => a.SchoolId == schoolid).Select(s => new CourseDto
            {                
                Id = s.Id,
                Name = s.Course.Name
            }).ToList();
            return schoolcourse;        
        }
        public List<School> GetSchoolByIds(List<int> schoolid)
        {
            var course = _context.Schools.Where(c => schoolid.Contains(c.Id)).ToList();
            return course;
        }
    }
}