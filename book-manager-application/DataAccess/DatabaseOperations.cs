using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class DatabaseOperations : IDatabaseOperations
    {
        public SqlConnection sqlConnection { get;}



        public DatabaseOperations(string dbStr)
        {
            sqlConnection = new SqlConnection(dbStr);

        }

        void Open()
        {
            sqlConnection.Open();
        }

        void Close()
        {
            sqlConnection.Close();
        }

        public DataSet FetchData(string sqlQuery, List<SqlParameter> sqlParameters = null)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                if (sqlParameters != null)
                {
                    cmd.Parameters.AddRange(sqlParameters.ToArray());
                }
                Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                Close();
                return ds;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int ExecuteNonQuery(string sqlQuery, List<SqlParameter> sqlParameter = null)
        {
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery,
                        sqlConnection);
                if (sqlParameter != null)
                {
                    command.Parameters.AddRange(sqlParameter.ToArray());
                }
                Open();
                var result = command.ExecuteNonQuery();
                Close();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            
        }
    }
}
