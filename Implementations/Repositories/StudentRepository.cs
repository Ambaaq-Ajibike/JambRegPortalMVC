using JambRegistrationMVC.Context;
using Microsoft.EntityFrameworkCore;
using System;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Interfaces.Repositories;
namespace JambRegistrationMVC.Implementations.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _context;
        public StudentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;            
        }
        public Student EditStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;            
        }
        public Student GetStudent(int id)
        {
            var student = _context.Students.Include(c => c.center).SingleOrDefault(s => s.Id == id);
            return student;
        }
        public IList<StudentDto> GetAllStudents()
        {
            var students = _context.Students.Select(s => new StudentDto
            {
                    Id = s.Id,
                    FullName = $"{s.FirstName} {s.LastName}",
                    Address = s.Address,
                    Email = s.Email,
                    Gender = s.Gender,
                    StudentImage = s.StudentImage,
                    ExaminationDate = s.ExaminationDate,
                   CenterName = s.center.Name,
                    CenterAddress = s.center.Address,
                    SchoolFirstChoice = s.SchoolFirstChoice,
                    SchoolSecondChoice = s.SchoolSecondChoice,
                    DateOfBirth = s.DateOfBirth        
            }).ToList();
            return students;
        }         
        public bool DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true; 
        }
         
    }
}