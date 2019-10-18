using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Data
{
    public class FeaturedPropertyData : BaseData, IFeaturedPropertyData
    {
        public List<FeaturedPropertyModel> SelectAllFeaturedProperties()
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand =  base.createSqlCommandSP("SelectAllFeaturedProperties");

                List<FeaturedPropertyModel> outputList = new List<FeaturedPropertyModel>();
                FeaturedPropertyModel output;

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while(sqlDataReader.Read())
                {
                    output = new FeaturedPropertyModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public FeaturedPropertyModel SelectFeaturedPropertyByID(FeaturedPropertyModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectFeaturedPropertyByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", property.ID));

                FeaturedPropertyModel output = null;

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while(sqlDataReader.Read())
                {
                    output = new FeaturedPropertyModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.State = ModelState.Selected;
                }

                base.closeConnection();
                return output;
            }
        }

        public List<FeaturedPropertyModel> SelectFeaturedPropertiesByCategoryID(CategoryModel category)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectFeaturedPropertiesByCategoryID");
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", category.CategoryID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<FeaturedPropertyModel> outputList = new List<FeaturedPropertyModel>();
                FeaturedPropertyModel output;

                while(sqlDataReader.Read())
                {
                    output = new FeaturedPropertyModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }
        
        public FeaturedPropertyModel InsertFeaturedProperty(FeaturedPropertyModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertFeaturedProperty");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", property.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", property.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", property.PropertyID));

                FeaturedPropertyModel output = null;

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    output = SelectFeaturedPropertyByID(property);
                    output.State = ModelState.Inserted;
                }

                base.closeConnection();
                return output;
            }
        }

        public FeaturedPropertyModel UpdateFeaturedProperty(FeaturedPropertyModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateFeaturedProperty");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", property.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", property.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@PropertyID", property.PropertyID));

                FeaturedPropertyModel output = null;

                if(sqlCommand.ExecuteNonQuery() > 0)
                {
                    output = SelectFeaturedPropertyByID(property);
                    output.State = ModelState.Updated;
                }

                base.closeConnection();
                return output;
            }
        }

        public bool DeleteFeaturedProperty(FeaturedPropertyModel property)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteFeaturedProperty");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", property.ID));

                if(sqlCommand.ExecuteNonQuery() > 0)
                {
                    if(SelectFeaturedPropertyByID(property) == null)
                    {
                        base.closeConnection();
                        return true;
                    }
                }
                base.closeConnection();
                return false;
            }
        }
    }
}
