using MiddleTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    class OtherOperations
    {
        public static List<Book> DsToList(DataSet ds)
        {
            

            List<Book> li = new List<Book>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                li.Add(
                    new Book()
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        bName = dr["Book"].ToString(),
                        bAuthor = dr["Author"].ToString(),
                        bYear = Convert.ToInt32(dr["Year"]),
                        bDescription = dr["Description"].ToString(),
                        bISBN = Convert.ToInt32(dr["ISBN"])
                    }
                    );

            }
            return li;

        }

    }
}
