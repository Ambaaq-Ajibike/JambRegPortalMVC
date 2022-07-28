using JambRegistrationMVC.Context;
using System;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Interfaces.Repositories;
namespace JambRegistrationMVC.Implementations.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationContext _context;
        public SubjectRepository(ApplicationContext context)
        {
            _context = context;
        }  
        public Subject CreateSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return subject;            
        }
        public Subject UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
            return subject;            
        }
        public Subject GetSubject(int id)
        {
            var subject = _context.Subjects.Find(id);
            return subject;
        }
        public  IList<SubjectDto> GetAllSubjects()
        {
            var subject = _context.Subjects.Select(a => new SubjectDto
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
            return subject;
        }         
        public bool DeleteSubject(int id)
        {
            var subject = _context.Subjects.Find(id);
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return true; 
        }
        public IList<Subject> GetSubjectByIds(List<int> subjectid)
        {
            var subject = _context.Subjects.Where(c => subjectid.Contains(c.Id)).ToList();
            return subject;
        }
    }
}