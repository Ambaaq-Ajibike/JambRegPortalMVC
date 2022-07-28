using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Services
{
    public interface ICenterService
    {
         CenterResponseModel AddCenter(CenterRequestModel admin);
         CenterResponseModel EditCenter(CenterRequestModel admin, int id);
         CenterResponseModel GetCenter(int id);
         CentersResponseModel GetAllCenters();
         bool DeleteCenter(int id);
    }
}