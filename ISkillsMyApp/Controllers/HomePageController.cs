using ISkillsMyApp.Models;
using ISkillsMyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISkillsMyApp.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
       
        ISkillsContext db = new ISkillsContext();
        vmforCat vm = new vmforCat();
       BusinessFlow flow = new BusinessFlow();
       
        public ActionResult Index()
        {


            vm.Categories = from e in db.Categories
                            select new CategoriesListVM
                            {
                                CategoryID = e.CategoryID,
                                CategoryName = e.CategoryName


                            };

            return View(vm);

        }


        [HttpPost]
            public ActionResult Index(String catlist , string command)

        {
            bool getproductlist = false;
            if(command == "Productlist")
            {
                getproductlist = true;
            }
            vm = flow.getInformation(catlist, getproductlist);


            return View(vm);
            
        }
    }
}