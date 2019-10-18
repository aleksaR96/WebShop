using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Model;

namespace WebShop.Interfaces
{
    public interface IImagesData
    {
        bool Delete(ImageModel image);
        bool DeleteByProductID(ProductsModel product);
        bool Insert(ImageModel newImage);
        ImageModel Select(ImageModel image);
        List<ImageModel> SelectByProductID(ProductsModel product);
        List<ImageModel> SelectAll();
        bool Update(ImageModel image);
        bool UpdateByProduct(ImageModel image);
    }
}
