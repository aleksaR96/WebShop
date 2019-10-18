using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using WebShop.Business;
using WebShop.Model;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumb("ViewData.Title", FromAction = "Index", FromController = typeof(CategoryController))]
        public IActionResult ViewProducts(int id)
        {
            ProductsBusiness pd = new ProductsBusiness();
            List<ProductsModel> products = pd.GetAllProductsByCategory(id);
            CategoryBusiness cb = new CategoryBusiness();
            List<CategoryModel> categoryList = cb.GetAllCategories();
            ViewProductsModel viewProductsModel = new ViewProductsModel(categoryList, products, cb.GetCategory(new CategoryModel(id)));
            return View(viewProductsModel);
        }

        [Breadcrumb("ViewData.Title", FromAction = "ViewProducts", FromController = typeof(ProductsController))]
        public IActionResult GetProduct(int id)
        {
            ProductsBusiness pb = new ProductsBusiness();
            ProductsModel product = pb.GetProduct(new ProductsModel(id));

            return View(product);
        }

        [HttpGet]
        public PartialViewResult LoadProducts(string cats, string offs)
        {

            int categoryId = Int32.Parse(cats);
            int offset = Int32.Parse(offs);
            ProductsBusiness pb = new ProductsBusiness();
            ViewData["totalProducts"] = pb.GetTotalCountOfProductsByCategory(categoryId);
            List<ProductsModel> model = pb.Get24ProductsByCategoryWithOffset(categoryId, offset);
            return PartialView("_product", new Products(model));
        }
    }
}