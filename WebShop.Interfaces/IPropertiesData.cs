using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Model;

namespace WebShop.Interfaces
{
    public interface IPropertiesData
    {
        bool InsertProperty(PropertyModel property);
        bool UpdateProperty(PropertyModel property);
        List<PropertyModel> SelectAllPropertiesByProductID(ProductsModel product);
        bool UpdatePropertyByProductIDAndPropertyID(PropertyModel property);
    }
}
