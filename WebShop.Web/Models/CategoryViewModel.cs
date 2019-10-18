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

        public CategoryViewModel(List<CategoryModel> listOfCategories)
        {
            this.listOfCategories = listOfCategories;
        }
    }
}
