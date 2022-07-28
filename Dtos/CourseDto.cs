using System;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Entities;
namespace JambRegistrationMVC.Dtos
{
    public class CourseDto
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public List<SchoolCourse> SchoolCourses{get; set;} = new List<SchoolCourse>();

    }
    public class CourseResponseModel : BaseResponse
    {
       public CourseDto Data{get; set;}
    }
    public class CoursesResponseModel : BaseResponse
    {
        public IList<CourseDto> Data{get; set;}
    }
    public class CourseRequestModel
    {
        public string Name{get; set;}
    }
}