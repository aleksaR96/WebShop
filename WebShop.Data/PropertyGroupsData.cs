using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Data
{
    class PropertyGroupsData : BaseData, IPropertyGroups
    {
        public bool Delete(PropertyGroupsModel propertyGroup)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeletePropertyGroup");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyGroup.GroupID));

                var num = sqlCommand.ExecuteNonQuery();

                propertyGroup.State = ModelState.Deleted;

                base.closeConnection();
                return (num > 0) ? true : false;
            }
        }

        public PropertyGroupsModel Insert(PropertyGroupsModel propertyGroup)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertPropertyGroup");
                sqlCommand.Parameters.Add(new SqlParameter("@Name", propertyGroup.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", propertyGroup.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@Alias", propertyGroup.Alias));
                sqlCommand.Parameters.Add(new SqlParameter("@SupGroup", propertyGroup.SupGroup));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                PropertyGroupsModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new PropertyGroupsModel();
                    output.GroupID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.SupGroup = Convert.ToInt32(sqlDataReader["SupGroup"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Alias = sqlDataReader["Alias"].ToString();
                    output.State = ModelState.Inserted;
                }

                base.closeConnection();
                return output;
            }
        }

        public PropertyGroupsModel Select(PropertyGroupsModel propertyGroup)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectPropertyGroup");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyGroup.GroupID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                PropertyGroupsModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new PropertyGroupsModel();
                    output.GroupID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.SupGroup = Convert.ToInt32(sqlDataReader["SupGroup"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Alias = sqlDataReader["Alias"].ToString();
                    output.State = ModelState.Selected;
                }

                base.closeConnection();
                return output;
            }
        }

        public List<PropertyGroupsModel> SelectAll()
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectAllPropertyGroups");

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                List<PropertyGroupsModel> outputList = new List<PropertyGroupsModel>();
                PropertyGroupsModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new PropertyGroupsModel();
                    output.GroupID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.SupGroup = Convert.ToInt32(sqlDataReader["SupGroup"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Alias = sqlDataReader["Alias"].ToString();
                    output.State = ModelState.Selected;

                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public PropertyGroupsModel Update(PropertyGroupsModel propertyGroup)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdatePropertyGroup");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", propertyGroup.GroupID));
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", propertyGroup.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@SupGroup", propertyGroup.SupGroup));
                sqlCommand.Parameters.Add(new SqlParameter("@Name", propertyGroup.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@Alias", propertyGroup.Alias));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                PropertyGroupsModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new PropertyGroupsModel();
                    output.GroupID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.SupGroup = Convert.ToInt32(sqlDataReader["SupGroup"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Alias = sqlDataReader["Alias"].ToString();
                    output.State = ModelState.Updated;
                }

                base.closeConnection();
                return output;
            }
        }
    }
}
