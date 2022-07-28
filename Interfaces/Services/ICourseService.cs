using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Services
{
    public interface ICourseService
    {
         CourseResponseModel AddCourse(CourseRequestModel course);
         CourseResponseModel EditCourse(CourseRequestModel course, int id);
         CourseResponseModel GetCourse(int id);
         CoursesResponseModel GetAllCourses();
         bool DeleteCourse(int id);
         SchoolsResponseModel GetSchoolsByCourseId(int courselid);
    }
}