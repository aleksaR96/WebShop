using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Data
{
    public class PropertiesData : BaseData, IPropertiesData
    {
        public List<PropertyModel> SelectAllPropertiesByProductID(ProductsModel product)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectAllPropertiesByProductID");
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", product.ProductID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                List<PropertyModel> outputList = new List<PropertyModel>();
                PropertyModel output;

                while(sqlDataReader.Read())
                {
                    output = new PropertyModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.Value = sqlDataReader["Value"].ToString();

                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public bool InsertProperty(PropertyModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertProperty");
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", property.ProductID));
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", property.PropertyID));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", property.Value));

                var num = sqlCommand.ExecuteNonQuery();

                base.closeConnection();
                property.State = ModelState.Inserted;
                return (num > 0) ? true : false;
            }
        }

        public bool UpdateProperty(PropertyModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateProperty");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", property.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", property.ProductID));
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", property.PropertyID));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", property.Value));

                var num = sqlCommand.ExecuteNonQuery();
                base.closeConnection();
                property.State = ModelState.Updated;
                return (num > 0) ? true : false;

            }
        }

        public bool UpdatePropertyByProductIDAndPropertyID(PropertyModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {

                SqlCommand sqlCommand = base.createSqlCommandSP("UpdatePropertyByProductIDAndPropertyID");
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", property.ProductID));
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", property.PropertyID));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", property.Value));

                var num = sqlCommand.ExecuteNonQuery();
                base.closeConnection();
                property.State = ModelState.Updated;
                return (num > 0) ? true : false;
            }
        }

        public List<PropertyModel> SelectPropertyByProductIDAndPropertyID(ProductsModel product, List<FeaturedPropertyModel> featuredProperties)
        {
            using (SqlConnection conn = base.createConnection())
            {
                List<PropertyModel> outputList = new List<PropertyModel>();
                PropertyModel output = null;

                foreach (var prop in featuredProperties)
                {
                    //poziva SP za svaki FP i dodaje u listu koju vraca
                    output = new PropertyModel();
                    SqlCommand sqlCommand = base.createSqlCommandSP("SelectPropertyByProductIDAndPropertyID");
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductID", product.ProductID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", prop.PropertyID));

                    SqlDataReader sqlDataReader = base.getSqlDataReader();

                    while(sqlDataReader.Read())
                    {
                        output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                        output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                        output.Value = sqlDataReader["Value"].ToString();

                        output.State = ModelState.Selected;

                        outputList.Add(output);
                    }
                }

                base.closeConnection();
                return outputList;
            }
        }
    }
}
