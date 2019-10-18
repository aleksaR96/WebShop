using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Model;

namespace WebShop.Web.Models
{
    public class Products
    {
        public List<ProductsModel> ProductsList { get; set; }

        public Products(List<ProductsModel> products)
        {
            ProductsList = products;
        }
    }
}
