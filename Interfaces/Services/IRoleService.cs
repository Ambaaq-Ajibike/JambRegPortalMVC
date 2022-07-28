using System;
using System.Collections;
using System.Collections.Generic;
namespace JambRegistrationMVC.Interfaces.Services
{
    public class IRoleService
    {
        Role AddRole(Role role);
        Role UpdateRole(Role role);
        bool DeleteRole(Role role);
        Role GetRole(int id);
        IList<Role> GetAllRolesles();

    }
}