using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class PropertyGroupsModel : BaseModel
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public string Alias { get; set; }
        public int SupGroup { get; set; }

        public PropertyGroupsModel(int groupID, string name, int categoryID, string alias, int supGroup)
        {
            GroupID = groupID;
            Name = name;
            CategoryID = categoryID;
            Alias = alias;
            SupGroup = supGroup;
        }

        public PropertyGroupsModel(int groupID)
        {
            GroupID = groupID;
        }

        public PropertyGroupsModel(string name, int categoryID, string alias, int supGroup)
        {
            Name = name;
            CategoryID = categoryID;
            Alias = alias;
            SupGroup = supGroup;
        }

        public PropertyGroupsModel()
        {
        }

        public override string ToString()
        {
            return GroupID + " " + Name;
        }
    }
}
