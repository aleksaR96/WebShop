using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class FeaturedPropertyModel : BaseModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int PropertyID { get; set; }

        public FeaturedPropertyModel(int iD, int categoryID, int propertyID)
        {
            ID = iD;
            CategoryID = categoryID;
            PropertyID = propertyID;
        }

        public FeaturedPropertyModel(int categoryID, int propertyID)
        {
            CategoryID = categoryID;
            PropertyID = propertyID;
        }

        public FeaturedPropertyModel(int iD)
        {
            ID = iD;
        }

        public FeaturedPropertyModel()
        {
        }

        public override string ToString()
        {
            return "[ " + ID + " " + CategoryID + " " + PropertyID + " ]";
        }
    }
}
