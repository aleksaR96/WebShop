using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Model;

namespace WebShop.Web.Models
{
    public class ListOfPinnedProducts
    {
        public List<ProductsModel> discountProducts { get; set; }
        public List<ProductsModel> newProducts { get; set; }
        public List<ProductsModel> popularProducts { get; set; }

        public ListOfPinnedProducts(List<ProductsModel> discountProducts, List<ProductsModel> newProducts, List<ProductsModel> popularProducts)
        {
            this.discountProducts = discountProducts;
            this.newProducts = newProducts;
            this.popularProducts = popularProducts;
        }
    }
}
