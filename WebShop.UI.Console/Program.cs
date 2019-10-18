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

            CategoryData cd = new CategoryData();

            cd.Update(new CategoryModel(301, "Periferije", "301.png", "fa fa-keyboard-o"));

            List<CategoryModel> list = cd.SelectAll();

            foreach(CategoryModel cat in list)
            {
                WriteLine(cat);
            }

            ReadKey();

        }
               
    }
}
           