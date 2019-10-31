using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class PropertyValueModel
    {
        public int ID { get; set; }
        public int PropertyID { get; set; }
        public string Value { get; set; }

        public PropertyValueModel(int iD, int propertyID, string value)
        {
            ID = iD;
            PropertyID = propertyID;
            Value = value;
        }

        public PropertyValueModel(int propertyID, string value)
        {
            PropertyID = propertyID;
            Value = value;
        }

        public PropertyValueModel(int iD)
        {
            ID = iD;
        }

        public PropertyValueModel()
        {
        }

        public override string ToString()
        {
            return ID + " " + PropertyID + " " + Value;
        }
    }
}
