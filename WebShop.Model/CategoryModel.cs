using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class CategoryModel : BaseModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }
        public List<FeaturedPropertyModel> FeaturedProperties { get; set; }

        public CategoryModel(int categoryID, string categoryName, string image, string icon, List<FeaturedPropertyModel> properties)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Image = image;
            Icon = icon;
            FeaturedProperties = properties;
        }

        public CategoryModel(int categoryID, string categoryName, string image, string icon)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Image = image;
            Icon = icon;
        }

        public CategoryModel(int categoryID)
        {
            CategoryID = categoryID;
        }

        public CategoryModel()
        {
        }

        public override string ToString()
        {
            return CategoryID + " " + CategoryName + " " +  Image + " " + Icon + " " + base.ToString();
        }
    }
}
