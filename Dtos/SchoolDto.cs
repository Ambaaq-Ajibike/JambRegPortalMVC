using System;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Entities;
namespace JambRegistrationMVC.Dtos
{
    public class SchoolDto
    {
       public int Id{get; set;}
        public string Name{get; set;}
        public string Address{get; set; }
        public string CourseId{get; set; }
        public List<SchoolCourse> SchoolCourses{get; set;} = new List<SchoolCourse>();

    }
    public class SchoolResponseModel : BaseResponse
    {
       public SchoolDto Data{get; set;}
    }
    public class SchoolsResponseModel : BaseResponse
    {
        public IList<SchoolDto> Data{get; set;}
    }
    public class SchoolRequestModel
    {
        public string Name{get; set;}
        public string Address{get; set; }
        public List<int> CourseIds {get; set; } = new List<int>();
    }
}