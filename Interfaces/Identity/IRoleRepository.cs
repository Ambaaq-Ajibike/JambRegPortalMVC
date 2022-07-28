using System;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Dtos;
using JambRegistrationMVC.Identity;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Interfaces.Identity
{
    public interface IRoleRepository
    {
         Role AddRole(Role role);
         Role UpdateRole(Role role);
         Role GetRole(int id);
         IList<Role> GetAllRoles();
         bool DeleteRole(Role role);
         IList<Role> GetSelectedRoles(IList<int> ids);
    }
}