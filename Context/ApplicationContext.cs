using System;
using Microsoft.EntityFrameworkCore;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Identity;
namespace JambRegistrationMVC.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }
        public DbSet<Admin> Admins{get; set;}
        public DbSet<Center> Centers{get; set;}
        public DbSet<School> Schools{get; set;}
        public DbSet<Student> Students{get; set;}
        public DbSet<StudentSubject> StudentSubjects {get; set;}
        public DbSet<Subject> Subjects {get; set;}
        public DbSet<Course> Courses {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<UserRole> UserRoles {get; set;}
        public DbSet<SchoolCourse> SchoolCourses {get; set;}
    }
}