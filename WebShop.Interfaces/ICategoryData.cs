using System.Collections.Generic;
using WebShop.Model;

namespace WebShop.Data
{
    public interface ICategoryData
    {
        bool Delete(CategoryModel category);
        bool Insert(CategoryModel newCategory);
        CategoryModel Select(CategoryModel category);
        List<CategoryModel> SelectAll();
        bool Update(CategoryModel category);
    }
}