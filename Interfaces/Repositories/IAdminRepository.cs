using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Repositories
{
    public interface IAdminRepository
    {
         Admin CreateAdmin(Admin admin);
         Admin UpdateAdmin(Admin admin);
         Admin GetAdmin(int id);
         IList<AdminDto> GetAllAdmins();
         bool DeleteAdmin(int id);
    }
}