using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Model;

namespace WebShop.Web.Models
{
    public class indexModel
    {
        public ListOfPinnedProducts listOfPinnedProducts { get; set; }
        public List<CategoryModel> listOfCategories { get; set; }

        public indexModel(ListOfPinnedProducts listOfPinnedProducts, List<CategoryModel> listOfCategories)
        {
            this.listOfPinnedProducts = listOfPinnedProducts;
            this.listOfCategories = listOfCategories;
        }
    }
}
