using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace MiddleTier
{
    public class Book : IMiddleLayer
    {
        [Required(ErrorMessage ="Name Cannot Be Empty")]
        public string bName { get; set; }
        //private string _bName = "";

        [Key]
        public int ID { get; set; }

        /*public string bName
        {
            get => _bName;
            set
            {
                if (value.Length == 0)
                    throw new Exception("cannot be zero");
                _bName = value;

            }
        }*/
        public string bAuthor { get; set; }
        public int bYear { get; set; }
        [StringLength(1000,ErrorMessage ="Desc cannot contain >1000 chars ")]
        public string bDescription { get; set; }
        public int bISBN { get; set; }

        private readonly string _dbStr;

        public Book(string dbStr)
        {
            _dbStr = dbStr;

    }

        public Book()
        {
            

        }

        public Book(string dbStr,int id, string name, string author, int year, string description, int isbn)
        {
            _dbStr=dbStr;
            ID = id;
            bName = name;
            bAuthor = author;
            bYear = year;
            bDescription = description;
            bISBN = isbn;
        }

        public Book(string dbStr,string name, string author, int year, string description, int isbn)
        {
            _dbStr =dbStr;
            bName = name;
            bAuthor = author;
            bYear = year;
            bDescription = description;
            bISBN = isbn;
        }



        public int Save()
        {
            IDatabaseOperations obj = new DatabaseOperations(_dbStr);
            List<SqlParameter> sqlParameters = new List<SqlParameter>() {

                new SqlParameter() {ParameterName="@bookName" , Value=bName },
                new SqlParameter() { ParameterName ="bookAuthor" , Value =bAuthor },
                new SqlParameter() { ParameterName ="@bookYear" , Value =bYear },
                new SqlParameter() { ParameterName = "@bookDescription", Value =bDescription },
                new SqlParameter() { ParameterName = "@bookISBN", Value =bISBN },
                };


            int res = obj.ExecuteNonQuery(SQLQueries.CreateRecord,sqlParameters);
            

            return res;
        }

        public DataSet Load()
        {
            IDatabaseOperations obj = new DatabaseOperations(_dbStr);

            return obj.FetchData(SQLQueries.GetAllData);
        }
        public DataSet Load(string a)
        {

            IDatabaseOperations obj = new DatabaseOperations(_dbStr);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("bookName", a));




            return obj.FetchData(SQLQueries.GetDataByName, sqlParameters);
        }

        
        public DataSet Load(int a)
        {
            IDatabaseOperations obj = new DatabaseOperations(_dbStr);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("bookId", a));




            return obj.FetchData(SQLQueries.GetDataById,sqlParameters);
        }




        public int Delete(int id)
        {
            IDatabaseOperations obj = new DatabaseOperations(_dbStr);
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter(){ParameterName="@bookId",Value=id}
            };
            int res = obj.ExecuteNonQuery(SQLQueries.DeleteRecord,sqlParameters);
            return res;
        }


        public int Update()
        {
            IDatabaseOperations obj = new DatabaseOperations(_dbStr);
            List<SqlParameter> sqlParameters = new List<SqlParameter>() {
                new SqlParameter(){ParameterName="@bookId", Value=ID},
                new SqlParameter() {ParameterName="@bookName" , Value=bName },
                new SqlParameter() { ParameterName ="bookAuthor" , Value =bAuthor },
                new SqlParameter() { ParameterName ="@bookYear" , Value =bYear },
                new SqlParameter() { ParameterName = "@bookDescription", Value =bDescription },
                new SqlParameter() { ParameterName = "@bookISBN", Value =bISBN },
                };
            int affected = obj.ExecuteNonQuery(SQLQueries.UpdateRecord,sqlParameters);

            return affected;
        }









    }
}
