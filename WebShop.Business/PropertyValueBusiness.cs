using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Business
{
    public class PropertyValueBusiness
    {
        public PropertyValueModel GetPropertyValue(PropertyValueModel propertyValue)
        {
            IPropertyValueData pvd = new PropertyValueData();
            return pvd.SelectPropertyValue(propertyValue);
        }

        public List<PropertyValueModel> GetAllPropertyValues()
        {
            IPropertyValueData pvd = new PropertyValueData();
            return pvd.SelectAllPropertyValues();
        }

        public List<PropertyValueModel> GetPropertyValuesByProperty(PropertyListModel property)
        {
            IPropertyValueData pvd = new PropertyValueData();
            return pvd.SelectPropertyValuesByPropertyId(property);
        }
    }
}
