using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class PropertyModel : BaseModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int PropertyID { get; set; }
        public string Value { get; set; }

        public PropertyModel(int iD, int productID, int propertyID, string value)
        {
            ID = iD;
            ProductID = productID;
            PropertyID = propertyID;
            Value = value;
        }

        public PropertyModel(int propertyID, string value)
        {
            PropertyID = propertyID;
            Value = value;
        }

        public PropertyModel(int productID, int propertyID, string value)
        {
            ProductID = productID;
            PropertyID = propertyID;
            Value = value;
        }

        public PropertyModel(int propertyID)
        {
            PropertyID = propertyID;
        }

        public PropertyModel()
        {
        }

        public override string ToString()
        {
            return ID + " " + ProductID + " " + PropertyID + " " + Value;
        }
    }
}
