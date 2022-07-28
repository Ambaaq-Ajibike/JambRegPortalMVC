using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Services
{
    public interface IAdminService
    {
         AdminResponseModel AddAdmin(AdminsRequestModel admin);
         AdminResponseModel EditAdmin(AdminsRequestModel admin, int id);
         AdminResponseModel GetAdmin(int id);
         AdminsResponseModel GetAllAdmins();
         bool DeleteAdmin(int id);
    }
}