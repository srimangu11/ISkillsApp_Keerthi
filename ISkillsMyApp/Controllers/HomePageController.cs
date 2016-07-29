using ISkillsMyApp.Models;

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

        ISkillsContext database = new ISkillsContext();
        private const int PAGE_SIZE = 3;
        // GET: Shop
        public ActionResult Index(int page = 1, int categoryID = 0, string SearchString = "")
        {
            return View(Getmodel(page, categoryID));
        }
        [HttpPost]
        public ActionResult Index(ProductsModel productsmodel)
        {
            return View(Getmodel(1, productsmodel.CategoryID));
        }

        private ProductsModel Getmodel(int page, int categoryID)
        {
            var data = database.Products.Select(p => p).Where(p => categoryID == 0 || p.CategoryID == categoryID)
               
                .OrderBy(p => p.ProductName).Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            ProductsModel model = new ProductsModel
            {
                Products = data,
                Pagination = new PaginationModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = categoryID == 0 ?
                    database.Products.Count() : database.Products.Select(p => p).Where(p => p.CategoryID == categoryID).Count()
                },
                CategoryID = categoryID
            };
            return model;
        }
    }
}