using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Kursach.Models.Repository
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(IConfiguration config) : base(config) { }

        public IEnumerable<ProjectModel> GetProjects(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<ProjectModel>($@"
select	Project     	{nameof(ProjectModel.Project)},
		ProjectName		{nameof(ProjectModel.ProjectName)},
        Cost            {nameof(ProjectModel.Cost)},
		Deadline	    {nameof(ProjectModel.Deadline)},
        IsDone          {nameof(ProjectModel.IsDone)},
        UserId          {nameof(ProjectModel.UserId)}
from	Projects
where   UserId = @{nameof(userId)}
", new { userId });
            }
        }

        public IEnumerable<StepOfDevelopmentModel> GetStepsOfDevelopmentByProjectId(int projectId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<StepOfDevelopmentModel>($@"
select	StepOfDevelopment   {nameof(StepOfDevelopmentModel.StepOfDevelopment)},
		Name		        {nameof(StepOfDevelopmentModel.Name)},
        Description         {nameof(StepOfDevelopmentModel.Description)},
		EndDate	            {nameof(StepOfDevelopmentModel.EndDate)},
        ProjectId           {nameof(StepOfDevelopmentModel.ProjectId)}
from	StepsOfDevelopment
where   ProjectId = @{nameof(projectId)}
", new { projectId });
            }
        }
    }
}
