using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Repositories
{
    public interface ISubjectRepository
    {
         Subject CreateSubject(Subject subject);
         Subject UpdateSubject(Subject subject);
         Subject GetSubject(int id);
         IList<SubjectDto> GetAllSubjects();
         bool DeleteSubject(int id);
         IList<Subject> GetSubjectByIds(List<int> subjectid);
    }
}