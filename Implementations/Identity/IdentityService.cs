using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using JambRegistrationMVC.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Security.Claims;
using System.Collections.Generic;
using JambRegistrationMVC.Interfaces.Identity;
namespace JambRegistrationMVC.Implementations.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public IdentityService(IUserRepository userRepository, IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }
        public User FindByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            var user = _userRepository.GetUserByName(name);
            return user;
        }
        public bool CheckPassword(User user, string password)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.Password == password)
            {
                return true;
            }
            return false;
        }
        public IList<string> GetUserRole(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var roles = _userRepository.GetUserRole(user);
            return roles;
        }
        public string GetUserIdentity()
        {
            var identity = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return identity;
        }
        public void SetClaims(User user, IEnumerable<string> roles)
        {
            IList<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimsIdentity);
            _contextAccessor.HttpContext?.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
        }
    }
}