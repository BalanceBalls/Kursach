using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Kursach.Models;

/*Система по ведению учета процесса разработки, включая сроки выполнения,
 * стоимость услуг, этапов разработки (система многопользовательская)*/
namespace Kursach.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));


        public IActionResult Index()
        {


            return View();
        }

        public IActionResult GetUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();
                var users = conn.Query<User>($@"
                                        select	id,
                                                name,
                                                password
                                        from Users
                                       ");
                return View(users);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
