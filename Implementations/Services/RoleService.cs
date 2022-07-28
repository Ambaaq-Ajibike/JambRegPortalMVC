using System;
using System.Collections.Generic;
using System.Collections;
using USERANDROLE.Identity;
using USERANDROLE.Entity;
using USERANDROLE.Interfaces.Identity;
using USERANDROLE.Interfaces.Repositories;
using USERANDROLE.Dtos;
using JambRegistrationMVC.Interfaces.Service;
namespace JambRegistrationMVC.Implementations.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        public RoleService(IRoleRepository rolerepository, IUserRepository userrepository, IIdentityService identityservice)
        {
            _roleRepository = rolerepository;
            _userRepository = userrepository;
            _identityService = identityservice;
        }
        public IList<Role> GetRoles()
        {
            var roles = _roleRepository.GetRoles();
            return roles;
        }
        public Role AddRole(Role role)
        {
            if (role == null)
            {
                throw new 
            }
             _roleRepository.AddRole(role);
            return role;
        }
        public Role UpdateRole(Role role)
        {
            _roleRepository.UpdateRole(role);
            return role;
        }
        public bool DeleteRole(Role role)
        {
            var
        }
        Role GetRole(int id);
        IList<Role> GetAllRolesles();
    }
}