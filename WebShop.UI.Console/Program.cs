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

            /*ProductsBusiness pb = new ProductsBusiness();

            var a = pb.GetAllProducts();

            //foreach (var b in a)
            //{
            //    WriteLine(b);
            //}

            for(int i = 0; i < a.Count; i++)
            {
                WriteLine("\n\n\n***********************************************************");
                WriteLine("ProductID: " + a[i].ProductID + " " + a[i].Name + "\n\n");

                foreach (PropertyModel property in a[i].FeaturedProperties)
                {
                    WriteLine(property);
                }

                foreach (PropertyListModel property in a[i].FeaturedPropertiesName)
                {
                    WriteLine(property);
                }

                //WriteLine("\n\n");

                //foreach(PropertyModel property in a[i].Properties)
                //{
                //    WriteLine(property);
                //}
            }*/
            /*
            ProductsBusiness pb = new ProductsBusiness();
            IPropertiesData prd = new PropertiesData();

            var a = pb.GetAllProducts();

            var referentniProduct = ProductsModel.GetProductModelFromListByID(a, 28) ?? new ProductsModel();
            
            int[] ids = {3,4,6,7,15,16,17,18,19,20,21,22,26,27};
            
            foreach(int id in ids)
            {
                foreach(PropertyModel property in referentniProduct.Properties)
                {
                    prd.InsertProperty(new PropertyModel(id, property.PropertyID, property.Value));
                }
            }

            a = pb.GetAllProducts();

            for (int i = 0; i < a.Count; i++)
            {
                WriteLine("\n\n\n***********************************************************");
                WriteLine("ProductID: " + a[i].ProductID + "\n\n");

                foreach (PropertyModel property in a[i].FeaturedProperties)
                {
                    WriteLine(property);
                }

                foreach (PropertyListModel property in a[i].FeaturedPropertiesName)
                {
                    WriteLine(property);
                }
            }*/

            //IPropertiesData prd = new PropertiesData();
            //prd.UpdatePropertyByProductIDAndPropertyID(new PropertyModel(15, 3, "Quad-Core"));

            /*string[] procesori = { "Dual-Core", "Quad-Core", "Hexa-Core", "Octa-Core" };
            string[] ram = { "2 Gb", "3 Gb", "4 Gb", "6 Gb"};

            IPropertiesData prd = new PropertiesData();
            ProductsBusiness pb = new ProductsBusiness();

            Random random1 = new Random();
            Random random2 = new Random();
            int b, z;

            var prds = pb.GetAllProducts();

            foreach(var prdu in prds)
            {
                b = random1.Next(0, procesori.Length);
                z = random2.Next(0, ram.Length);
                prd.UpdatePropertyByProductIDAndPropertyID(new PropertyModel((int)prdu.ProductID, 3, procesori[b]));
                prd.UpdatePropertyByProductIDAndPropertyID(new PropertyModel((int)prdu.ProductID, 12, ram[z]));
            }*/
            IPropertiesData prd = new PropertiesData();
            prd.UpdatePropertyByProductIDAndPropertyID(new PropertyModel(6, 3, "Quad-Core"));

            ReadKey();

        }
               
    }
}
           