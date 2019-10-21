using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Model;

namespace WebShop.Web.Models
{
    public class CategoryViewModel
    {
        public List<CategoryModel> listOfCategories { get; set; }
        public ListOfPinnedProducts listOfPinnedProducts { get; set; }

        public CategoryViewModel(List<CategoryModel> listOfCategories, List<ProductsModel> discountProducts)
        {
            this.listOfCategories = listOfCategories;
            this.listOfPinnedProducts = new ListOfPinnedProducts(discountProducts);
        }
    }
}
