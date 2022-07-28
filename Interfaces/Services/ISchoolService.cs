using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Services
{
    public interface ISchoolService
    {
         SchoolResponseModel AddSchool(SchoolRequestModel School);
         SchoolResponseModel EditSchool(SchoolRequestModel School, int id);
         SchoolResponseModel GetSchool(int id);
         SchoolsResponseModel GetAllSchools();
         bool DeleteSchool(int id);
        bool DeleteCourseFromSchool(int schoolcourseid);
        CoursesResponseModel GetCoursesBySchoolId(int schoolid);
        bool AddNewCourseToSchool(SchoolRequestModel schoolrequest, int id);
    }
}