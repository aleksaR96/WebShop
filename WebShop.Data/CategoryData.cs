using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Model;

namespace WebShop.Data
{
    public class CategoryData : BaseData, ICategoryData
    {
        public List<CategoryModel> SelectAll()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllCategories");

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<CategoryModel> outputList = new List<CategoryModel>();
                CategoryModel output;

                //citanje iz baze
                while (sqlDataReader.Read())
                {
                    output = new CategoryModel(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3));
                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                //zatvaranje konekcije
                base.closeConnection();

                return outputList;
            }
        }

        public CategoryModel Select(CategoryModel category)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectCategoryByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", category.CategoryID));

                //citanje iz baze
                SqlDataReader sqlDataReader = base.getSqlDataReader();
                CategoryModel output = new CategoryModel();

                while (sqlDataReader.Read())
                {
                    output.CategoryID = sqlDataReader.GetInt32(0);
                    output.CategoryName = sqlDataReader.GetString(1);
                    output.Image = sqlDataReader.GetString(2);
                    output.Icon = sqlDataReader.GetString(3);
                    output.State = ModelState.Selected;
                }

                base.closeConnection();

                return output;
            }
        }

        public CategoryModel Insert(CategoryModel newCategory)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertIntoCategory");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", newCategory.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@Name", newCategory.CategoryName));
                sqlCommand.Parameters.Add(new SqlParameter("@Icon", newCategory.Icon));

                CategoryModel output = null;

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    output = Select(newCategory);
                    output.State = ModelState.Inserted;
                }
                base.closeConnection();
                return output;
            }
        }

        public bool Delete(CategoryModel category)
        {
            using (SqlConnection conn = base.createConnection())
            {             
                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteCategoryByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", category.CategoryID));

                int num = sqlCommand.ExecuteNonQuery();
                category.State = ModelState.Deleted;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public CategoryModel Update(CategoryModel category)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateCategoryByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", category.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", category.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@Name", category.CategoryName));
                sqlCommand.Parameters.Add(new SqlParameter("@Image", category.Image));
                sqlCommand.Parameters.Add(new SqlParameter("@Icon", category.Icon));

                CategoryModel output = null;

                //azuriranje iz baze
                if(sqlCommand.ExecuteNonQuery() > 0)
                {
                    output = Select(category);
                    category.State = ModelState.Updated;
                }
                
                base.closeConnection();
                return output;
                
            }
        }
    }
}
