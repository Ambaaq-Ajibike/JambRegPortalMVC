using System;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Entities;
using Microsoft.AspNetCore.Http;
namespace JambRegistrationMVC.Dtos
{
    public class StudentDto
    {
        public int Id{get; set;}
        public string FullName{get; set;}
        public string Address{get; set;}
        public string StudentImage{get; set;}
        public string Email{get; set;}
        public Gender Gender{get; set;}
        public string ExaminationDate{get; set;}
        public string CenterName{get; set;}
        public string CenterAddress{get; set;}
         public string SchoolFirstChoice{get; set;}
        public string CourseFirstChoice{get; set;}
        public string SchoolSecondChoice{get; set;}
        public string CourseSecondChoice{get; set;}        
        public DateTime DateOfBirth{get; set;} 
        public List<StudentSubject> studentsubject{get; set;} = new List<StudentSubject>();
    }
    public class StudentResponseModel : BaseResponse
    {
        public StudentDto Data {get; set;}
    }
    public class StudentsResponseModel :BaseResponse
    {
        public IList<StudentDto> Data = new List<StudentDto>();
    }
    public class StudentRequestModel
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Address{get; set;}
        public IFormFile StudentImage{get; set;}
        public string Email{get; set;}
        public Gender Gender{get; set;}
        public string Password{get; set;}
        public DateTime DateOfBirth{get; set;} 
        public List<int> CenterIds {get; set; } = new List<int>();
        public List<int> CourseIds {get; set; } = new List<int>();
        public List<int> SubjectIds {get; set; } = new List<int>();
        public List<int> SchoolIds {get; set; } = new List<int>();
    }
}