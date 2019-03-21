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
using Microsoft.AspNetCore.Authorization;

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
        //<ItemGroup>
        //  <Compile Remove = "Models\Class.cs" />
        //  < Compile Remove="Models\Project.cs" />
        //</ItemGroup>

        //[Authorize]
        public IActionResult Index()
        {
            using (var conn = Connection)
            {
                var sqlQuery = "SELECT * FROM Projects";
               
                conn.Open();
                var projects = conn.Query<ProjectModel>(sqlQuery);

                foreach (var proj in projects)
                {
                    var sql = $"select * from StepsOfDevelopment WHERE ProjectId={proj.Project}";
                    var steps = conn.Query<StepOfDevelopmentModel>(sql);
                    proj.Steps = new List<StepOfDevelopmentModel>();
                    foreach (var st in steps)
                    {
                        proj.Steps.Add(st);
                    }
                }
                

                return View(projects);
            }
        }

        public IActionResult GetUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();
                var users = conn.Query<UserModel>($@"
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
            using (var conn = Connection)
            {
                conn.Open();
                var steps = conn.Query<StepOfDevelopmentModel>($@"
                                        select	StepOfDevelopment,
                                                Name,
                                                Description,
                                                EndDate, 
                                                ProjectId
                                        from StepsOfDevelopment
                                       ");
                return View(steps);
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
