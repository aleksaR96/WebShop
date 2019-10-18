using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class OrderProductsModel : BaseModel
    {
        public int OrderProductsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public OrderProductsModel(int orderID, int productID, int quantity, float price)
        {
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
            Price = price;
        }

        public OrderProductsModel()
        {
        }

        public override string ToString()
        {
            return OrderID + " " + ProductID + " " + Quantity + " " + Price + " " + base.ToString();
        }
    }
}
