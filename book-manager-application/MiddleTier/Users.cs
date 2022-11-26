using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess;

namespace MiddleTier
{
    public class Users
    {

        private bool _isAdmin = false;
        public string user { get; set; }
        public string password { get; set; }

        private string _dbStr;

        public bool isAdmin
        {
            get => _isAdmin;
        }

        public Users(string dbStr)
        {
            _dbStr = dbStr;
        }

        public Users(string dbStr, string un, string pswd)
        {
            user = un;
            password = pswd;
            _dbStr = dbStr;
        }





        public bool getUser()
        {
                IDatabaseOperations obj = new DatabaseOperations(_dbStr);

                List<SqlParameter> sqlParameters = new List<SqlParameter>() {
                    new SqlParameter() {ParameterName="@uname" , Value=user },
                    new SqlParameter() { ParameterName ="@psswd" , Value =password },
                    };

                DataSet isL= obj.FetchData(SQLQueries.GetUser,sqlParameters);

            
                if (isL.Tables[0].Rows.Count == 0)
                    return false;
                else
                {
                    _isAdmin = Convert.ToBoolean(isL.Tables[0].Rows[0]["isAdmin"]);
                    return true;
                }
            

        }
    }
}
