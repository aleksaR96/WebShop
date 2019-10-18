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
    }
}
