using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Kursach.Models;
using Microsoft.AspNetCore.Authorization;
using Kursach.Models.Repository;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;

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

        public IActionResult UpdateProjStatus(int projectId)
        {
            this._projectRepository.UpdateProjectStatus(projectId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddUserView(int projectId, string projectName)
        {
            ViewData["ProjectId"] = projectId;
            ViewData["ProjectName"] = projectName;
            ViewData["Users"] = this._projectRepository.GetUsersInfo();
            ViewData["SubscribedUsers"] = this._projectRepository.GetUsersInProject(projectId);

            return View("AddUserToProject");
        }

        public IActionResult SubscribeUsersToProject(int projectId, int[] userlist)
        {
            this._projectRepository.RemoveUsersFromProject(projectId);
            foreach (int User in userlist)
            {
                this._projectRepository.WriteUsersToProject(projectId, User);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveStepFromProject(int stepID)
        {

            this._projectRepository.RemoveStep(stepID);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddStep(int projectId , string projectName)
        {
            ViewData["ProjectId"] = projectId;
            ViewData["ProjectName"] = projectName;
            return View("AddStepOfDevelopment");
        }
        public IActionResult WriteNewStep(string Name, string Description, int ProjectId)
        {
            this._projectRepository.WriteNewStep(Name, Description, ProjectId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return NotFound();
        }

        public IActionResult AddProject()
        {
            return View("AddProject");
        }

        public IActionResult CreateNewProject(string ProjectName, double Cost, DateTime Deadline, int AuthorId)
        {
            this._projectRepository.WriteNewProject(ProjectName, Cost, Deadline, AuthorId);

            return RedirectToAction("Index", "Home");
        }
    }
}
