using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Model;

namespace WebShop.KorisnikApija.Models
{
    public class PropertyGroup
    {
        public PropertyGroupsModel PropertyGroupModel { get; set; }
        public List<PropertyListModel> PropertyList { get; set; }

        public PropertyGroup(PropertyGroupsModel propertyGroupModel, List<PropertyListModel> propertyList)
        {
            PropertyGroupModel = propertyGroupModel;
            PropertyList = propertyList;
        }

        public PropertyGroup()
        {
        }
    }
}
