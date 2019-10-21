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

            ProductsBusiness pb = new ProductsBusiness();

            var a = pb.GetAllProducts();

            foreach(var b in a)
            {
                WriteLine(b);
            }

            ReadKey();

        }
               
    }
}
           