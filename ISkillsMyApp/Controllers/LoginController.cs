using ISkillsMyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using System.Web.Routing;
using System.Web.Security;


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
        [ValidateAntiForgeryToken]
        public ActionResult Index(Customer cust)
        {
            if (!ModelState.IsValid)
            {

                using (ISkillsContext dc = new ISkillsContext())
                {
                    var query = dc.Customers.Where(a => a.Email.Equals(cust.Email) && a.Password.Equals(cust.Password)).FirstOrDefault();

                    if (query != null)
                    {
                        Session["LogedUserID"] = query.Email.ToString();
                        Session["LogedUsername"] = query.FirstName.ToString();

                        return RedirectToAction("AfterLogin");

                    }
                    else
                    {
                        ModelState.AddModelError("", "The provided Username/password is incorrect");
                    }
                }

            }

            return View(cust);
        }
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public  ActionResult AfterLogout()
        {
      
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();

            return RedirectToAction("Index");

        }
          
    }


}















