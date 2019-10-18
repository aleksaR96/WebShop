using System.Collections.Generic;
using WebShop.Model;

namespace WebShop.Data
{
    public interface IData
    {
        object SelectAll();
        void Select(object o);
        bool Insert(object o);
        bool Update(object o);
        bool Delete(object o);
    }
}