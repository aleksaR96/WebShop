using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Model;

namespace WebShop.Data
{
    public class ProductsData : BaseData, IProductsData
    {
        public List<ProductsModel> SelectAll()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllProducts");

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                while (sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();

                return outputList;
            }
        }

        public ProductsModel Select(ProductsModel product)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectProductByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", product.ProductID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while (sqlDataReader.Read())
                {
                    product.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    product.Name = sqlDataReader["Name"].ToString();
                    product.Description = sqlDataReader["Description"].ToString();
                    product.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    product.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    product.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    product.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    product.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    product.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    product.New = Convert.ToByte(sqlDataReader["New"]);
                    product.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    product.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    product.State = ModelState.Selected;
                }
                
                base.closeConnection();
                return product;
            }
        }

        public ProductsModel SelectByName(ProductsModel product)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectProductByName");
                sqlCommand.Parameters.Add(new SqlParameter("@Name", product.Name));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while (sqlDataReader.Read())
                {
                    product.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    product.Name = sqlDataReader["Name"].ToString();
                    product.Description = sqlDataReader["Description"].ToString();
                    product.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    product.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    product.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    product.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    product.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    product.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    product.New = Convert.ToByte(sqlDataReader["New"]);
                    product.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    product.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    product.State = ModelState.Selected;
                }

                base.closeConnection();
                return product;
            }
        }

        public bool Insert(ProductsModel newProduct)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertIntoProducts");
                sqlCommand.Parameters.Add(new SqlParameter("@Name", newProduct.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@Description", newProduct.Description));
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", newProduct.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@Price", newProduct.Price));
                sqlCommand.Parameters.Add(new SqlParameter("@Quantity", newProduct.Quantity));
                sqlCommand.Parameters.Add(new SqlParameter("@BrandID", newProduct.BrandID));
                sqlCommand.Parameters.Add(new SqlParameter("@Pinned", newProduct.Pinned));
                sqlCommand.Parameters.Add(new SqlParameter("@Discount", newProduct.Discount));
                sqlCommand.Parameters.Add(new SqlParameter("@New", newProduct.New));
                sqlCommand.Parameters.Add(new SqlParameter("@Popular", newProduct.Popular));
                sqlCommand.Parameters.Add(new SqlParameter("@EAN", newProduct.EAN));

                int num = sqlCommand.ExecuteNonQuery();
                newProduct.State = ModelState.Inserted;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool Update(ProductsModel product)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateProductsByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", product.ProductID));
                sqlCommand.Parameters.Add(new SqlParameter("@Name", product.Name));
                sqlCommand.Parameters.Add(new SqlParameter("@Description", product.Description));
                sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", product.CategoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@Price", product.Price));
                sqlCommand.Parameters.Add(new SqlParameter("@Quantity", product.Quantity));
                sqlCommand.Parameters.Add(new SqlParameter("@BrandID", product.BrandID));
                sqlCommand.Parameters.Add(new SqlParameter("@Pinned", product.Pinned));
                sqlCommand.Parameters.Add(new SqlParameter("@Discount", product.Discount));
                sqlCommand.Parameters.Add(new SqlParameter("@New", product.New));
                sqlCommand.Parameters.Add(new SqlParameter("@Popular", product.Popular));
                sqlCommand.Parameters.Add(new SqlParameter("@EAN", product.EAN));

                int num = sqlCommand.ExecuteNonQuery();
                product.State = ModelState.Updated;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool Delete(ProductsModel product)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteProductsByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", product.ProductID));

                int num = sqlCommand.ExecuteNonQuery();
                product.State = ModelState.Deleted;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public List<ProductsModel> SelectProductsByCategoryID(int id)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectProductsByCategoryID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", id));


                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                while (sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);
                    output.State = ModelState.Selected;

                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public List<ProductsModel> SelectAllPinnedDiscountProducts()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllPinnedDiscountProducts");
                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                while (sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();

                return outputList;
            }
        }

        public List<ProductsModel> SelectAllPinnedNewProducts()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllPinnedNewProducts");
                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                while (sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();

                return outputList;
            }
        }

        public List<ProductsModel> SelectAllPinnedPopularProducts()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllPinnedPopularProducts");
                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                while (sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();

                return outputList;
            }
        }

        public List<ProductsModel> Select24ProductsWithOffset(int offset)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("Select24ProductsWithOffset");
                sqlCommand.Parameters.Add(new SqlParameter("@offset", offset));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                while(sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public List<ProductsModel> Select10ProductsWithOffset(int offset)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("Select10ProductsWithOffset");
                sqlCommand.Parameters.Add(new SqlParameter("@offset", offset));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                while (sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public List<ProductsModel> Select24ProductsByCategoryWithOffset(int categoryID, int offset)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("Select24ProductsFromCategoryWithOffset");
                sqlCommand.Parameters.Add(new SqlParameter("@categoryID", categoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@offset", offset));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                while (sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public List<ProductsModel> Select10ProductsByCategoryWithOffset(int categoryID, int offset)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("Select10ProductsFromCategoryWithOffset");
                sqlCommand.Parameters.Add(new SqlParameter("@categoryID", categoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@offset", offset));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                List<ProductsModel> outputList = new List<ProductsModel>();
                ProductsModel output;

                while (sqlDataReader.Read())
                {
                    output = new ProductsModel();
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();
                return outputList;
            }
        }

        public ProductsModel SelectOneProductByCategoryWithOffset(int categoryID, int offset)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectOneProductFromCategoryWithOffset");
                sqlCommand.Parameters.Add(new SqlParameter("@categoryID", categoryID));
                sqlCommand.Parameters.Add(new SqlParameter("@offset", offset));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                ProductsModel output = new ProductsModel();

                while (sqlDataReader.Read())
                {
                    output.ProductID = Convert.ToInt32(sqlDataReader["ProductID"]);
                    output.Name = sqlDataReader["Name"].ToString();
                    output.Description = sqlDataReader["Description"].ToString();
                    output.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                    output.Price = Convert.ToSingle(sqlDataReader["Price"]);
                    output.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    output.BrandID = Convert.ToInt32(sqlDataReader["BrandID"]);
                    output.Pinned = Convert.ToByte(sqlDataReader["Pinned"]);
                    output.Discount = Convert.ToInt32(sqlDataReader["Discount"]);
                    output.New = Convert.ToByte(sqlDataReader["New"]);
                    output.Popular = Convert.ToByte(sqlDataReader["Popular"]);
                    output.EAN = Convert.ToInt32(sqlDataReader["EAN"]);

                    output.State = ModelState.Selected;
                }

                base.closeConnection();
                return output;
            }
        }

        public int CountProductsByCategoryID(int categoryID)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("CountProductsByCategoryID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", categoryID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();
                int countedNum = 0;

                while(sqlDataReader.Read())
                {
                    countedNum = sqlDataReader.GetInt32(0);
                }

                base.closeConnection();
                return countedNum;
            }
        }
    }
}
