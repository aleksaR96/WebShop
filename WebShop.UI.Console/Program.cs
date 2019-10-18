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
            CategoryModel kategorija = new CategoryModel();
            kategorija.CategoryName = "TEST";
            kategorija.CategoryID = 999;
            kategorija.Icon = "";
            kategorija.Image = "";

            FeaturedPropertyModel prop1 = new FeaturedPropertyModel(kategorija.CategoryID, 1);
            FeaturedPropertyModel prop2 = new FeaturedPropertyModel(kategorija.CategoryID, 3);
            FeaturedPropertyModel prop3 = new FeaturedPropertyModel(kategorija.CategoryID, 8);

            List<FeaturedPropertyModel> listaPropertija = new List<FeaturedPropertyModel>();
            listaPropertija.Add(prop1);
            listaPropertija.Add(prop2);
            listaPropertija.Add(prop3);

            CategoryModel list = cb.AddCategory(kategorija);

            WriteLine("\nDODATA: \n" + list);

            list.CategoryName = "IZMENJENA";
            list = cb.EditCategory(kategorija);
            WriteLine("\nIZMENJENA: \n" + list);

            //foreach(CategoryModel cat in list)
            //{
            //    WriteLine(cat);
            //}

            WriteLine(list);

            ReadKey();

        }
               
    }
}
           