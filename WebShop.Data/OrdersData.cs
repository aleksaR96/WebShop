using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Model;

namespace WebShop.Data
{
    public class OrdersData : BaseData, IOrdersData
    {
        public List<OrdersModel> SelectAll()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllOrders");

                List<OrdersModel> outputList = new List<OrdersModel>();
                OrdersModel output;

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while (sqlDataReader.Read())
                {
                    output = new OrdersModel();
                    output.OrderID = sqlDataReader.GetInt32(0);
                    output.UserID = sqlDataReader.GetInt32(1);
                    output.TotalQuantity = sqlDataReader.GetInt32(2);
                    output.TotalPrice = sqlDataReader.GetFloat(3);
                    output.State = ModelState.Selected;
                    outputList.Add(output);

                }

                base.closeConnection();
                return outputList;
            }
        }

        public void Select(OrdersModel order)
        {
            using (SqlConnection conn = base.createConnection())
            {

                base.createSqlCommandSP("SelectOrderByID").Parameters.Add(new SqlParameter("@ID", order.OrderID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while (sqlDataReader.Read())
                {
                    order.OrderID = sqlDataReader.GetInt32(0);
                    order.UserID = sqlDataReader.GetInt32(1);
                    order.TotalPrice = sqlDataReader.GetFloat(3);
                    order.TotalQuantity = sqlDataReader.GetInt32(2);
                }
                order.State = ModelState.Selected;
                base.closeConnection();
            }

        }

        public bool Delete(OrdersModel order)
        {
            using (SqlConnection conn = base.createConnection())
            {

                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteOrdersByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", order.OrderID));

                int num = sqlCommand.ExecuteNonQuery();
                order.State = ModelState.Deleted;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool Update(OrdersModel newOrder)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateOrdersByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", newOrder.OrderID));
                sqlCommand.Parameters.Add(new SqlParameter("@UserID", newOrder.UserID));
                sqlCommand.Parameters.Add(new SqlParameter("@TotalPrice", newOrder.TotalPrice));
                sqlCommand.Parameters.Add(new SqlParameter("@TotalQuantity", newOrder.TotalQuantity));

                int num = sqlCommand.ExecuteNonQuery();
                newOrder.State = ModelState.Updated;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool Insert(OrdersModel newOrder)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertIntoOrders");
                sqlCommand.Parameters.Add(new SqlParameter("@UserID", newOrder.UserID));
                sqlCommand.Parameters.Add(new SqlParameter("@TotalPrice", newOrder.TotalPrice));
                sqlCommand.Parameters.Add(new SqlParameter("@TotalQuantity", newOrder.TotalQuantity));

                int num = sqlCommand.ExecuteNonQuery();
                newOrder.State = ModelState.Inserted;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }
    }
}
