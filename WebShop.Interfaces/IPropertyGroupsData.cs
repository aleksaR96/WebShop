using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Model;

namespace WebShop.Interfaces
{
    public interface IPropertyGroupsData
    {
        PropertyGroupsModel Select(PropertyGroupsModel propertyGroup);
        List<PropertyGroupsModel> SelectAll();
        PropertyGroupsModel Update(PropertyGroupsModel propertyGroup);
        PropertyGroupsModel Insert(PropertyGroupsModel propertyGroup);
        bool Delete(PropertyGroupsModel propertyGroup);
        List<PropertyGroupsModel> SelectByCategoryID(CategoryModel category);
    }
}
