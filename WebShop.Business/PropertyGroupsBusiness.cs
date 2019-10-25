using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Business
{
    public class PropertyGroupsBusiness
    {
        public List<PropertyGroupsModel> GetAllPropertyGroups()
        {
            IPropertyGroupsData pg = new PropertyGroupsData();
            return pg.SelectAll();
        }

        public PropertyGroupsModel GetPropertyGroups(PropertyGroupsModel propertyGroups)
        {
            IPropertyGroupsData pg = new PropertyGroupsData();
            return pg.Select(propertyGroups);
        }

        public PropertyGroupsModel AddPropertyGroups(PropertyGroupsModel propertyGroups)
        {
            IPropertyGroupsData pg = new PropertyGroupsData();
            
            PropertyGroupsModel output = null;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    output = pg.Insert(propertyGroups);
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return output;
        }

        public PropertyGroupsModel EditPropertyGroups(PropertyGroupsModel propertyGroups)
        {
            IPropertyGroupsData pg = new PropertyGroupsData();
            PropertyGroupsModel output = null;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    output = pg.Update(propertyGroups);
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }

        public List<PropertyGroupsModel> GetPropertyGroupsByCategoryID(CategoryModel category)
        {
            IPropertyGroupsData pg = new PropertyGroupsData();
            return pg.SelectByCategoryID(category);
        }
    }
}
