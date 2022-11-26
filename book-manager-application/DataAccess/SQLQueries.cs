using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public static class SQLQueries
    {
        public readonly static string GetAllData = "select * from BooksTable";
        public readonly static string GetDataById = "select * from BooksTable where ID= @bookId";
        public readonly static string GetDataByName = "select * from BooksTable where Book= @bookName";
        public readonly static string CreateRecord = "insert into BooksTable values(@bookName,@bookAuthor,@bookYear,@bookDescription,@bookISBN)";
        public readonly static string UpdateRecord = "update BooksTable set Book=@bookName,Author=@bookAuthor,Year=@bookYear,Description=@bookDescription,ISBN=@bookISBN where ID=@bookId";
        public readonly static string DeleteRecord = "delete from BooksTable where ID=@bookId";
        public readonly static string GetUser = "select * from lUsers where username=@uname and passwd=@psswd";
    }
}
