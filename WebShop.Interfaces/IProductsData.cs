using System.Collections.Generic;
using WebShop.Model;

namespace WebShop.Data
{
    public interface IProductsData
    {
        bool Delete(ProductsModel product);
        bool Insert(ProductsModel newProduct);
        ProductsModel Select(ProductsModel product);
        ProductsModel SelectByName(ProductsModel product);
        List<ProductsModel> SelectAll();
        bool Update(ProductsModel product);
        List<ProductsModel> SelectProductsByCategoryID(int id);
        List<ProductsModel> SelectAllPinnedDiscountProducts();
        List<ProductsModel> SelectAllPinnedNewProducts();
        List<ProductsModel> SelectAllPinnedPopularProducts();
        List<ProductsModel> Select24ProductsWithOffset(int offset);
        List<ProductsModel> Select10ProductsWithOffset(int offset);
        List<ProductsModel> Select24ProductsByCategoryWithOffset(int categoryID, int offset);
        List<ProductsModel> Select10ProductsByCategoryWithOffset(int categoryID, int offset);
        ProductsModel SelectOneProductByCategoryWithOffset(int categoryID, int offset);
        int CountProductsByCategoryID(int categoryID);
    }
}