using System;
using JambRegistrationMVC.Contract;
using System.Collections;
using JambRegistrationMVC.Entities;
using System.Collections.Generic;
namespace JambRegistrationMVC.Identity
{
    public class Role : AuditableEntity
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Description{get; set;}
        public IList<UserRole> UserRoles{get; set;} = new List<UserRole>();
    }    
}