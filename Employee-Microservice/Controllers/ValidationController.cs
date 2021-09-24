using Employee_Microservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Microservice.Controllers
{
    public class ValidationController : Controller
    {

        CoreDbContext db = new CoreDbContext();
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Validate(Employee admin)
        {
            var _admin = db.Employees.Where(s => s.UserName == admin.UserName);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Passcode == admin.Passcode).Any())
                {

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!" });
            }
        }
    }
}
