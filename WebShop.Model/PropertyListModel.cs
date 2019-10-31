using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class PropertyListModel : BaseModel
    {
        public int PropertyID { get; set; }
        public int GroupID { get; set; }
        public string Name { get; set; }

        public PropertyListModel(int propertyID, int groupID, string value)
        {
            PropertyID = propertyID;
            GroupID = groupID;
            Name = value;
        }

        public PropertyListModel(int groupID, string value)
        {
            GroupID = groupID;
            Name = value;
        }

        public PropertyListModel(int propertyID)
        {
            PropertyID = propertyID;
        }

        public PropertyListModel()
        {
        }

        public override string ToString()
        {
            return PropertyID + " " + GroupID + " " + Name;
        }
    }
}
