using System;
using System.Collections.Generic;
using System.Collections;
using JambRegistrationMVC.Entities;
namespace JambRegistrationMVC.Dtos
{
    public class CenterDto
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Address  {get; set;}
        public int Capacity{get; set;}
        List<Student> students{get; set;} = new List<Student>();
    }
    public class CenterResponseModel : BaseResponse
    {
       public CenterDto Data{get; set;}
    }
    public class CentersResponseModel : BaseResponse
    {
        public IList<CenterDto> Data{get; set;}
    }
    public class CenterRequestModel
    {
        public string Name{get; set;}
        public string Address  {get; set;}
        public int Capacity{get; set;}
    }
}