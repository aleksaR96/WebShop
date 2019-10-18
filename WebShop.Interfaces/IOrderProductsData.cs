using System.Collections.Generic;
using WebShop.Model;

namespace WebShop.Data
{
    public interface IOrderProductsData
    {
        bool Delete(OrderProductsModel orderProducts);
        bool Insert(OrderProductsModel newOrderProducts);
        void Select(OrderProductsModel productsModel);
        List<OrderProductsModel> SelectAll();
        bool Update(OrderProductsModel newOrderProducts);
    }
}