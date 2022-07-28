using System;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Entities
{
    public class Center
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Address  {get; set;}
        public int Capacity{get; set;}
        List<Student> students{get; set;} = new List<Student>();
    }
}