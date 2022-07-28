using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JambRegistrationMVC.Models;
using JambRegistrationMVC.Dtos;
using JambRegistrationMVC.Interfaces.Services;
namespace JambRegistrationMVC.Controllers
{
    public class CenterController : Controller
    {
        ICenterService _centerService;
        public CenterController(ICenterService centerService)
        {
            _centerService = centerService;
        }
         public IActionResult Index()
        {
            var centers = _centerService.GetAllCenters();
            return View(centers.Data);
        }
        public IActionResult CreateCenter()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult CreateCenter(CenterRequestModel center)
        {
            var createcenter = _centerService.AddCenter(center);
            if(createcenter == null)
            {
                return RedirectToAction("Center with this name and address already exist");
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCenter(int id)
        {
            var center = _centerService.GetCenter(id);
            return View(center);
        }
        [HttpPost]
        public IActionResult UpdateCenter(CenterRequestModel center, int id)
        {
            _centerService.EditCenter(center, id);
            return RedirectToAction("Index");
        }
        public IActionResult GetCenter(int id)
        {
            var center = _centerService.GetCenter(id);
            return View(center);
        }
        public IActionResult Delete(int id)
        {
            var center = _centerService.GetCenter(id);
            return View(center);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCenter(int id)
        {
            _centerService.DeleteCenter(id);
            return RedirectToAction("Index");
        }
    }
}