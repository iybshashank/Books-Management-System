using MiddleTier;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        
        public IConfiguration Configuration { get; }

        public BookController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //GET ALL RECORDS
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {

            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"));
            DataSet ds = obj.Load();

            List<Book> li = await Task.Run(() => OtherOperations.DsToList(ds));


            return li;

            //return JsonConvert.SerializeObject(ds.Tables[0]);
        }


       



        //GET RECORD BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Book>>> GetById(int id)
        {
            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"));
            DataSet ds = obj.Load(id);

            List<Book> li = await Task.Run(() => OtherOperations.DsToList(ds));

            return li;
        }

        //CREATE A RECORD
        [HttpPost("create")]
        public async Task<IActionResult> Post([Bind("ID,bName,bAuthor,bYear,bDescription,ISBN")] Book book)
        {

            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"), book.bName,book.bAuthor, book.bYear, book.bDescription, book.bISBN);
/*            Book obj = new Book(book.bName, book.bAuthor, Convert.ToInt32(bYear), bDescription, Convert.ToInt32(bISBN));
*/
            try
            {
               await Task.Run(()=> obj.Save());
            }
            catch
            {
                return new JsonResult("Some Error Occured");
            }

            return new JsonResult("Successfully Created");
            
        }


        //UPDATE A RECORD
        [HttpPut("update")]
        public async Task<IActionResult> Put([Bind("ID,bName,bAuthor,bYear,bDescription,ISBN")] Book book)
        {

            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"), book.ID,book.bName, book.bAuthor, book.bYear, book.bDescription, book.bISBN);

            try
            {
                int rowAffected = await Task.Run(() => obj.Update());

                return (rowAffected==0) ? 
                    new JsonResult("No records affected") : 
                    new JsonResult("Successfully Updated," + rowAffected + " Rows Affected") ;
                
            }

            catch
            {
                return new JsonResult("Some Error Occured.");
            }
        }



        //DELETE A RECORD
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = new Book(Configuration.GetConnectionString("DefaultConnection"));
            
            try
            {
            
               int rowAffected = await Task.Run(()=> book.Delete(id));

                return (rowAffected==0) ? 
                    new JsonResult("No rows affected") : 
                    new JsonResult("Successfully Deleted," + rowAffected + " Rows Affected"); 

               
                
            }
            catch
            {
                return new JsonResult("Some Error Occured");
            }

           

        }
       
    }



   
}
