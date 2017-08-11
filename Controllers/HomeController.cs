using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
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
            ViewBag.Errors = new List<string>();
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid){
                User NewUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailId = model.EmailId,
                    Password = model.Password,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                   
                };
 
        // Handle success
               
                System.Console.WriteLine("Came here");
                _context.Add(NewUser);
                _context.SaveChanges();
                System.Console.WriteLine("Done adding to DB");
                User EnteredPerson = _context.user.SingleOrDefault(user => user.EmailId == model.EmailId);
                HttpContext.Session.SetString("FirstName", EnteredPerson.FirstName);
                HttpContext.Session.SetInt32("UserId",EnteredPerson.UserId);
                return RedirectToAction("show");
            }
            else 
            {
                ViewBag.errors = ModelState.Values;
                 ViewBag.Errors = new List<string>();
                return View("Index");
            }
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [Route("PostLogin")]
        public IActionResult PostLogin(string EmailId, string Password)
        {
             User loggedUser = _context.user.SingleOrDefault(user => user.EmailId == EmailId);
             HttpContext.Session.SetString("FirstName", loggedUser.FirstName);
             HttpContext.Session.SetInt32("UserId", loggedUser.UserId);
             return RedirectToAction("show");
        }
        
        [HttpGet]
        [Route("show")]
        public IActionResult show(){
            ViewBag.UserName = HttpContext.Session.GetString("FirstName");
            return View("show");
        }
       
    }
}
