using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using JambRegistrationMVC.Identity;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Identity
{
    public interface IUserRepository
    {
         User AddUser(User user);
         User UpdateUser(User user);
         User GetUser(int id);
         IList<string> GetUserRole(User user);
         User GetUserByName(string username);
         IList<User> GetAllUsers();
         bool DeleteUser(User user);
    }
}