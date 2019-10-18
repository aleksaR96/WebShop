using System.Collections.Generic;
using WebShop.Model;

namespace WebShop.Data
{
    public interface IOrdersData
    {
        bool Delete(OrdersModel order);
        bool Insert(OrdersModel newOrder);
        void Select(OrdersModel order);
        List<OrdersModel> SelectAll();
        bool Update(OrdersModel newOrder);
    }
}