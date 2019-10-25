using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Data
{
    public class BrandsData : BaseData, IBrandsData
    {
        public bool Delete(BrandModel brand)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteBrand");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", brand.ID));

                var num = sqlCommand.ExecuteNonQuery();

                brand.State = ModelState.Deleted;

                base.closeConnection();
                return (num > 0) ? true : false;
            }
        }

        public BrandModel Insert(BrandModel newBrand)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertBrand");
                sqlCommand.Parameters.Add(new SqlParameter("@Name", newBrand.Name));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                BrandModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new BrandModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.State = ModelState.Inserted;
                }

                base.closeConnection();
                return output;
            }
        }

        public BrandModel Select(BrandModel brand)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectBrands");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", brand.ID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                BrandModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new BrandModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.State = ModelState.Selected;
                }

                base.closeConnection();
                return output;
            }
        }

        public List<BrandModel> SelectAll()
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectAllBrands");

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<BrandModel> outputList = new List<BrandModel>();
                BrandModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new BrandModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public BrandModel Update(BrandModel brand)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateBrand");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", brand.ID));
                sqlCommand.Parameters.Add(new SqlParameter("@Name", brand.Name));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                BrandModel output = null;

                while (sqlDataReader.Read())
                {
                    output = new BrandModel();
                    output.ID = Convert.ToInt32(sqlDataReader["ID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.State = ModelState.Updated;
                }

                base.closeConnection();
                return output;
            }
        }
    }
}
