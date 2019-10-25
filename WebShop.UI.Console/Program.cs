using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebShop.Business;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Model;
using static System.Console;

namespace WebShop.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /*   BrandsData bd = new BrandsData();
              var brands = bd.SelectAll();

              foreach (BrandModel brd in brands)
              {
                  WriteLine(brd);
              }

              BrandModel brand = bd.Insert(new BrandModel("Gorenje"));
              WriteLine(brand + "\n");
              brand = bd.Select(brand);
              WriteLine(brand + "\n");
              brand = bd.Update(new BrandModel(brand.ID, "Beko"));
              WriteLine(brand + "\n");
              bd.Delete(brand);

              brands = bd.SelectAll();
              foreach (BrandModel brd in brands)
              {
                  WriteLine(brd);
              } */

            BrandsBusiness bb = new BrandsBusiness();
            List<BrandModel> list = new List<BrandModel>();
            list = bb.GetAllBrands();

            foreach (BrandModel novbr in list)
            {
                WriteLine(novbr);
            }

            BrandModel novi = bb.GetBrand(new BrandModel(10));
            WriteLine(novi);

            var dodat = bb.AddBrand(new BrandModel("Toshiba"));
            WriteLine(dodat);


            var izmenjen = bb.EditBrand(new BrandModel(dodat.ID, "Vox"));
            WriteLine(izmenjen);
            ReadKey();

        }
               
    }
}
           