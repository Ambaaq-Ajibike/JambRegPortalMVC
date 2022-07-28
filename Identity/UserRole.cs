using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Contract;
namespace JambRegistrationMVC.Identity
{
    public class UserRole : AuditableEntity
    {
        public int Id{get; set;}
        public int UserId{get; set;}
        public User User{get; set;}
        public int RoleId{get; set;}
        public Role Role{get; set;}
    }
}