using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Security.Claims;
using JambRegistrationMVC.Identity;
using System.Collections.Generic;
namespace JambRegistrationMVC.Interfaces.Identity
{
    public interface IIdentityService
    {
        User FindByName(string name);
        bool CheckPassword(User user, string password);
        IList<string> GetUserRole(User user);
        string GetUserIdentity();
        void SetClaims(User user, IEnumerable<string> roles);
    }
}