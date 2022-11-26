using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public interface IDatabaseOperations
    {
        int ExecuteNonQuery(string sqlQuery, List<SqlParameter> sqlParameter = null);

        DataSet FetchData(string sqlQuery, List<SqlParameter> sqlParameters=null);
    }
}
