using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace DataAccess
{
    public class DataAccessLayer
    {
        
        private readonly string _dbStr;

        public DataAccessLayer(string dbStr)
        {
            _dbStr = dbStr;
        }

        public DataSet getBooks()
        {
            //var a = ConfigurationManager.ConnectionStrings["dbConnection"].ToString();

            string ConnectionString = _dbStr;
            //String ConnectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            SqlConnection objConnection = new SqlConnection(_dbStr);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("select * from BooksTable", objConnection);
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConnection.Close();
            return objDataSet;
        }

        public DataSet getBooks(string bName)
        {

            string ConnectionString = _dbStr;
            SqlConnection objConnection = new SqlConnection(ConnectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("select * from BooksTable where Book='"+bName+"'", objConnection);
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConnection.Close();
            return objDataSet;
        }

        public DataSet getBooks(int id)
        {

            string ConnectionString = _dbStr;
            SqlConnection objConnection = new SqlConnection(ConnectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("select * from BooksTable where ID='" + id + "'", objConnection);
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConnection.Close();
            return objDataSet;
        }


        public bool addBook(string bName,
                                string bAuthor,
                                int bYear,
                                string bDesc,
                                int bISBN)
        {

            string ConnectionString = _dbStr;
            SqlConnection objConnection = new SqlConnection(ConnectionString);
            objConnection.Open();
            try
            {
                SqlCommand objCommand = new SqlCommand
                    ("insert into BooksTable values('" + bName + "','" + bAuthor + "'," + bYear + ",'" + bDesc + "'," + bISBN + ")", objConnection);
                DataSet objDataSet = new DataSet();
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objDataSet);
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                objConnection.Close();
            }
            return true;
        }


        public int updateBook(int id, string bName,
                                string bAuthor,
                                int bYear,
                                string bDesc,
                                int bISBN)
        {

            string ConnectionString = _dbStr;
            SqlConnection objConnection = new SqlConnection(ConnectionString);
            objConnection.Open();
            try
            {
                SqlCommand objCommand = new SqlCommand
                    ("update BooksTable set Book='" + bName + "',Author='" + bAuthor + "',Year=" + bYear + ",Description='" + bDesc + "',ISBN=" + bISBN + " where ID='"+id+"'", objConnection);
                DataSet objDataSet = new DataSet();
                return objCommand.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                objConnection.Close();
            }

        }


        public int deleteBooks(int id)
        {

            string ConnectionString = _dbStr;
            SqlConnection objConnection = new SqlConnection(ConnectionString);
            objConnection.Open();
            try
            {
                SqlCommand objCommand = new SqlCommand("delete from BooksTable where ID='" + id + "'", objConnection);
                DataSet objDataSet = new DataSet();
                
                return objCommand.ExecuteNonQuery();

            }

            catch
            {
                throw new Exception("Some error occured");
            }
            finally
            {
                objConnection.Close();
            }
        }

        public DataSet loginUser(string user,string password)
        {
            string ConnectionString = _dbStr;
            SqlConnection objConnection = new SqlConnection(ConnectionString);
            objConnection.Open();

            SqlCommand objCommand = new SqlCommand("select * from lUsers where username='" + user + "' and passwd='"+password+"'", objConnection);
            DataSet objDataSet = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConnection.Close();

            return objDataSet;



        }
    }
}
