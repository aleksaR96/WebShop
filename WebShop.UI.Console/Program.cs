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

            PropertyGroupsBusiness pgb = new PropertyGroupsBusiness();

            var items = pgb.GetAllPropertyGroups();

            foreach(var item in items)
            {
                WriteLine(item);
            }

            var inserted = pgb.AddPropertyGroups(new PropertyGroupsModel("Proba", 200, "Proba", 0));

            WriteLine("\n" + inserted);

            var selected = pgb.GetPropertyGroups(inserted);

            WriteLine("\n" + selected);

            var updated = pgb.EditPropertyGroups(new PropertyGroupsModel(selected.GroupID, "Izmenjen", 0, "Proba", 0));

            WriteLine("\n" + updated + "\n\n");

            items = pgb.GetAllPropertyGroups();

            foreach (var item in items)
            {
                WriteLine(item);
            }

            ReadKey();

        }
               
    }
}
           