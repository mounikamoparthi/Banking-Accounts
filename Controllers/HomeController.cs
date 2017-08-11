using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bankaccounts.Models;

namespace bankaccounts.Controllers
{
    public class HomeController : Controller
    {
        private BankContext _context;
 
        public HomeController(BankContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserViewModel model,User NewUser)
        {
            if(ModelState.IsValid){

                NewUser.CreatedAt = DateTime.Now;
                NewUser.UpdatedAt = DateTime.Now;
                _context.Add(NewUser);
                _context.SaveChanges();
                return RedirectToAction("show");
            }
            else {
                ViewBag.errors = ModelState.Values;
                ViewBag.status = "fail";
                return View("Index");
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpGet]
        [Route("show")]
        public IActionResult show(){
            return View();
        }

    }
}
