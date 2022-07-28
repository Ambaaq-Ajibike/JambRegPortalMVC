using System;
using System.Collections.Generic;
namespace JambRegistrationMVC.Entities
{
    public class Course
    {
        public int Id{get; set;}  
        public string Name{get; set;}
        public List<SchoolCourse> SchoolCourses{get; set;} = new List<SchoolCourse>();
    }
}