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
        public bool Delete(PropertyListModel propertyList)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeletePropertyList");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyList.PropertyID));

                var num = sqlCommand.ExecuteNonQuery();

                base.closeConnection();
                return (num > 0) ? true : false;
            }
        }

        public PropertyListModel Insert(PropertyListModel propertyList)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertPropertyList");
                sqlCommand.Parameters.Add(new SqlParameter("@Name", propertyList.Value));
                sqlCommand.Parameters.Add(new SqlParameter("@GroupID", propertyList.GroupID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                PropertyListModel output = null;

                while(sqlDataReader.Read())
                {
                    output = new PropertyListModel();

                    output.Value = sqlDataReader["Name"].ToString();
                    output.PropertyID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.GroupID = Convert.ToInt32(sqlDataReader["GroupID"]);

                    output.State = ModelState.Inserted;
                }

                base.closeConnection();
                return output;
            }
        }

        public PropertyListModel Select(PropertyListModel propertyList)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectPropertyList");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyList.PropertyID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                PropertyListModel output = null;

                while(sqlDataReader.Read())
                {
                    output = new PropertyListModel();

                    output.Value = sqlDataReader["Name"].ToString();
                    output.GroupID = Convert.ToInt32(sqlDataReader["GroupID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["ID"]);

                    output.State = ModelState.Selected;
                }

                base.closeConnection();
                return output;
            }
        }

        public List<PropertyListModel> SelectAll()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllPropertyList");
                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<PropertyListModel> outputList = new List<PropertyListModel>();
                PropertyListModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new PropertyListModel();

                    output.Value = sqlDataReader["Name"].ToString();
                    output.PropertyID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.GroupID = Convert.ToInt32(sqlDataReader["GroupID"]);
                    output.State = ModelState.Selected;

                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

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

        public PropertyListModel Update(PropertyListModel propertyList)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdatePropertyList");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyList.PropertyID));
                sqlCommand.Parameters.Add(new SqlParameter("@Name", propertyList.Value));
                sqlCommand.Parameters.Add(new SqlParameter("@GroupID", propertyList.GroupID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                PropertyListModel output = null;

                while(sqlDataReader.Read())
                {
                    output = new PropertyListModel();
                    output.PropertyID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.GroupID = Convert.ToInt32(sqlDataReader["GroupID"]);
                    output.Value = sqlDataReader["Name"].ToString();

                    output.State = ModelState.Updated;
                }

                base.closeConnection();
                return output;
            }
        }

        public List<PropertyListModel> SelectPropertyListByPropertyGroup(PropertyGroupsModel propertyGroup)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectPropertyListByPropertyGroup");
                sqlCommand.Parameters.Add(new SqlParameter("@GroupID", propertyGroup.GroupID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<PropertyListModel> outputList = new List<PropertyListModel>();
                PropertyListModel output = null;

                while(sqlDataReader.Read())
                {
                    output = new PropertyListModel();
                    output.GroupID = Convert.ToInt32(sqlDataReader["GroupID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.Value = sqlDataReader["Name"].ToString();
                    output.State = ModelState.Selected;

                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }
    }
}
