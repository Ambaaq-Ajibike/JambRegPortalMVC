using JambRegistrationMVC.Context;
using System;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Interfaces.Repositories;
namespace JambRegistrationMVC.Implementations.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;
        public AdminRepository(ApplicationContext context)
        {
            _context = context;
        }  
        public Admin CreateAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return admin;            
        }
        public Admin UpdateAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return admin;            
        }
        public Admin GetAdmin(int id)
        {
            var admin = _context.Admins.Include(x => x.User).SingleOrDefault(a => a.Id == id);
            return admin;
        }
        public  IList<AdminDto> GetAllAdmins()
        {
            var admin = _context.Admins.Select(a => new AdminDto
            {
                Id = a.Id,
                FullName = $"{a.FirstName} {a.LastName}",                   
                Address = a.Address,
                Gender = a.Gender,
                AdminId = a.AdminId
            }).ToList();
            return admin;
        }         
        public bool DeleteAdmin(int id)
        {
            var admin = _context.Admins.Find(id);
            _context.Admins.Remove(admin);
            _context.SaveChanges();
            return true; 
        }
    }
}