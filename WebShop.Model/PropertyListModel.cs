using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class PropertyListModel : BaseModel
    {
        public int PropertyID { get; set; }
        public int GroupID { get; set; }
        public string Value { get; set; }
        public int RelatedPropertyID { get; set; }
        public List<PropertyValueModel> Values { get; set; }

        public PropertyListModel(int propertyID, int groupID, string name)
        {
            PropertyID = propertyID;
            GroupID = groupID;
            Value = name;
        }

        public PropertyListModel(int groupID, string name)
        {
            GroupID = groupID;
            Value = name;
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
            return PropertyID + " " + GroupID + " " + Value + " " + RelatedPropertyID;
        }
    }
}
