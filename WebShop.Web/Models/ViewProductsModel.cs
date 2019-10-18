using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Model;

namespace WebShop.Web.Models
{
    public class ViewProductsModel
    {
        public List<CategoryModel> listOfCategories { get; set; }
        public List<ProductsModel> listOfProducts { get; set; }
        public CategoryModel currentCategory { get; set; }

        public ViewProductsModel(List<CategoryModel> listOfCategories, List<ProductsModel> listOfProducts, CategoryModel category)
        {
            this.listOfCategories = listOfCategories;
            this.listOfProducts = listOfProducts;
            currentCategory = category;
        }
    }
}
