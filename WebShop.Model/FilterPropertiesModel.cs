using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class FilterPropertiesModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int PropertyID { get; set; }

        public FilterPropertiesModel(int iD, int categoryID, int propertyID)
        {
            ID = iD;
            CategoryID = categoryID;
            PropertyID = propertyID;
        }

        public FilterPropertiesModel(int iD)
        {
            ID = iD;
        }

        public override string ToString()
        {
            return ID + " " + CategoryID + " " + PropertyID;
        }
    }
}
