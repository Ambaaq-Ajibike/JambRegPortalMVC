 using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Services
{
    public interface IStudentService
    {
         StudentResponseModel AddStudent(StudentRequestModel Student);
        // StudentResponseModel EditStudent(StudentRequestModel Student, int id);
         StudentResponseModel GetStudent(int id);
         StudentsResponseModel GetAllStudents();
         bool DeleteStudent(int id);
    }
}