using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Data
{
    public class PropertyValueData : BaseData, IPropertyValueData
    {
        public bool DeletePropertyValue(PropertyValueModel propertyValue)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeletePropertyValue");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyValue.ID));

                var num = sqlCommand.ExecuteNonQuery();
                propertyValue.State = ModelState.Deleted;

                base.closeConnection();
                return (num > 0) ? true : false;
            }
        }

        public PropertyValueModel InsertProperty(PropertyValueModel propertyValue)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertPropertyValue");
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", propertyValue.PropertyID));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", propertyValue.Value));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                PropertyValueModel output = null;

                while(sqlDataReader.Read())
                {
                    output = new PropertyValueModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.Value = sqlDataReader["Value"].ToString();
                    output.State = ModelState.Inserted;
                }

                base.closeConnection();
                return output;
            }
        }

        public List<PropertyValueModel> SelectAllPropertyValues()
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectAllPropertyValues");

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<PropertyValueModel> outputList = new List<PropertyValueModel>();
                PropertyValueModel output = null;

                while(sqlDataReader.Read())
                {
                    output = new PropertyValueModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.Value = sqlDataReader["Value"].ToString();
                    output.State = ModelState.Selected;

                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public PropertyValueModel SelectPropertyValue(PropertyValueModel propertyValue)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectPropertyValue");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyValue.ID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                PropertyValueModel output = null;

                while(sqlDataReader.Read())
                {
                    output = new PropertyValueModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.Value = sqlDataReader["Value"].ToString();
                    output.State = ModelState.Selected;
                }

                base.closeConnection();
                return output;
            }
        }

        public List<PropertyValueModel> SelectPropertyValuesByPropertyId(PropertyListModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectPropertyValuesByPropertyID");
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", property.PropertyID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                List<PropertyValueModel> outputList = new List<PropertyValueModel>();
                PropertyValueModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new PropertyValueModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.Value = sqlDataReader["Value"].ToString();
                    output.State = ModelState.Selected;

                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public PropertyValueModel UpdateProperty(PropertyValueModel propertyValue)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdatePropertyValue");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyValue.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", propertyValue.PropertyID));
                sqlCommand.Parameters.Add(new SqlParameter("@Value", propertyValue.Value));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                PropertyValueModel output = null;

                while(sqlDataReader.Read())
                {
                    output = new PropertyValueModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.Value = sqlDataReader["Value"].ToString();
                    output.State = ModelState.Updated;
                }

                base.closeConnection();
                return output;
            }
        }
    }
}
