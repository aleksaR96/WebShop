using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class OrdersModel : BaseModel
    {
        public int? OrderID { get; set; }
        public int UserID { get; set; }
        public int TotalQuantity { get; set; }
        public float TotalPrice { get; set; }

        public OrdersModel(int userID, int totalQuantity, float totalPrice)
        {
            OrderID = null;
            UserID = userID;
            TotalQuantity = totalQuantity;
            TotalPrice = totalPrice;
        }

        public OrdersModel()
        {
        }

        public override string ToString()
        {
            return OrderID + " " + UserID + " " + TotalQuantity + " " + TotalPrice + " " + base.ToString();
        }
    }
}
