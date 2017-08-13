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
    public class TransactController : Controller
    {
        private BankContext _context;
 
        public TransactController(BankContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("RunTransaction")]
        public IActionResult RunTransaction(Transaction NewTransaction){
            System.Console.WriteLine("adding newTransction");
            
            NewTransaction.CreatedAt = DateTime.Now;
             var loggedUserId = HttpContext.Session.GetInt32("UserId");

             var update_success = Update(NewTransaction.Amount);
             if(update_success){
                NewTransaction.UserId = loggedUserId.Value;
            
                _context.Add(NewTransaction);
                _context.SaveChanges();
             }
             else{
                 System.Console.WriteLine(" ################In Else");
                 ViewBag.status = new List<string>(){"Invalid Amount"};
             }
                return RedirectToAction("show","Home");
            
        }
        public bool Update(double Amount){
            var loggedUserId = HttpContext.Session.GetInt32("UserId");
            var save_user = _context.user.Single(user => user.UserId == loggedUserId);
            var NewBal = save_user.CurrentBal + Amount;
            if (NewBal<0){
                return false;
            }
            else{
                save_user.CurrentBal = NewBal; //update currbal to newbal
                _context.SaveChanges();
                return true;
            }
        }

        

    }
}
