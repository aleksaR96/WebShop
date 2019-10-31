using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WebShop.Data
{
    public class BaseData
    {
        private string connectionString;

        //readonly property
        protected string ConnectionString {
            get { return connectionString; }
        }

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        protected BaseData()
        {
            connectionString = "Server=BEL-STESIM-LT01\\SQLEXPRESS03;Database=WebShop;Trusted_Connection=true";
        }

        //vraca sqlconnection, otvara konekciju sa bazom ako vec nije
        protected SqlConnection createConnection ()
        {
            //kreira obj konekcije
            sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                //otvara konekciju ako vec nije
                sqlConnection.Open();
                return sqlConnection;
            }
            else
            {
                return null;
            }
        }

        //zatvara konekciju
        protected void closeConnection()
        {
            sqlConnection.Close();
        }

        //kreira sqlcommand i definise tip komande
        protected SqlCommand createSqlCommandSP(string spName)
        {
            sqlCommand = new SqlCommand(spName, sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            return sqlCommand;
        }

        //vraca sqldatareader
        protected SqlDataReader getSqlDataReader()
        {
            return sqlCommand.ExecuteReader();
        }
    }
}
