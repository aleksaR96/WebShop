using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Business
{
    public class PropertyListBusiness
    {
        public List<PropertyListModel> GetAllPropertyList()
        {
            IPropertyListData ipld = new PropertyListData();
            IPropertyValueData ipvd = new PropertyValueData();

            List<PropertyListModel> propertyList = ipld.SelectAll();

            foreach (PropertyListModel property in propertyList)
            {
                property.Values = ipvd.SelectPropertyValuesByPropertyId(new PropertyListModel(property.PropertyID));
            }

            return propertyList;            
        }
        public PropertyListModel GetPropertyList(PropertyListModel propertyList)
        {
            IPropertyListData pld = new PropertyListData();
            IPropertyValueData ipvd = new PropertyValueData();

            PropertyListModel property = pld.SelectPropertyByPropertyID(new PropertyModel(propertyList.PropertyID));
            property.Values = ipvd.SelectPropertyValuesByPropertyId(propertyList);

            return property;
        }
        public PropertyListModel AddPropertyList(PropertyListModel propertyList)
        {
            IPropertyListData pld = new PropertyListData();
            IPropertyValueData pvd = new PropertyValueData();
            PropertyListModel output = null;

            using(TransactionScope scope = new TransactionScope())
            {
                try
                {
                    output = pld.Insert(propertyList);
                    output.Values = new List<PropertyValueModel>();
                    foreach(PropertyValueModel value in propertyList.Values)
                    {
                        output.Values.Add(pvd.InsertProperty(new PropertyValueModel(output.PropertyID, value.Value)));
                    }
                    scope.Complete();
                }
                catch(TransactionAbortedException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return output;
        }
        public PropertyListModel EditPropertyList(PropertyListModel propertyList)
        {
            IPropertyListData pld = new PropertyListData();
            IPropertyValueData pvd = new PropertyValueData();
            PropertyListModel output = null;

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    output = pld.Update(propertyList);
                    output.Values = new List<PropertyValueModel>();
                    foreach (PropertyValueModel property in propertyList.Values)
                    {
                        output.Values.Add(pvd.UpdateProperty(property));
                    }
                    scope.Complete();
                }
                catch(TransactionAbortedException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return output;
        }
        public List<PropertyListModel> GetAllPropertyListByPropertyGroup(PropertyGroupsModel propertyGroup)
        {
            IPropertyListData pld = new PropertyListData();
            IPropertyValueData pvd = new PropertyValueData();

            List<PropertyListModel> outputList = pld.SelectPropertyListByPropertyGroup(propertyGroup);

            foreach(var property in outputList)
            {
                property.Values = pvd.SelectPropertyValuesByPropertyId(property);
            }
            return outputList;
        }
    }
}
