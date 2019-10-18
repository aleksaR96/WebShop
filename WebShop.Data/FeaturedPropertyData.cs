using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Data
{
    class FeaturedPropertyData : BaseData, IFeaturedPropertyData
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

                FeaturedPropertyModel output = new FeaturedPropertyModel();

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while(sqlDataReader.Read())
                {
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.PropertyID = Convert.ToInt32(sqlDataReader["PropertyID"]);
                    output.State = ModelState.Selected;
                }

                base.closeConnection();
                return output;
            }
        }
        
    }
}
