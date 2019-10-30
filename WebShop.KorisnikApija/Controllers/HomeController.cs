using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebShop.KorisnikApija.Models;
using WebShop.Model;

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
            var result = await GetCategoriesAsync("https://localhost:44315/api/Category");
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> LoadBrands()
        {
            var result = await GetBrandsAsync("https://localhost:44315/api/Brands");
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> LoadProperties(int categoryID)
        {
            var result = await GetPropertyGroupsAsync("https://localhost:44315/api/PropertyGroups/" + categoryID);
            List<PropertyGroup> propertyGroupList = new List<PropertyGroup>();
            var objects = JsonConvert.DeserializeObject<List<PropertyGroupsModel>>(result);
            foreach (var obj in objects)
            {
                PropertyGroup pg = new PropertyGroup();
                pg.PropertyGroupModel = obj;



                propertyGroupList.Add(pg);
            }
            return Ok(propertyGroupList);
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

        static async Task<string> GetPropertyGroupsAsync(string path)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(path);

            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
