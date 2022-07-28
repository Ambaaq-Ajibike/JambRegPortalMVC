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
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepo;
        private ISchoolRepository _schoolRepo;
        public CourseService(ICourseRepository courseRepo, ISchoolRepository schoolRepo)
        {
            _courseRepo = courseRepo;
            _schoolRepo = schoolRepo;
        }
        public  CourseResponseModel AddCourse(CourseRequestModel course)
        {
            if (CheckCourse(course.Name) == false)
            {
                var addCourse = new Course
                {
                    Name = course.Name,
                };
                var addCourseToDb = _courseRepo.CreateCourse(addCourse);
                if (addCourseToDb != null)
                {
                    var courseDto = new CourseDto
                    {
                        Id = addCourseToDb.Id,
                        Name = addCourseToDb.Name
                    };
                    return new  CourseResponseModel
                    {
                        Status = true,
                        Message = "Course Successfully added",
                        Data = courseDto
                    };
                }
            }            
            return new  CourseResponseModel
            {
                Status = false,
                Message = "Course with these name already exist"
            };
            
        }
        public CourseResponseModel EditCourse(CourseRequestModel courserequest, int id)
         {
             var checkId = _courseRepo.GetCourse(id);
             if (checkId != null)
             {
                    checkId.Name = courserequest.Name;      
                 _courseRepo.UpdateCourse(checkId);
                 var courseDto = new CourseDto
                 {
                     Id = checkId.Id,
                     Name = checkId.Name
                 };
                 return new CourseResponseModel
                 {
                     Data = courseDto,
                     Status = true,
                     Message = "Successfully updated"
                 };
             }
             return new CourseResponseModel
             {
                 Status = false,
                 Message = "Not Successful"
             };
        }
        public CourseResponseModel GetCourse(int id)
        {
            var checkId = _courseRepo.GetCourse(id);
            if(checkId != null)
            {
                 var courseDto = new CourseDto
                {
                    Id = checkId.Id,
                    Name = checkId.Name
                };
                return new CourseResponseModel
                {
                    Data = courseDto,
                    Status = true,
                    Message = "Successfully updated"
                };
            }
            return new CourseResponseModel
            {
                Status = false,
                Message = "Not Successful"
            };
        }
        public  CoursesResponseModel GetAllCourses()
        {
            var allCourses = _courseRepo.GetAllCourses();
            return new CoursesResponseModel
            {
                Data = allCourses,
                Status = true,
                Message = "These are list of Courses"
            };
        }
        public bool DeleteCourse(int id)
        {
            var checkId = _courseRepo.GetCourse(id);
            _courseRepo.DeleteCourse(id);
            return true;
        }
        public bool CheckCourse(string name)
        {
             var allCourses = _courseRepo.GetAllCourses();
             foreach (var course in allCourses)
             {
                if(name == course.Name)
                {
                    return true;
                }
               
             }
              return false;
        }
         public  SchoolsResponseModel GetSchoolsByCourseId(int courselid)
        {
            // var getcourse = _schoolRepo.GetSchool(courselid);
            // if (getcourse != null)
            // {
                var course = _courseRepo.GetSchoolsByCourseId(courselid);
                 return new SchoolsResponseModel
                {
                    Data = course,
                    Status = true,
                    Message = "These are list of courses"
                };
            // }
            //  return new SchoolsResponseModel
            // {
            //     Status = true,
            //    Message = "These are list of courses"
            // };
            
        }        
    }
}