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

            IPropertyListData pld = new PropertyListData();

            var all = pld.SelectAll();

            foreach(var one in all)
            {
                WriteLine(one);
            }

            var first = pld.Select(all[0]);
            WriteLine("\n\nSelect\n" + first);

            var inserted = pld.Insert(new PropertyListModel(1, "PROBA"));
            WriteLine("\n\nInsert\n" + inserted);

            var updated = pld.Update(new PropertyListModel(inserted.PropertyID, 1, "PROBA IZMENJEN"));
            WriteLine("\n\nUpdate\n" + updated);

            pld.Delete(updated);

            all = pld.SelectAll();
            WriteLine("\n\nNakon delete\n");
            foreach (var one in all)
            {
                WriteLine(one);
            }

            ReadKey();

        }
               
    }
}
           