using System;
using System.IO;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Interfaces.Repositories;
using JambRegistrationMVC.Implementations.Repositories;
using JambRegistrationMVC.Interfaces.Services;
namespace JambRegistrationMVC.Implementations.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly ISchoolCourseRepository _schoolCourseRepo;
        private readonly IWebHostEnvironment webpost;
        private ISubjectRepository _subjectRepo;
        private ISchoolRepository _schoolRepo;
        private ICourseRepository _courseRepo;
        private ICenterRepository _centerRepo;
        public StudentService(IStudentRepository studentRepo, IWebHostEnvironment _webpost, ICenterRepository centerRepo, ISubjectRepository subjectRepo, ICourseRepository courseRepo, ISchoolRepository schoolRepo, ISchoolCourseRepository schoolCourseRepo)
        {
             webpost = _webpost;
            _studentRepo = studentRepo;
            _centerRepo = centerRepo;
            _subjectRepo = subjectRepo;
            _courseRepo = courseRepo;
            _schoolRepo = schoolRepo;
            _schoolCourseRepo = schoolCourseRepo;
        }
        public StudentResponseModel AddStudent(StudentRequestModel student)
        {
            
           var ImageName = "";
           if (student.StudentImage != null)
           {
               var path = webpost.WebRootPath;
               var imagepath = Path.Combine(path, "Images");
               Directory.CreateDirectory(imagepath);
               var imagetype = student.StudentImage.ContentType.Split('/')[1];
               if(imagetype != "png" && imagetype != "jpg" && imagetype != "jpeg")
               {
                   return new StudentResponseModel
                   {
                       Message = "Fail to create student because file type is not image",
                       Status = false
                   };
               }
               ImageName = $"{Guid.NewGuid()}.{imagetype}";
               var fullpath = Path.Combine(imagepath, ImageName);
               using (var stream = new FileStream(fullpath, FileMode.Create))
               {
                    student.StudentImage.CopyTo(stream);
               }
           }
           var centerId = GenerateCenter(student.CenterIds);
           var schools = _schoolRepo.GetSchoolByIds(student.SchoolIds);
           var center = _centerRepo.GetCenter(centerId);
           var courses = _courseRepo.GetCoursesByIds(student.CourseIds);
        //    if(_schoolCourseRepo.CheckSchoolCourse(student.SchoolIds, student.CenterIds) == true)
        //    {
                var addstudent = new Student
               {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Address = student.Address,
                    Email = student.Email,
                    PassWord = student.Password,
                    Gender = student.Gender,
                    StudentImage = ImageName,
                    ExaminationDate = GenerateExaminationDate(),
                    CenterID = centerId,
                    SchoolFirstChoice = schools[0].Name,
                    CourseFirstChoice = courses[0].Name,
                    SchoolSecondChoice = schools[1].Name,
                    CourseSecondChoice = courses[1].Name,
                    DateOfBirth = student.DateOfBirth,
               };
               var subjects = _subjectRepo.GetSubjectByIds(student.SubjectIds);
               foreach (var sub in subjects)
               {
                   var studentSubject = new StudentSubject
                   {
                        StudentID = addstudent.Id,
                        SubjectID = sub.Id
                   };
                   addstudent.studentsubject.Add(studentSubject);        
               }
               var addstudentToDB = _studentRepo.AddStudent(addstudent);               
                return new StudentResponseModel
                {
                    Data = new StudentDto
                    {
                        Id = addstudentToDB.Id,
                        FullName = $"{addstudentToDB.FirstName} {addstudentToDB.LastName}",
                        Address = addstudentToDB.Address,
                        Email = addstudentToDB.Email,
                        Gender = addstudentToDB.Gender,
                        StudentImage = addstudentToDB.StudentImage,
                        ExaminationDate = addstudentToDB.ExaminationDate,
                        CenterName = center.Name,
                        CenterAddress = center.Address,
                        SchoolFirstChoice = addstudentToDB.SchoolFirstChoice,
                        SchoolSecondChoice = addstudentToDB.SchoolSecondChoice,
                        DateOfBirth = addstudentToDB.DateOfBirth        
                    },
                    Status = true,
                    Message = $"Your examinationdate is {addstudentToDB.ExaminationDate} and Your center is {center.Name} Located at {center.Address}"
                };
            
        }   
        public int GenerateCenter(List<int> c)
        {
            Random rnd = new Random();
            var d = rnd.Next(0, c.Count - 1);
            var a = c[d];           
           return a;
        }
        public string GenerateExaminationDate()
        {
            var d = DateTime.Now.Date;
            var e = d.AddDays(30);
            var f = e.AddDays(14);
            List<string> examdate = new List<string>();
            for (DateTime i = e; i.Date <= f; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Sunday)
                {
                    string a = (i.Date).ToString();
                    examdate.Add(a);             
                }
                else
                {
                    continue;
                }
            }
            Random rnd = new Random();
            var r = rnd.Next(0, examdate.Count - 1); 
            return examdate[r];
        }
         public StudentResponseModel GetStudent(int id)
        {
            var addstudentToDB = _studentRepo.GetStudent(id);
            if(addstudentToDB != null)
            {
                 var StudentDto = new StudentDto
                {
                        Id = addstudentToDB.Id,
                        FullName = $"{addstudentToDB.FirstName} {addstudentToDB.LastName}",
                        Address = addstudentToDB.Address,
                        Email = addstudentToDB.Email,
                        Gender = addstudentToDB.Gender,
                        StudentImage = addstudentToDB.StudentImage,
                        ExaminationDate = addstudentToDB.ExaminationDate,
                        CenterName = addstudentToDB.center.Name,
                        CenterAddress = addstudentToDB.center.Address,
                        SchoolFirstChoice = addstudentToDB.SchoolFirstChoice,
                        CourseFirstChoice = addstudentToDB.CourseFirstChoice,
                        CourseSecondChoice = addstudentToDB.CourseSecondChoice,
                        SchoolSecondChoice = addstudentToDB.SchoolSecondChoice,
                        DateOfBirth = addstudentToDB.DateOfBirth        
                };
                return new StudentResponseModel
                {
                    Data = StudentDto,
                    Status = true,
                    Message = "Successfully updated"
                };
            }
            return new StudentResponseModel
            {
                Status = false,
                Message = "Not Successful"
            };
        }
        public  StudentsResponseModel GetAllStudents()
        {
            var allStudents = _studentRepo.GetAllStudents();
                
            return new StudentsResponseModel
            {
                Data = allStudents,
                Status = true,
                Message = "These are list of Schools"
            };
        }
        public bool DeleteStudent(int id)
        {
            var checkId = _studentRepo.GetStudent(id);
            _studentRepo.DeleteStudent(id);
            return true;
        }
    }
}
         
         