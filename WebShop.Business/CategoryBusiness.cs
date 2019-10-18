using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Business
{
    public class CategoryBusiness
    {
        public List<CategoryModel> GetAllCategories()
        {
            ICategoryData cd = new CategoryData();
            IFeaturedPropertyData ifpd = new FeaturedPropertyData();
            List<CategoryModel> outputList = cd.SelectAll();

            foreach(CategoryModel category in outputList)
            {
                category.FeaturedProperties = ifpd.SelectFeaturedPropertiesByCategoryID(category);
            }

            return outputList;
        }

        public CategoryModel GetCategory(CategoryModel category)
        {
            ICategoryData cd = new CategoryData();
            IFeaturedPropertyData ifpd = new FeaturedPropertyData();
            CategoryModel output = cd.Select(category);
            output.FeaturedProperties = ifpd.SelectFeaturedPropertiesByCategoryID(category);
            return output;
        }

        public CategoryModel AddCategory(CategoryModel category)
        {
            ICategoryData cd = new CategoryData();
            IFeaturedPropertyData ifpd = new FeaturedPropertyData();

            CategoryModel result = null;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    result = cd.Insert(category);

                    for (int i = 0; i < category.FeaturedProperties.Count; i++)
                    {
                        //insert metoda vraca insertovan objekat (potreban nam je zbog jedinstvenog ID koji dobijamo tek nakon select-a koji se desava nakon ubacivanja zapisa
                        category.FeaturedProperties[i] = ifpd.InsertFeaturedProperty(category.FeaturedProperties[i]);
                    }
                    result.FeaturedProperties = category.FeaturedProperties;
                    scope.Complete();
                }
            }
            catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;           
        }

        public CategoryModel EditCategory(CategoryModel category)
        {
            ICategoryData cd = new CategoryData();
            IFeaturedPropertyData ifpd = new FeaturedPropertyData();

            CategoryModel result = null;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    result = cd.Update(category);

                    for (int i = 0; i < category.FeaturedProperties.Count; i++)
                    {
                        category.FeaturedProperties[i] = ifpd.UpdateFeaturedProperty(category.FeaturedProperties[i]);
                    }
                    result.FeaturedProperties = category.FeaturedProperties;
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
