using System.Collections.Generic;

namespace Kursach.Models.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<ProjectModel> GetProjects(int userId);

        IEnumerable<StepOfDevelopmentModel> GetStepsOfDevelopmentByProjectId(int projectId);
    }
}
