using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Model;

namespace WebShop.Data
{
    public class OrderProductsData : BaseData, IOrderProductsData
    {
        public List<OrderProductsModel> SelectAll()
        {
            using (SqlConnection sqlConnection = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllOrderProducts");
                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<OrderProductsModel> outputList = new List<OrderProductsModel>();
                OrderProductsModel output;

                while (sqlDataReader.Read())
                {
                    output = new OrderProductsModel();
                    output.OrderProductsID = sqlDataReader.GetInt32(0);
                    output.OrderID = sqlDataReader.GetInt32(1);
                    output.ProductID = sqlDataReader.GetInt32(2);
                    output.Price = sqlDataReader.GetFloat(4);
                    output.Quantity = sqlDataReader.GetInt32(3);
                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();

                return outputList;
            }
        }

        public void Select(OrderProductsModel productsModel)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectOrderProductsByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", productsModel.OrderProductsID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while (sqlDataReader.Read())
                {
                    productsModel.OrderProductsID = sqlDataReader.GetInt32(0);
                    productsModel.OrderID = sqlDataReader.GetInt32(1);
                    productsModel.ProductID = sqlDataReader.GetInt32(2);
                    productsModel.Quantity = sqlDataReader.GetInt32(3);
                    productsModel.Price = sqlDataReader.GetFloat(4);
                }

                productsModel.State = ModelState.Selected;
                base.closeConnection();
            }
        }

        public bool Insert(OrderProductsModel newOrderProducts)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertIntoOrderProducts");
                sqlCommand.Parameters.Add(new SqlParameter("@OrderProductsID", newOrderProducts.OrderProductsID));
                sqlCommand.Parameters.Add(new SqlParameter("@OrderID", newOrderProducts.OrderID));
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", newOrderProducts.ProductID));
                sqlCommand.Parameters.Add(new SqlParameter("@Quantity", newOrderProducts.Quantity));
                sqlCommand.Parameters.Add(new SqlParameter("@Price", newOrderProducts.Price));

                int num = sqlCommand.ExecuteNonQuery();
                newOrderProducts.State = ModelState.Inserted;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool Update(OrderProductsModel newOrderProducts)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateOrderProductsByID");
                sqlCommand.Parameters.Add(new SqlParameter("@OrderProductsID", newOrderProducts.OrderProductsID));
                sqlCommand.Parameters.Add(new SqlParameter("@OrderID", newOrderProducts.OrderID));
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", newOrderProducts.ProductID));
                sqlCommand.Parameters.Add(new SqlParameter("@Quantity", newOrderProducts.Quantity));
                sqlCommand.Parameters.Add(new SqlParameter("@Price", newOrderProducts.Price));

                int num = sqlCommand.ExecuteNonQuery();
                newOrderProducts.State = ModelState.Updated;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool Delete(OrderProductsModel orderProducts) {

            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteOrderProductsByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", orderProducts.OrderProductsID));

                int num = sqlCommand.ExecuteNonQuery();
                orderProducts.State = ModelState.Deleted;
                base.closeConnection();
                return (num > 0) ? true : false;
            }
        }
    }
}
