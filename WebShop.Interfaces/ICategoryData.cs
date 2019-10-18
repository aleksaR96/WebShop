using System.Collections.Generic;
using WebShop.Model;

namespace WebShop.Data
{
    public interface ICategoryData
    {
        bool Delete(CategoryModel category);
        CategoryModel Insert(CategoryModel newCategory);
        CategoryModel Select(CategoryModel category);
        List<CategoryModel> SelectAll();
        CategoryModel Update(CategoryModel category);
    }
}