using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Context;
using JambRegistrationMVC.Identity;
using JambRegistrationMVC.Interfaces.Identity;
using JambRegistrationMVC.Interfaces.Repositories;
namespace JambRegistrationMVC.Implementations.Identity
{
    public class RoleStore : IRoleRepository
    {
        private readonly ApplicationContext _context;
        public RoleStore(ApplicationContext context)
        {
            _context = context;
        }
        public Role AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }
        public Role UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }
        public Role GetRole(int id)
        {
            var role =  _context.Roles.Include(r => r.UserRoles).ThenInclude(x => x.User).SingleOrDefault(s => s.Id == id);;
            return role;
        }
        public IList<Role> GetAllRoles()
        {
            var roles = _context.Roles.Include(x => x.UserRoles).ThenInclude(s => s.User).ToList();
            return roles;
        }
        public bool DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return true;
        }
        public IList<Role> GetSelectedRoles(IList<int> ids)
        {
            var roles = _context.Roles.Where(x => ids.Contains(x.Id)).ToList();
            return roles;
        }   
    }
}