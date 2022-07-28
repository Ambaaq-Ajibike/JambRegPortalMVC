using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using JambRegistrationMVC.Identity;
using Microsoft.EntityFrameworkCore;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Interfaces.Identity;
using JambRegistrationMVC.Context;
using JambRegistrationMVC.Interfaces.Repositories;
namespace JambRegistrationMVC.Implementations.Identity
{
    public class UserStore : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserStore(ApplicationContext context)
        {
            _context = context;
        }
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
        public User GetUser(int id)
        {
            var user =  _context.Users.Include(r => r.UserRoles).ThenInclude(x => x.Role).SingleOrDefault(s => s.Id == id);;
            return user;
        }
        public User GetUserByName(string username)
        {
            var user =  _context.Users.Include(r => r.UserRoles).ThenInclude(x => x.Role).SingleOrDefault(s => s.UserName == username);
            return user;
        }
        public IList<User> GetAllUsers()
        {
            var users = _context.Users.Include(x => x.UserRoles).ThenInclude(s => s.Role).ToList();
            return users;
        }
        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
        public IList<string> GetUserRole(User user)
        {
            var roles = _context.UserRoles.Include(r => r.Role).Where(x => x.User == user).Select(a => a.Role.Name).ToList();
            return roles;
        }
    }
}