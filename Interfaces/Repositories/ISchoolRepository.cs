using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Repositories
{
    public interface ISchoolRepository
    {
         School CreateSchool(School school);
         School UpdateSchool(School school);
         School GetSchool(int id);
         IList<SchoolDto> GetAllSchools();
         bool DeleteSchool(int id);
         IList<CourseDto> GetCoursesBySchoolId(int schoolid);
          List<School> GetSchoolByIds(List<int> schoolid);        
        // public SchoolCourse AddSchoolCourse(SchoolCourse schoolCourse);
    }
}