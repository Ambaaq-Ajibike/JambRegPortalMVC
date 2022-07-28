using System;
using JambRegistrationMVC.Contract;
using System.Collections;
using JambRegistrationMVC.Entities;
using System.Collections.Generic;
namespace JambRegistrationMVC.Identity
{
    public class User : AuditableEntity
    {
        public int Id{get; set;}
        public string UserName{get; set;}
        public string Password{get; set;}
        public string Email{get; set;}
        public Admin Admin{get; set;}
        public Student Student{get; set;}
        public IList<UserRole> UserRoles{get; set;} = new List<UserRole>();
    }    
}