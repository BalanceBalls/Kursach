using System.Collections.Generic;
using System;
namespace Kursach.Models.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<ProjectModel> GetProjects(int userId);

        IEnumerable<StepOfDevelopmentModel> GetStepsOfDevelopmentByProjectId(int projectId);

        IEnumerable<ProjectModel> GetAllProjectsOfUser(int userId);

        void UpdateStepOfDevelopmentStatus(int stepId);

        void UpdateProjectStatus(int projectId);

        void WriteNewStep(string Name, string Description, int ProjectId);

        IEnumerable<UserModel> GetUsersInfo();

        IEnumerable<UsersInProjectsModel> GetUsersInProject(int projectId);

        void RemoveUsersFromProject(int projectId);

        void RemoveStep(int stepOfDevelopment);

        void WriteUsersToProject(int projectId, int userId);

        void WriteNewProject(string ProjectName , double Cost, DateTime Deadline ,int AuthorId);
    }
}
