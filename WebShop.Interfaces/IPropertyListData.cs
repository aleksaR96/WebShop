using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Model;

namespace WebShop.Interfaces
{
    public interface IPropertyListData
    {
        PropertyListModel SelectPropertyByPropertyID(PropertyModel property);
        PropertyListModel Select(PropertyListModel propertyList);
        List<PropertyListModel> SelectAll();
        PropertyListModel Update(PropertyListModel propertyList);
        PropertyListModel Insert(PropertyListModel propertyList);
        bool Delete(PropertyListModel propertyList);
    }
}
