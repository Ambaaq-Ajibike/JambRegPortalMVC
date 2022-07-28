using System;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Entities
{
    public class School
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Address{get; set; }
        public List<SchoolCourse> SchoolCourses{get; set;} = new List<SchoolCourse>();
    }
}