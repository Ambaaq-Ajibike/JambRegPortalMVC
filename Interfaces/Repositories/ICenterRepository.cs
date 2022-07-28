using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Repositories
{
    public interface ICenterRepository
    {
         Center CreateCenter(Center center);
         Center UpdateCenter(Center center);
         Center GetCenter(int id);
         IList<CenterDto> GetAllCenters();
         bool DeleteCenter(int id);
         IList<Center> GetCenterByIds(List<int> centerid);
    }
}