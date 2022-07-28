using System;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Entities;
namespace JambRegistrationMVC.Dtos
{
    public class SubjectDto
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public List<StudentSubject> StudentSubjects{get; set;} = new List<StudentSubject>();

    }
    public class SubjectResponseModel : BaseResponse
    {
       public SubjectDto Data{get; set;}
    }
    public class SubjectsResponseModel : BaseResponse
    {
        public IList<SubjectDto> Data{get; set;}
    }
    public class SubjectRequestModel
    {
        public string Name{get; set;}
    }
}