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
    public class SchoolService : ISchoolService
    {
        private ISchoolRepository _schoolRepo;
        private ICourseRepository _courseRepo;
        private ISchoolCourseRepository _schoolcourseRepo;
        public SchoolService(ISchoolRepository schoolRepo, ICourseRepository courseRepo, ISchoolCourseRepository schoolcourseRepo)
        {
            _schoolRepo = schoolRepo;
            _courseRepo = courseRepo;
            _schoolcourseRepo = schoolcourseRepo;
        }
        public  SchoolResponseModel AddSchool(SchoolRequestModel school)
        {
            if (CheckSchool(school.Name, school.Address) == false)
            {
                var addSchool = new School
                {
                    Name = school.Name,
                    Address = school.Address,
                };
                var courses = _courseRepo.GetCoursesByIds(school.CourseIds);
               foreach (var course in courses)
               {
                   var schoolCourse = new SchoolCourse
                   {
                        SchoolId = addSchool.Id,
                        CourseId = course.Id,
                   };
                    addSchool.SchoolCourses.Add(schoolCourse);
               }

                var addSchoolToDb = _schoolRepo.CreateSchool(addSchool);
                if (addSchoolToDb != null)
                {
                    var SchoolDto = new SchoolDto
                    {
                        Id = addSchoolToDb.Id,
                        Name = addSchoolToDb.Name,
                        Address = addSchoolToDb.Address,
                    };
                    return new  SchoolResponseModel
                    {
                        Status = true,
                        Message = "School Successfully added",
                        Data = SchoolDto
                    };
                }
            }            
            return new  SchoolResponseModel
            {
                Status = true,
                Message = "School with these and address name already exist"
            };
            
        }
        public bool CheckSchool(string name, string address)
        {
             var allSchools = _schoolRepo.GetAllSchools();
             foreach (var school in allSchools)
             {
                if(name == school.Name && address == school.Address)
                {
                    return true;
                }
               
             }
              return false;
        }
        public SchoolResponseModel EditSchool(SchoolRequestModel schoolrequest, int id)
         {                 
              var checkId = _schoolRepo.GetSchool(id);
              if (checkId != null)
              {                                                     
                    checkId.Name = schoolrequest.Name;
                    checkId.Address = schoolrequest.Address;
                    var courses = _courseRepo.GetCoursesByIds(schoolrequest.CourseIds);
                    _schoolRepo.UpdateSchool(checkId);
                                                
                    return new SchoolResponseModel
                    {
                        Data =new SchoolDto
                        {
                            Id = checkId.Id,
                            Name = checkId.Name,
                            Address = checkId.Address,
                        },
                        Status = true,
                        Message = "Successfully updated"
                    };
              } 
             
             return new SchoolResponseModel
             {
                 Status = false,
                 Message = "Not Successful"
             };
        }
        public SchoolResponseModel GetSchool(int id)
        {
            var checkId = _schoolRepo.GetSchool(id);
            if(checkId != null)
            {
                 var schoolDto = new SchoolDto
                 {
                     Id = checkId.Id,
                     Name = checkId.Name,
                     Address = checkId.Address,
                 };
                 return new SchoolResponseModel
                 {
                     Data = schoolDto,
                     Status = true,
                     Message = "Successfully updated"
                 };
            }
            return new SchoolResponseModel
            {
                Status = false,
                Message = "Not Successful"
            };
        }
        public  SchoolsResponseModel GetAllSchools()
        {
            var allSchools = _schoolRepo.GetAllSchools();
            return new SchoolsResponseModel
            {
                Data = allSchools,
                Status = true,
                Message = "These are list of Schools"
            };
        }
        public bool DeleteSchool(int id)
        {
            var checkId = _schoolRepo.GetSchool(id);
            _schoolRepo.DeleteSchool(id);
            return true;
        }
        public  CoursesResponseModel GetCoursesBySchoolId(int schoolid)
        {
            var getschool = _schoolRepo.GetSchool(schoolid);
            if (getschool != null)
            {
                var course = _schoolRepo.GetCoursesBySchoolId(schoolid);
                 return new CoursesResponseModel
                {
                    Data = course,
                    Status = true,
                    Message = "These are list of courses"
                };
            }
             return new CoursesResponseModel
            {
                Status = true,
               Message = "These are list of courses"
            };            
        } 
        public bool DeleteCourseFromSchool(int schoolcourseid)
        {
            var getschoolcourse = _schoolcourseRepo.GetSchoolCourse(schoolcourseid);
            _schoolcourseRepo.DeleteCourseFromSchool(getschoolcourse);
            return true;
        }
        public bool AddNewCourseToSchool(SchoolRequestModel schoolrequest, int id)
        {
             var school = _schoolRepo.GetSchool(id);
             var courses = _courseRepo.GetCoursesByIds(schoolrequest.CourseIds);
             if (school != null)
             {  
                 foreach (var course in courses)
                 {
                    var schoolCourse = new SchoolCourse
                   {
                        SchoolId = school.Id,
                        CourseId = course.Id,
                       
                   };
                   
                   if (_schoolcourseRepo.CheckSchoolCourse(school.Id, course.Id) == true)
                   {
                       _schoolcourseRepo.AddSchoolCourse(schoolCourse);
                   } 
                 }                  
             }
             return true;  
        }
        
    }
}
     