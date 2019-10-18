using System.Collections.Generic;
using WebShop.Model;

namespace WebShop.Data
{
    public interface IUsersData
    {
        bool Delete(UsersModel user);
        bool Insert(UsersModel newUser);
        void Select(UsersModel user);
        List<UsersModel> SelectAll();
        bool Update(UsersModel newUser);
    }
}