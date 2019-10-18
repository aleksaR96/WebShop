using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebShop.Business;
using WebShop.Model;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class HomeController : Controller
    {
        [DefaultBreadcrumb("Početna")]
        public IActionResult Index()
        {
            ProductsBusiness pb = new ProductsBusiness();
            List<ProductsModel> discountProducts = pb.GetAllPinnedDiscountProducts();
            List<ProductsModel> newProducts = pb.GetAllPinnedNewProducts();
            List<ProductsModel> popularProducts = pb.GetAllPinnedPopularProducts();

            CategoryBusiness cb = new CategoryBusiness();
            List<CategoryModel> categoryList = cb.GetAllCategories();
            ListOfPinnedProducts listOfPinnedProducts = new ListOfPinnedProducts(discountProducts, newProducts, popularProducts);
            return View(new indexModel(listOfPinnedProducts, categoryList));
        }

        //ne treba stajati u home controleru, sluzi samo za test ajaxa
        [HttpGet]
        public JsonResult Load24Products(string page)
        {
            var pagging = Int32.Parse(page);
            var offset = (pagging - 1) * 24;
            ProductsBusiness pb = new ProductsBusiness();
            return Json(pb.Get24ProductsWithOffset(offset));
        }

        //propa za slanje partial viewa
        [HttpPost]
        public PartialViewResult LoadHtml()
        {
            ProductsBusiness pb = new ProductsBusiness();
            List<ProductsModel> discountProducts = pb.GetAllPinnedDiscountProducts();
            List<ProductsModel> newProducts = pb.GetAllPinnedNewProducts();
            List<ProductsModel> popularProducts = pb.GetAllPinnedPopularProducts();

            CategoryBusiness cb = new CategoryBusiness();
            List<CategoryModel> categoryList = cb.GetAllCategories();
            ListOfPinnedProducts listOfPinnedProducts = new ListOfPinnedProducts(discountProducts, newProducts, popularProducts);

            return PartialView("_indexDiscountSlider", new indexModel(listOfPinnedProducts, categoryList));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
