using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using WebShop.Model;

namespace WebShop.Data
{
    public class UsersData : BaseData, IUsersData
    {
        public List<UsersModel> SelectAll()
        {
            using (SqlConnection conn = base.createConnection())
            {
                base.createSqlCommandSP("SelectAllUsers");

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                List<UsersModel> outputList = new List<UsersModel>();
                UsersModel output;

                while (sqlDataReader.Read())
                {
                    output = new UsersModel();
                    output.UserID = Convert.ToInt32(sqlDataReader["UserID"]);
                    output.FirstName = sqlDataReader["FirstName"].ToString();
                    output.LastName = sqlDataReader["LastName"].ToString();
                    output.Address = sqlDataReader["Adress"].ToString();
                    output.Phone = sqlDataReader["Phone"].ToString();
                    output.City = sqlDataReader["City"].ToString();
                    output.Username = sqlDataReader["Username"].ToString();
                    output.Password = sqlDataReader["Password"].ToString();
                    output.Email = sqlDataReader["Email"].ToString();
                    output.UserType = Convert.ToByte(sqlDataReader["UserType"]);
                    output.State = ModelState.Selected;
                    outputList.Add(output);
                }

                base.closeConnection();

                return outputList;
            }
        }

        public void Select(UsersModel user)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("SelectUserByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", user.UserID));

                SqlDataReader sqlDataReader = base.getSqlDataReader();

                while (sqlDataReader.Read())
                {
                    user.UserID = sqlDataReader.GetInt32(0);
                    user.FirstName = sqlDataReader.GetString(1);
                    user.LastName = sqlDataReader.GetString(2);
                    user.Address = sqlDataReader.GetString(3);
                    user.Phone = sqlDataReader.GetString(4);
                    user.City = sqlDataReader.GetString(5);
                    user.Email = sqlDataReader["Email"].ToString();
                    user.Username = sqlDataReader["Username"].ToString();
                    user.Password = sqlDataReader["Password"].ToString();
                    user.UserType = Convert.ToByte(sqlDataReader["UserType"]);
                    user.State = ModelState.Selected;
                }

                base.closeConnection();
            }
        }

        public bool Insert(UsersModel newUser)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("InsertIntoUsers");
                sqlCommand.Parameters.Add(new SqlParameter("@FirstName", newUser.FirstName));
                sqlCommand.Parameters.Add(new SqlParameter("@LastName", newUser.LastName));
                sqlCommand.Parameters.Add(new SqlParameter("@Address", newUser.Address));
                sqlCommand.Parameters.Add(new SqlParameter("@Phone", newUser.Phone));
                sqlCommand.Parameters.Add(new SqlParameter("@City", newUser.City));
                sqlCommand.Parameters.Add(new SqlParameter("@Username", newUser.Username));
                sqlCommand.Parameters.Add(new SqlParameter("@Password", newUser.Password));
                sqlCommand.Parameters.Add(new SqlParameter("@Email", newUser.Email));
                sqlCommand.Parameters.Add(new SqlParameter("@UserType", newUser.UserType));

                int num = sqlCommand.ExecuteNonQuery();
                newUser.State = ModelState.Inserted;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }

        public bool Delete(UsersModel user)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("DeleteUsersByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", user.UserID));

                int num = sqlCommand.ExecuteNonQuery();
                user.State = ModelState.Deleted;
                base.closeConnection();
                return (num > 0) ? true : false;
            }
        }

        public bool Update(UsersModel newUser)
        {
            using (SqlConnection conn = base.createConnection())
            {
                SqlCommand sqlCommand = base.createSqlCommandSP("UpdateUserSByID");
                sqlCommand.Parameters.Add(new SqlParameter("@ID", newUser.UserID));
                sqlCommand.Parameters.Add(new SqlParameter("@FirstName", newUser.FirstName));
                sqlCommand.Parameters.Add(new SqlParameter("@LastName", newUser.LastName));
                sqlCommand.Parameters.Add(new SqlParameter("@Adress", newUser.Address));
                sqlCommand.Parameters.Add(new SqlParameter("@Phone", newUser.Phone));
                sqlCommand.Parameters.Add(new SqlParameter("@City", newUser.City));
                sqlCommand.Parameters.Add(new SqlParameter("@Username", newUser.Username));
                sqlCommand.Parameters.Add(new SqlParameter("@Password", newUser.Password));
                sqlCommand.Parameters.Add(new SqlParameter("@Email", newUser.Email));
                sqlCommand.Parameters.Add(new SqlParameter("@UserType", newUser.UserType));

                int num = sqlCommand.ExecuteNonQuery();
                newUser.State = ModelState.Updated;
                base.closeConnection();

                return (num > 0) ? true : false;
            }
        }
    }
}
