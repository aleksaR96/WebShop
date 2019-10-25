using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Model;

namespace WebShop.Interfaces
{
    public interface IBrandsData
    {
        bool Delete(BrandModel image);
        BrandModel Insert(BrandModel newImage);
        BrandModel Select(BrandModel image);
        List<BrandModel> SelectAll();
        BrandModel Update(BrandModel image);
    }
}
