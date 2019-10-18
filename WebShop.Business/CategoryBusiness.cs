using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using WebShop.Data;
using WebShop.Model;

namespace WebShop.Business
{
    public class CategoryBusiness
    {
        public List<CategoryModel> GetAllCategories()
        {
            ICategoryData cd = new CategoryData();
            return cd.SelectAll();
        }

        public CategoryModel GetCategory(CategoryModel category)
        {
            ICategoryData cd = new CategoryData();
            return cd.Select(category);
        }

        public bool AddCategory(CategoryModel category)
        {
            ICategoryData cd = new CategoryData();
            bool result = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    result = cd.Insert(category);
                    scope.Complete();
                }
            }
            catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;           
        }

        public bool EditCategory(CategoryModel category)
        {
            ICategoryData cd = new CategoryData();
            bool result = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    result = cd.Update(category);
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
