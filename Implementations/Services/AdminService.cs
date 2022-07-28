using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Interfaces.Repositories;
using JambRegistrationMVC.Implementations.Repositories;
using JambRegistrationMVC.Interfaces.Services;
using JambRegistrationMVC.Interfaces.Identity;
using JambRegistrationMVC.Identity;
namespace JambRegistrationMVC.Implementations.Services
{
    public class AdminService : IAdminService
    {
        private IAdminRepository IadminRepo;
        private IIdentityService _identityService;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        public AdminService(IAdminRepository _adminRepo, IRoleRepository roleRepository, IIdentityService identityService, IUserRepository userRepository)
        {
            IadminRepo = _adminRepo;
            _userRepository = userRepository;
            _identityService = identityService;
            _roleRepository = roleRepository;
        }
        public  AdminResponseModel AddAdmin(AdminsRequestModel admin)
        {
            if (CheckAdmin(admin.Email) == false)
            {
                var authenticatedUser = int.Parse(_identityService.GetUserIdentity());
                var user = new User
                {
                    UserName = $"{admin.FirstName} {admin.LastName}",
                    Password = admin.Password,
                    Email = admin.Email,
                    CreatedBy = authenticatedUser
                };
                _userRepository.AddUser(user);
                var roles = _roleRepository.GetSelectedRoles(admin.UserRole);
                foreach (var role in roles)
                {
                    var userRole = new UserRole
                    {
                        UserId = user.Id,
                        User = user,
                        RoleId = role.Id,
                        CreatedBy = authenticatedUser
                    };
                    user.UserRoles.Add(userRole);
                } 
                _userRepository.UpdateUser(user);  
            
                var addadmin = new Admin
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Address = admin.Address,
                    Gender = admin.Gender,
                    AdminId = GenerateAdminId()
                };
                var addadminToDb = IadminRepo.CreateAdmin(addadmin);
                if (addadminToDb != null)
                {
                    var adminDto = new AdminDto
                    {
                        Id = addadminToDb.Id,
                        FullName = $"{addadminToDb.FirstName} {addadminToDb.LastName}",
                        Address = addadminToDb.Address,
                        Email =  addadminToDb.User.Email,
                        AdminId = addadminToDb.AdminId,
                        Gender = addadminToDb.Gender
                    };
                    return new  AdminResponseModel
                    {
                        Status = true,
                        Message = "Admin Successfully added",
                        Data = adminDto
                    };
                }
            }            
            return new  AdminResponseModel
            {
                Status = false,
                Message = "Admin with these email already exist"
            };
            
        }
        private string GenerateAdminId()
        {
            var newguid = Guid.NewGuid().ToString().Substring(0, 4);
            string join = "";
            for (int i = 0; i < newguid.Length; i++)
            {
                var convert = ((int) newguid[i]);
                join+= convert;
            }
            return $"Admin {join.Substring(0, 4)}";
        }
        public AdminResponseModel EditAdmin(AdminsRequestModel adminrequest, int id)
         {
             var checkId = IadminRepo.GetAdmin(id);
             if (checkId != null)
             {
                    //checkId.FirstName = adminrequest.FirstName;
                    checkId.LastName = adminrequest.LastName;
                    checkId.Address = adminrequest.Address;
                    checkId.User.Email = adminrequest.Email;
                    checkId.User.Password = adminrequest.Password;
                    checkId.Gender = adminrequest.Gender;
                 
                 IadminRepo.UpdateAdmin(checkId);
                 var AdDto = new AdminDto
                 {
                     Id = checkId.Id,
                     FullName = $"{checkId.FirstName} {checkId.LastName}",                    
                     Address = checkId.Address,
                     Gender = checkId.Gender
                 };
                 return new AdminResponseModel
                 {
                     Data = AdDto,
                     Status = true,
                     Message = "Successfully updated"
                 };
             }
             return new AdminResponseModel
             {
                 Status = false,
                 Message = "Not Successful"
             };
        }
        public AdminResponseModel GetAdmin(int id)
        {
            var checkId = IadminRepo.GetAdmin(id);
            if(checkId != null)
            {
                 var AdDto = new AdminDto
                {
                    Id = checkId.Id,
                    FullName = $"{checkId.FirstName} {checkId.LastName}",                    
                    Address = checkId.Address,
                    Gender = checkId.Gender,
                    AdminId = checkId.AdminId
                };
                return new AdminResponseModel
                {
                    Data = AdDto,
                    Status = true,
                    Message = "Successfully updated"
                };
            }
            return new AdminResponseModel
            {
                Status = false,
                Message = "Not Successful"
            };
        }
        public  AdminsResponseModel GetAllAdmins()
        {
            var allAdmins = IadminRepo.GetAllAdmins();
            return new AdminsResponseModel
            {
                Data = allAdmins,
                Status = true,
                Message = "These are list of admins"
            };
        }
        public bool DeleteAdmin(int id)
        {
            var checkId = IadminRepo.GetAdmin(id);
            IadminRepo.DeleteAdmin(id);
            return true;
        }
        public bool CheckAdmin(string email)
        {
             var allAdmins = IadminRepo.GetAllAdmins();
             foreach (var admin in allAdmins)
             {
                if(email == admin.Email)
                {
                    return true;
                }
               
             }
              return false;
        }
    }
}