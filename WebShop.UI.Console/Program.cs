using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebShop.Business;
using WebShop.Data;
using WebShop.Model;
using static System.Console;

namespace WebShop.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            CategoryBusiness cb = new CategoryBusiness();

            FeaturedPropertyModel fp1 = new FeaturedPropertyModel(100, 3);
            FeaturedPropertyModel fp2 = new FeaturedPropertyModel(100, 12);

            CategoryModel cat = new CategoryModel(111, "test", "test", "test");
            cat.FeaturedProperties = new List<FeaturedPropertyModel>{ fp1, fp2};

            cat = cb.AddCategory(cat);


            WriteLine(cat);

            ReadKey();

        }
               
    }
}
           