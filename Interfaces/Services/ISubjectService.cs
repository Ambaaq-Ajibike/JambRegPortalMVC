using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Services
{
    public interface ISubjectService
    {
         SubjectResponseModel AddSubject(SubjectRequestModel Subject);
         SubjectResponseModel EditSubject(SubjectRequestModel Subject, int id);
         SubjectResponseModel GetSubject(int id);
         SubjectsResponseModel GetAllSubjects();
         bool DeleteSubject(int id);
    }
}