using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Data
{
    public class ImagesData : BaseData, IImagesData
    {
        public bool Delete(ImageModel image)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteImageByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", image.ImageID));

                var num = sqlCommand.ExecuteNonQuery();

                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool DeleteByProductID(ProductsModel product)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteImageByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", product.ProductID));

                var num = sqlCommand.ExecuteNonQuery();

                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool Insert(ImageModel newImage)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertImage");
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", newImage.ProductID));

                var num = sqlCommand.ExecuteNonQuery();

                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public ImageModel Select(ImageModel image)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectImageByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", image.ImageID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                ImageModel output = new ImageModel();

                while (sqlDataReader.Read())
                {
                    output.ImageID = Convert.ToInt32(sqlDataReader["ImageID"]);
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Image = sqlDataReader["Image"].ToString();

                    output.State = ModelState.Selected;

                }

                base.closeConnection();

                return output;
            }
        }

        public List<ImageModel> SelectAll()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectImageByID");

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                ImageModel output;
                List<ImageModel> outputList = new List<ImageModel>();

                while (sqlDataReader.Read())
                {
                    output = new ImageModel();
                    output.ImageID = Convert.ToInt32(sqlDataReader["ImageID"]);
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Image = sqlDataReader["Image"].ToString();

                    output.State = ModelState.Selected;

                    outputList.Add(output);
                }

                base.closeConnection();

                return outputList;
            }
        }

        public List<ImageModel> SelectByProductID(ProductsModel product)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectImageByProductID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", product.ProductID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                ImageModel output;
                List<ImageModel> outputList = new List<ImageModel>();

                while (sqlDataReader.Read())
                {
                    output = new ImageModel();
                    output.ImageID = Convert.ToInt32(sqlDataReader["ImageID"]);
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Image = sqlDataReader["Image"].ToString();

                    output.State = ModelState.Selected;

                    outputList.Add(output);
                }

                base.closeConnection();

                return outputList;
            }
        }

        public bool Update(ImageModel image)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateImage");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", image.ImageID));
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", image.ProductID));
                sqlCommand.Parameters.Add(new SqlParameter("@Image", image.Image));

                var num = sqlCommand.ExecuteNonQuery();

                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool UpdateByProduct(ImageModel image)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateImageByProductID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", image.ImageID));
                sqlCommand.Parameters.Add(new SqlParameter("@ProductID", image.ProductID));
                sqlCommand.Parameters.Add(new SqlParameter("@Image", image.Image));

                var num = sqlCommand.ExecuteNonQuery();

                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }
    }
}
