using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Kursach.Models;
using Microsoft.AspNetCore.Authorization;
using Kursach.Models.Repository;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

/*Система по ведению учета процесса разработки, включая сроки выполнения,
 * стоимость услуг, этапов разработки (система многопользовательская)*/
namespace Kursach.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IProjectRepository projectRepository, IHttpContextAccessor httpContextAccessor)
        {
            _projectRepository = projectRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;//получаем ID пользователя из куков

            var projects = _projectRepository.GetAllProjectsOfUser(int.Parse(userId));

            foreach (var proj in projects)
            {
                proj.Steps = new List<StepOfDevelopmentModel>();
                var steps = _projectRepository.GetStepsOfDevelopmentByProjectId(proj.Project);
                foreach (var step in steps)
                {
                    proj.Steps.Add(step);
                }
            }

            return View(projects);
        }

        public IActionResult UpdateStepStatus(int stepId)
        {
            this._projectRepository.UpdateStepOfDevelopmentStatus(stepId);
            return RedirectToAction("Index","Home");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            return NotFound();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
