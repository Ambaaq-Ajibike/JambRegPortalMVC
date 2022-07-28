using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Repositories
{
    public interface ICourseRepository
    {
         Course CreateCourse(Course course);
         Course UpdateCourse(Course course);
         Course GetCourse(int id);
         IList<CourseDto> GetAllCourses();
         bool DeleteCourse(int id);
         List<Course> GetCoursesByIds(List<int> courseid);
        List<SchoolDto> GetSchoolsByCourseId(int courselid);
    }
}