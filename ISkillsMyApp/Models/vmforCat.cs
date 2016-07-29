using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISkillsMyApp.ViewModels
{
    public class vmforCat
    {
        public IEnumerable<CategoriesListVM> Categories {get; set ;}
        public IEnumerable<ProductListVM> Product {get; set; }
    }
    public class CategoriesListVM
    {
    public int CategoryID {get; set;}
    public string CategoryName {get; set;}
}

    public class ProductListVM
    {
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Description{ get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public string Details { get; set; }
}
}