using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Repositories
{
    public interface ISchoolCourseRepository
    {
         SchoolCourse AddSchoolCourse(SchoolCourse SchoolCourse);
        SchoolCourse GetSchoolCourse(int id);
         bool DeleteCourseFromSchool(SchoolCourse schoolCourse);
        bool CheckSchoolCourse(int schoolid, int coursesid); 
    }
}