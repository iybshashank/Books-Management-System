using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MiddleTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PlWebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        public IConfiguration Configuration { get; }

        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<List<object>>> Get(string username, string password)
        {
            try
            {
                Users us = new Users(Configuration.GetConnectionString("DefaultConnection"),username,password);
                bool isUser = await Task.Run( () => us.getUser());


                if (isUser) { 
                    List<object> user = new List<object> {us.user,us.isAdmin };
                    return user;
                }
                else
                {
                    return new JsonResult("User Not Found");            
                }
            }
            catch(Exception ex)
            {
                return new JsonResult($"Some error occured: {ex.Message}");
            }
        }
    }
}
