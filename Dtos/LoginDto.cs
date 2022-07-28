using System;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Dtos
{
    public class LoginRequestModel
    {
       public string Email{get; set;}
        public string Password{get; set;}
    }
    public class LoginDto
    {
        public int Id{get ; set;}
       public string Name{get; set;}
    }
}