using ISkillsMyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISkillsMyApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

       
        
        
        [HttpPost]
        public ActionResult Index(Customer cust)
        {

           
            
            ISkillsContext db = new ISkillsContext();
            var query = from e in db.Customers
                        where e.Email == cust.Email & e.Password == cust.Password
                        select e;

            if (query.Count() == 1)
            {
                return View("login", cust);
            }

            else
            {
                ModelState.AddModelError("", "EmailId or Password Incorrect.");
            }

            return View();

        }
    }
}

                
            
                        
        

