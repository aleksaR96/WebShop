using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    class PropertyListModel
    {
        public int PropertyID { get; set; }
        public int GroupID { get; set; }
        public string Value { get; set; }

        public PropertyListModel(int propertyID, int groupID, string value)
        {
            PropertyID = propertyID;
            GroupID = groupID;
            Value = value;
        }

        public PropertyListModel()
        {
        }

        public override string ToString()
        {
            return PropertyID + " " + GroupID + " " + Value;
        }
    }
}
