using System;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Contract;
using JambRegistrationMVC.Identity;
using JambRegistrationMVC.Entities;
namespace JambRegistrationMVC.Entities
{
    public class Student : AuditableEntity
    {
        public int Id{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Address{get; set;}
        public string Email{get; set;}
        public string PassWord{get; set;}
        public Gender Gender{get; set;}
        public string ExaminationDate{get; set;}
        public string StudentImage{get; set;}
        public int CenterID{get; set;}
        public Center center{get; set;}
        public string CourseFirstChoice{get; set;}
        public string CourseSecondChoice{get; set;}
        public string SchoolFirstChoice{get; set;}
        public string SchoolSecondChoice{get; set;}
        public DateTime DateOfBirth{get; set;} 
        public int UserId{get; set;}
        public User User{get; set;}
        public List<StudentSubject> studentsubject{get; set;} = new List<StudentSubject>();
    }
}