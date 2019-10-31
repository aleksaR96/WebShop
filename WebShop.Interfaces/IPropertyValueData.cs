using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Model;

namespace WebShop.Interfaces
{
    public interface IPropertyValueData
    {
        PropertyValueModel InsertProperty(PropertyValueModel propertyValue);
        PropertyValueModel UpdateProperty(PropertyValueModel propertyValue);
        List<PropertyValueModel> SelectAllPropertyValues();
        PropertyValueModel SelectPropertyValue(PropertyValueModel property);
        List<PropertyValueModel> SelectPropertyValuesByPropertyId(PropertyListModel property);
        bool DeletePropertyValue(PropertyValueModel propertyValue);
    }
}
