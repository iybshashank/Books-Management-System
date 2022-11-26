using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using MiddleTier;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; }

        



        public HomeController(IConfiguration configuration,ILogger<HomeController> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            ViewBag.uName = HttpContext.Session.GetString("s_name");
            ViewBag.uIsAdmin = HttpContext.Session.GetInt32("s_isAdmin") == 1 ? true : false;
            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"));
            DataSet ds = obj.Load();
            
            ViewBag.uName = HttpContext.Session.GetString("s_name");
            ViewBag.isAdmin = HttpContext.Session.GetInt32("s_isAdmin") == 1 ? true : false;
            return View(ds);
        }

        public IActionResult Login(string user, string password)
        {
            try
            {
            Users obj = new Users(Configuration.GetConnectionString("DefaultConnection"));
            obj.user = user;
            obj.password = password;

            if (obj.getUser())
            {
                HttpContext.Session.SetString("s_name", obj.user);
                HttpContext.Session.SetInt32("s_isAdmin",Convert.ToInt32(obj.isAdmin));
                
                //return RedirectToAction("Home",new {user=obj.user,isAdmin=obj.isAdmin });
                return RedirectToAction(nameof(Home));
            }
            return RedirectToAction(nameof(Index));

            }
            catch(Exception ex)
            {
                return Content($"Some error occured:");
            }

        }

        public ActionResult Delete()
        {
            int id =Convert.ToInt32(Request.Form["bookID"]);
            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"));
            
            obj.Delete(id);
           
            return RedirectToAction(nameof(Home));

        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Createb(string bName,string bAuthor,string bYear,string bDescription,string bISBN)
        {
            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"),bName, bAuthor, Convert.ToInt32(bYear), bDescription, Convert.ToInt32(bISBN));

            try {
                obj.Save();
            }
            catch(Exception ex)
            {

                return Content($"Some error occured");
            }

            return RedirectToAction(nameof(Home));
        }

        public IActionResult Update()
        {
            
            int nm =Convert.ToInt32(Request.Form["bookID"]);
            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"));
            DataSet ds=obj.Load(nm);
            ViewBag.bID = ds.Tables[0].Rows[0]["ID"];
            ViewBag.bName = ds.Tables[0].Rows[0]["Book"];
            ViewBag.bAuthor = ds.Tables[0].Rows[0]["Author"];
            ViewBag.bYear = ds.Tables[0].Rows[0]["Year"];
            ViewBag.bISBN = ds.Tables[0].Rows[0]["ISBN"];
            ViewBag.bDescription = ds.Tables[0].Rows[0]["Description"];
            return View();
        }

        public IActionResult Updateb(int ID,string bName, string bAuthor, string bYear, string bDescription, string bISBN)
        {

            Book obj = new Book(Configuration.GetConnectionString("DefaultConnection"),ID,bName, bAuthor, Convert.ToInt32(bYear), bDescription, Convert.ToInt32(bISBN));

            try
            {
                obj.Update();
            }
            catch(Exception ex)
            {

                return Content($"Some error occured:");
            }




            return RedirectToAction(nameof(Home));
        }


       





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
