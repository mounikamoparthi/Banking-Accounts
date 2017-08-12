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
        
    }
}
