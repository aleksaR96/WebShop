﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class ProductsModel : BaseModel
    {
        public int? ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int BrandID { get; set; }
        public byte Pinned { get; set; }
        public int Discount { get; set; }
        public byte New { get; set; }
        public byte Popular { get; set; }
        public int EAN { get; set; }
        public List<PropertyModel> Properties { get; set; }
        public List<ImageModel> Images { get; set; }
        public List<PropertyModel> FeaturedProperties { set; get; }
        public List<PropertyListModel> FeaturedPropertiesName { get; set; }

        public ProductsModel(string name, string description, int categoryID, float price, int quantity, int brandID, byte pinned, int discount, byte new1, byte popular, List<PropertyModel> properties, List<ImageModel> images)
        {
            ProductID = null;
            Name = name;
            Description = description;
            CategoryID = categoryID;
            Price = price;
            Quantity = quantity;
            BrandID = brandID;
            Pinned = pinned;
            Discount = discount;
            New = new1;
            Popular = popular;
            Properties = properties;
            Images = images;
            FeaturedProperties = new List<PropertyModel>();
            FeaturedPropertiesName = new List<PropertyListModel>();
        }

        public ProductsModel()
        {
            Properties = new List<PropertyModel>();
            Images = new List<ImageModel>();
            FeaturedProperties = new List<PropertyModel>();
            FeaturedPropertiesName = new List<PropertyListModel>();
        }

        public ProductsModel(int id)
        {
            ProductID = id;
            Properties = new List<PropertyModel>();
            Images = new List<ImageModel>();
            FeaturedProperties = new List<PropertyModel>();
            FeaturedPropertiesName = new List<PropertyListModel>();
        }

        public override string ToString()
        {
            string retString = ProductID + " " + EAN + " " + Name + " " + Description + " " + CategoryID + " " + Price + " " + Quantity + " " + BrandID + " " + Pinned + " " + Discount + " " + New + " " + Popular + " " + base.ToString();
            for(int i = 0; i < FeaturedProperties.Count; i++)
            {
                retString += " " + FeaturedPropertiesName[i].Value;
                retString += " " + FeaturedProperties[i].Value;
                retString += " " + i;
            }

            return retString;
        }

        public static ProductsModel GetProductModelFromListByID(List<ProductsModel> list, int id)
        {
            foreach(ProductsModel product in list)
            {
                if(product.ProductID == id)
                {
                    return product;
                }
            }

            return null;
        }
    }
}
