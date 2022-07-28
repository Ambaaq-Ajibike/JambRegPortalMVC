using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Interfaces.Repositories;
using JambRegistrationMVC.Implementations.Repositories;
using JambRegistrationMVC.Interfaces.Services;
namespace JambRegistrationMVC.Implementations.Services
{
    public class CenterService : ICenterService
    {
        private ICenterRepository _centerRepo;
        public CenterService(ICenterRepository centerRepo)
        {
            _centerRepo = centerRepo;
        }
        public  CenterResponseModel AddCenter(CenterRequestModel center)
        {
            if (CheckCenter(center.Name, center.Address) == false)
            {
                var addCenter = new Center
                {
                    Name = center.Name,
                    Address = center.Address,
                    Capacity = center.Capacity
                };
                var addCenterToDb = _centerRepo.CreateCenter(addCenter);
                if (addCenterToDb != null)
                {
                    var centerDto = new CenterDto
                    {
                        Id = addCenterToDb.Id,
                        Name = addCenterToDb.Name,
                        Address = addCenterToDb.Address,
                        Capacity = addCenterToDb.Capacity
                    };
                    return new  CenterResponseModel
                    {
                        Status = true,
                        Message = "Center Successfully added",
                        Data = centerDto
                    };
                }
            }            
            return new  CenterResponseModel
            {
                Status = true,
                Message = "Center with these name already exist"
            };
            
        }
        public bool CheckCenter(string name, string address)
        {
             var allCenters = _centerRepo.GetAllCenters();
             foreach (var center in allCenters)
             {
                if(name == center.Name && address == center.Address)
                {
                    return true;
                }
               
             }
              return false;
        }
        public CenterResponseModel EditCenter(CenterRequestModel centerrequest, int id)
         {
             var checkId = _centerRepo.GetCenter(id);
             if (checkId != null)
             {
                    checkId.Name = centerrequest.Name;
                    checkId.Address = centerrequest.Address;
                    checkId.Capacity = centerrequest.Capacity;
                 _centerRepo.UpdateCenter(checkId);                                
                 return new CenterResponseModel
                 {
                     Data =new CenterDto
                    {
                        Id = checkId.Id,
                        Name = checkId.Name,
                        Address = checkId.Address,
                        Capacity = checkId.Capacity,
                    },
                     Status = true,
                     Message = "Successfully updated"
                 };
             }
             return new CenterResponseModel
             {
                 Status = false,
                 Message = "Not Successful"
             };
        }
        public CenterResponseModel GetCenter(int id)
        {
            var checkId = _centerRepo.GetCenter(id);
            if(checkId != null)
            {
                 var centerDto = new CenterDto
                 {
                     Id = checkId.Id,
                     Name = checkId.Name,
                     Address = checkId.Address,
                     Capacity = checkId.Capacity
                 };
                 return new CenterResponseModel
                 {
                     Data = centerDto,
                     Status = true,
                     Message = "Successfully updated"
                 };
            }
            return new CenterResponseModel
            {
                Status = false,
                Message = "Not Successful"
            };
        }
        public  CentersResponseModel GetAllCenters()
        {
            var allCenters = _centerRepo.GetAllCenters();
            return new CentersResponseModel
            {
                Data = allCenters,
                Status = true,
                Message = "These are list of centers"
            };
        }
        public bool DeleteCenter(int id)
        {
            var checkId = _centerRepo.GetCenter(id);
            _centerRepo.DeleteCenter(id);
            return true;
        }
        // public bool CheckCenterbyAvailability(int id)
        // {
        //     var avc = _centerRepo.GetCenter(id);
        //     if(avc.Capacity > 0)
        //     {  
        //         var availablecenter = (avc.Capacity) - 1;
        //         avc.Capacity = availablecenter;
        //         context.Centers.Update(avc);
        //         context.SaveChanges();
        //         return true;
        //     }
        //     return false;     
        // }
    }
}