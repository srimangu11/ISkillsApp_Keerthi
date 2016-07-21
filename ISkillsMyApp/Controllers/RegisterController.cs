using ISkillsMyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISkillsMyApp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer cust)
        {


            Customer _adddb = new Customer();
            
            _adddb.FirstName = cust.FirstName;
            _adddb.LastName = cust.LastName;
            _adddb.Address = cust.Address;
            _adddb.CardNumber = cust.CardNumber;
            _adddb.BillingAddress = cust.BillingAddress;
            _adddb.BillingCity = cust.BillingCity;
            _adddb.BillingState = cust.BillingState;
            _adddb.BillingPostalCode = cust.BillingPostalCode;
            _adddb.Phone = cust.Phone;
            _adddb.Email = cust.Email;
            _adddb.Password = cust.Password;

            ISkillsContext _db = new ISkillsContext();
            _db.Customers.Add(_adddb);
            _db.SaveChanges();

            if (ModelState.IsValid)
                return View("Complete", cust);


            return View();



        }

        [HttpPost]

        public ActionResult Confirm(Customer cust)
        {
            return PartialView(cust);
        }
    }
}