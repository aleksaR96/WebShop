using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    class PropertyGroupsModel
    {
        public int GroupID { get; set; }
        public string Name { get; set; }

        public PropertyGroupsModel(int groupID, string name)
        {
            GroupID = groupID;
            Name = name;
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
