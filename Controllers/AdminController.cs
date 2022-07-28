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
    public class AdminController : Controller
    {
        private readonly IAdminService IadminService;

        public AdminController(IAdminService _IadminService)
        {
            IadminService = _IadminService;
        }
        public IActionResult Index()
        {
            var admins = IadminService.GetAllAdmins();
            return View(admins.Data);
        }
        public IActionResult CreateAdmin()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult CreateAdmin(AdminsRequestModel admin)
        {
            var createadmin = IadminService.AddAdmin(admin);
            if(createadmin == null)
            {
                return RedirectToAction("Admin with this email already exist");
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateAdmin(int id)
        {
            var admin = IadminService.GetAdmin(id);
            return View(admin);
        }
        [HttpPost]
        public IActionResult UpdateAdmin(AdminsRequestModel admin, int id)
        {
            IadminService.EditAdmin(admin, id);
            return RedirectToAction("Index");
        }
        public IActionResult GetAdmin(int id)
        {
            var admin = IadminService.GetAdmin(id);
            return View(admin);
        }
        public IActionResult Delete(int id)
        {
            var admin = IadminService.GetAdmin(id);
            return View(admin);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteAdmin(int id)
        {
            IadminService.DeleteAdmin(id);
            return RedirectToAction("Index");
        }
    }
    
}
       
         