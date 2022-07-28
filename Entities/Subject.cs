using System;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Entities
{
    public class Subject
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public List<StudentSubject> studentsubject{get; set;} = new List<StudentSubject>();
    }
}