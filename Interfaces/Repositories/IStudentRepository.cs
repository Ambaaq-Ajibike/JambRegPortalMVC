using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Repositories
{
    public interface IStudentRepository
    {
         Student AddStudent(Student student);
         Student EditStudent(Student student);
         Student GetStudent(int id);
         IList<StudentDto> GetAllStudents();
         bool DeleteStudent(int id);
    }
}