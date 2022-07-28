using System;
using System.Collections.Generic;
using System.Collections;
namespace JambRegistrationMVC.Dtos
{
    public class AdminDto
    {
        public int Id{get; set;}
        public string FullName{get; set;}
        public string Address{get; set;}
        public string Email{get; set;}
        public string AdminId{get; set;}
        public Gender Gender{get; set;}
    }
    public class AdminResponseModel : BaseResponse
    {
       public AdminDto Data{get; set;}
    }
    public class AdminsResponseModel : BaseResponse
    {
        public IList<AdminDto> Data{get; set;}
    }
    public class AdminsRequestModel
    {
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Address{get; set;}
        public string Email{get; set;}
        public string Password{get; set;}
        public Gender Gender{get; set;}
        public IList<int> UserRole{get; set;} = new List<int>();
    }
}