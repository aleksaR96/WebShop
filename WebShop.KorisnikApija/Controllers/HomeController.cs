using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.KorisnikApija.Models;

namespace WebShop.KorisnikApija.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> LoadCategories()
        {
            var result = await GetCategoriesAsync("https://localhost:44315/api/AddProduct/1");
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> LoadBrands()
        {
            var result = await GetBrandsAsync("https://localhost:44315/api/AddProduct/2");
            return Ok(result);
        }

        static async Task<string> GetCategoriesAsync(string path)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(path);

            var result = await response.Content.ReadAsStringAsync();
           
            return result;
        }

        static async Task<string> GetBrandsAsync(string path)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(path);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
