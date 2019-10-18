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
            /*ProductsBusiness pb = new ProductsBusiness();
            ProductsModel product = new ProductsModel();*/

            /*WriteLine("Unesi ime proizvoda: ");
            product.Name = ReadLine();
            WriteLine("Unesi opis proizvoda: ");
            product.Description = ReadLine();
            WriteLine("Unesi catID proizvoda: ");
            product.CategoryID = Convert.ToInt32(ReadLine());
            WriteLine("Unesi cenu proizvoda: ");
            product.Price = Convert.ToInt32(ReadLine());
            WriteLine("Unesi kolicinu proizvoda: ");
            product.Quantity = Convert.ToInt32(ReadLine());
            WriteLine("Unesi brandID proizvoda: ");
            product.BrandID = Convert.ToInt32(ReadLine());
            WriteLine("Unesi pinned proizvoda: ");
            product.Pinned = Convert.ToByte(ReadLine());
            WriteLine("Unesi discount proizvoda: ");
            product.Discount = Convert.ToInt32(ReadLine());
            WriteLine("Unesi new proizvoda: ");
            product.New = Convert.ToByte(ReadLine());
            WriteLine("Unesi popular proizvoda: ");
            product.Popular = Convert.ToByte(ReadLine());*/

            /*int[] id = {3, 4, 6, 7, 15, 16, 17 ,18, 19, 20, 21, 22, 26, 27 };
            List<PropertyModel> properties;
            PropertiesData pd = new PropertiesData();

            for (int i = 0; i < id.Length; i++)
            {
                properties = new List<PropertyModel>();
                properties.Add(new PropertyModel(id[i], 1, "158.5 x 74.7 x 7.7 mm"));
                properties.Add(new PropertyModel(id[i], 2, "166 g"));
                properties.Add(new PropertyModel(id[i], 3, "Octa-core"));
                properties.Add(new PropertyModel(id[i], 4, "4x2.3 GHz Cortex-A73 & 4x1.7 GHz Cortex-A53"));
                properties.Add(new PropertyModel(id[i], 5, "Li-Po"));
                properties.Add(new PropertyModel(id[i], 6, "4000 mAh"));
                properties.Add(new PropertyModel(id[i], 7, "1"));
                properties.Add(new PropertyModel(id[i], 8, "Super AMOLED"));
                properties.Add(new PropertyModel(id[i], 9, "6.4 inch"));
                properties.Add(new PropertyModel(id[i], 10, "1080 x 2340 pixels"));
                properties.Add(new PropertyModel(id[i], 11, "19.5:9"));
                properties.Add(new PropertyModel(id[i], 12, "4 Gb"));
                properties.Add(new PropertyModel(id[i], 13, "64GB"));
                properties.Add(new PropertyModel(id[i], 14, "1"));
                properties.Add(new PropertyModel(id[i], 15, "1 Tb"));
                properties.Add(new PropertyModel(id[i], 16, "1"));
                properties.Add(new PropertyModel(id[i], 17, "5.0"));
                properties.Add(new PropertyModel(id[i], 18, "1"));
                properties.Add(new PropertyModel(id[i], 19, "A-GPS"));
                properties.Add(new PropertyModel(id[i], 20, "1"));
                properties.Add(new PropertyModel(id[i], 21, "1"));
                properties.Add(new PropertyModel(id[i], 22, "GLONASS, GALILEO, BDS"));
                properties.Add(new PropertyModel(id[i], 23, "1"));
                properties.Add(new PropertyModel(id[i], 24, "1"));
                properties.Add(new PropertyModel(id[i], 25, "1"));
                properties.Add(new PropertyModel(id[i], 26, "1"));
                properties.Add(new PropertyModel(id[i], 27, "1"));
                properties.Add(new PropertyModel(id[i], 28, "25 MP, 8 MP, 5 MP"));
                properties.Add(new PropertyModel(id[i], 29, "1080 p"));
                properties.Add(new PropertyModel(id[i], 30, "1"));
                properties.Add(new PropertyModel(id[i], 31, "1"));
                properties.Add(new PropertyModel(id[i], 32, "25 MP"));
                properties.Add(new PropertyModel(id[i], 33, "1080 p"));
                properties.Add(new PropertyModel(id[i], 34, ""));

                foreach(PropertyModel propertyModel in properties)
                {
                    pd.InsertProperty(propertyModel);
                }
            }*/



            /*  WriteLine("unesi id prozivoda");  //svi properti za jedan prozivod

              int id = Convert.ToInt32(ReadLine());

              List<PropertyModel> list;

              PropertiesData pd = new PropertiesData();
              list = pd.SelectAllPropertiesByProductID(new ProductsModel(id));

              foreach (PropertyModel property in list)
              {
                  WriteLine(property);
              } 

              ProductsBusiness pb1 = new ProductsBusiness(); //svi prozivodi i svi property 

              List<ProductsModel> list = pb1.GetAllProducts();

              foreach (ProductsModel product1 in list)
              {
                  WriteLine(product1);

                  foreach (PropertyModel property in product1.Properties)
                  {
                      WriteLine("   " + property);
                  }
              }
            PropertiesData pd = new PropertiesData();
            ProductsModel product = new ProductsModel(25);
            product.Name = "Nokia 3310";
            product.Description = "";
            product.CategoryID = 100;
            product.Price = 100;
            product.Quantity = 5;

            product.Properties.Add(new PropertyModel(1, "888.5 x 74.7 x 7.7 mm"));
            product.Properties.Add(new PropertyModel(2, "166 g"));
            product.Properties.Add(new PropertyModel(3, "Octa-core"));
            product.Properties.Add(new PropertyModel(4, "4x2.3 GHz Cortex-A73 & 4x1.7 GHz Cortex-A53"));
            product.Properties.Add(new PropertyModel(5, "Li-Po"));
            product.Properties.Add(new PropertyModel(6, "4000 mAh"));
            product.Properties.Add(new PropertyModel(7, "1"));
            product.Properties.Add(new PropertyModel(8, "Super AMOLED"));
            product.Properties.Add(new PropertyModel(9, "6.4 inch"));
            product.Properties.Add(new PropertyModel(10, "1080 x 2340 pixels"));
            product.Properties.Add(new PropertyModel(11, "19.5:9"));
            product.Properties.Add(new PropertyModel(12, "4 Gb"));
            product.Properties.Add(new PropertyModel(13, "64GB"));
            product.Properties.Add(new PropertyModel(14, "1"));
            product.Properties.Add(new PropertyModel(15, "1 Tb"));
            product.Properties.Add(new PropertyModel(16, "1"));
            product.Properties.Add(new PropertyModel(17, "5.0"));
            product.Properties.Add(new PropertyModel(18, "1"));
            product.Properties.Add(new PropertyModel(19, "A-GPS"));
            product.Properties.Add(new PropertyModel(20, "1"));
            product.Properties.Add(new PropertyModel(21, "1"));
            product.Properties.Add(new PropertyModel(22, "GLONASS, GALILEO, BDS"));
            product.Properties.Add(new PropertyModel(23, "1"));
            product.Properties.Add(new PropertyModel(24, "1"));
            product.Properties.Add(new PropertyModel(25, "1"));
            product.Properties.Add(new PropertyModel(26, "1"));
            product.Properties.Add(new PropertyModel(27, "1"));
            product.Properties.Add(new PropertyModel(28, "25 MP, 8 MP, 5 MP"));
            product.Properties.Add(new PropertyModel(29, "1080 p"));
            product.Properties.Add(new PropertyModel(30, "1"));
            product.Properties.Add(new PropertyModel(31, "1"));
            product.Properties.Add(new PropertyModel(32, "25 MP"));
            product.Properties.Add(new PropertyModel(33, "1080 p"));
            product.Properties.Add(new PropertyModel(34, ""));

            

            ProductsBusiness pb = new ProductsBusiness();

            pb.EditProduct(product);
            product = pb.GetProduct(product);
            WriteLine(product);

            foreach (PropertyModel property in product.Properties)
            {
                WriteLine("   " + property);
            }*/


            /*ProductsBusiness pb = new ProductsBusiness();
            ProductsModel product = pb.GetProduct(new ProductsModel(28));
            var json = JsonConvert.SerializeObject(product);
            WriteLine(json);
            List<ProductsModel> output = pb.GetAllProductsByCategory(100);

            WriteLine("\n\nPO KATEGORIJI");
            foreach(var prod in output)
            {
                WriteLine(prod);
            }*/

            ProductsData pd = new ProductsData();
            WriteLine(pd.CountProductsByCategoryID(100));
           
            ReadKey();

        }
               
    }
}
           