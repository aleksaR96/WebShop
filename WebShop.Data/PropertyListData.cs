using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Data
{
    public class PropertyListData : BaseData, IPropertyListData
    {
        public PropertyListModel SelectPropertyByPropertyID(PropertyModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectPropertyByPropertyID");
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", property.PropertyID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                PropertyListModel output = new PropertyListModel();

                while(sqlDataReader.Read())
                {
                    output.PropertyID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.GroupID = Convert.ToInt32(sqlDataReader["GroupID"]);
                    output.Value = sqlDataReader["Name"].ToString();
                    output.State = ModelState.Selected;
                }

                base.closeConnection();
                return output;
            }
        }
    }
}
