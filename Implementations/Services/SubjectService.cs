using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Interfaces.Repositories;
using JambRegistrationMVC.Implementations.Repositories;
using JambRegistrationMVC.Interfaces.Services;
namespace JambRegistrationMVC.Implementations.Services
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _subjectRepo;
        public SubjectService(ISubjectRepository subjectRepo)
        {
            _subjectRepo = subjectRepo;
        }
        public  SubjectResponseModel AddSubject(SubjectRequestModel subject)
        {
            if (CheckSubject(subject.Name) == false)
            {
                var addSubject = new Subject
                {
                    Name = subject.Name,
                };
                var addSubjectToDb = _subjectRepo.CreateSubject(addSubject);
                if (addSubjectToDb != null)
                {
                    var subjectDto = new SubjectDto
                    {
                        Id = addSubjectToDb.Id,
                        Name = addSubjectToDb.Name
                    };
                    return new  SubjectResponseModel
                    {
                        Status = true,
                        Message = "Subject Successfully added",
                        Data = subjectDto
                    };
                }
            }            
            return new  SubjectResponseModel
            {
                Status = false,
                Message = "Subject with these name already exist"
            };
            
        }
        public SubjectResponseModel EditSubject(SubjectRequestModel subjectrequest, int id)
         {
             var checkId = _subjectRepo.GetSubject(id);
             if (checkId != null)
             {
                    checkId.Name = subjectrequest.Name;      
                 _subjectRepo.UpdateSubject(checkId);
                 var subjectDto = new SubjectDto
                 {
                     Id = checkId.Id,
                     Name = checkId.Name
                 };
                 return new SubjectResponseModel
                 {
                     Data = subjectDto,
                     Status = true,
                     Message = "Successfully updated"
                 };
             }
             return new SubjectResponseModel
             {
                 Status = false,
                 Message = "Not Successful"
             };
        }
        public SubjectResponseModel GetSubject(int id)
        {
            var checkId = _subjectRepo.GetSubject(id);
            if(checkId != null)
            {
                 var subjectDto = new SubjectDto
                {
                    Id = checkId.Id,
                    Name = checkId.Name
                };
                return new SubjectResponseModel
                {
                    Data = subjectDto,
                    Status = true,
                    Message = "Successfully updated"
                };
            }
            return new SubjectResponseModel
            {
                Status = false,
                Message = "Not Successful"
            };
        }
        public  SubjectsResponseModel GetAllSubjects()
        {
            var allSubjects = _subjectRepo.GetAllSubjects();
            return new SubjectsResponseModel
            {
                Data = allSubjects,
                Status = true,
                Message = "These are list of Subjects"
            };
        }
        public bool DeleteSubject(int id)
        {
            var checkId = _subjectRepo.GetSubject(id);
            _subjectRepo.DeleteSubject(id);
            return true;
        }
        public bool CheckSubject(string name)
        {
             var allSubjects = _subjectRepo.GetAllSubjects();
             foreach (var subject in allSubjects)
             {
                if(name == subject.Name)
                {
                    return true;
                }
               
             }
              return false;
        }
    }
}