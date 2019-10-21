using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;
using WebShop.Business;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        [Breadcrumb("Kategorije", FromAction = "Index", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            CategoryBusiness cb = new CategoryBusiness();
            ProductsBusiness pb = new ProductsBusiness();
            
            return View(new CategoryViewModel(cb.GetAllCategories(), pb.GetAllPinnedDiscountProducts()));
        }
    }
}