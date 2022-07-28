using JambRegistrationMVC.Context;
using System;
using JambRegistrationMVC.Dtos;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using JambRegistrationMVC.Entities;
using JambRegistrationMVC.Interfaces.Repositories;
namespace JambRegistrationMVC.Implementations.Repositories
{
    public class CenterRepository : ICenterRepository
    {
        private readonly ApplicationContext _context;
        public CenterRepository(ApplicationContext context)
        {
            _context = context;
        }  
        public Center CreateCenter(Center center)
        {
            _context.Centers.Add(center);
            _context.SaveChanges();
            return center;            
        }
        public Center UpdateCenter(Center center)
        {
            _context.Centers.Update(center);
            _context.SaveChanges();
            return center;            
        }
        public Center GetCenter(int id)
        {
            var center = _context.Centers.Find(id);
            return center;
        }
        public  IList<CenterDto> GetAllCenters()
        {
            var center = _context.Centers.Select(c => new CenterDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Capacity = c.Capacity,
            }).ToList();
            return center;
        }         
        public bool DeleteCenter(int id)
        {
            var center = _context.Centers.Find(id);
            _context.Centers.Remove(center);
            _context.SaveChanges();
            return true; 
        }
        public IList<Center> GetCenterByIds(List<int> centerid)
        {
            var center = _context.Centers.Where(c => centerid.Contains(c.Id)).ToList();
            return center;
        }
    }
}