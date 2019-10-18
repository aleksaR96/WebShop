using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Model;

namespace WebShop.Interfaces
{
    public interface IFeaturedPropertyData
    {
        List<FeaturedPropertyModel> SelectAllFeaturedProperties();

        FeaturedPropertyModel SelectFeaturedPropertyByID(FeaturedPropertyModel property);

        List<FeaturedPropertyModel> SelectFeaturedPropertiesByCategoryID(CategoryModel category);

        FeaturedPropertyModel InsertFeaturedProperty(FeaturedPropertyModel property);

        FeaturedPropertyModel UpdateFeaturedProperty(FeaturedPropertyModel property);

        bool DeleteFeaturedProperty(FeaturedPropertyModel property);
    }
}
