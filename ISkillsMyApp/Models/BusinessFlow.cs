using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISkillsMyApp.Models;
using ISkillsMyApp.ViewModels;

namespace ISkillsMyApp.ViewModels
{
    public class BusinessFlow
    {

        public vmforCat getInformation(string categoryid, bool Isgetproductlist)
        {
            ISkillsContext db = new ISkillsContext();
            vmforCat vm = new vmforCat();

            vmforCat obj = new vmforCat();

            vm.Categories = from e in db.Categories
                            select new CategoriesListVM
                            {
                                CategoryID = e.CategoryID,
                                CategoryName = e.CategoryName


                            };

            if (Isgetproductlist && categoryid != null)
            {
                var catid = Convert.ToInt16(categoryid);
                vm.Product = from pinfo in db.Products
                             join categorieslist in db.Categories
                             on pinfo.CategoryID equals categorieslist.CategoryID
                             where pinfo.CategoryID == catid
                             select new ProductListVM
                             {

                                 ProductName = pinfo.ProductName,
                                 Description = pinfo.Description,
                                 Price = pinfo.Price,
                                 Image = pinfo.Image,
                                 Details = pinfo.Details
                             };
            }


            return vm;




        }
    }
}
