using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Kursach.Models.Repository
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(IConfiguration config) : base(config) { }

        public IEnumerable<ProjectModel> GetAllProjectsOfUser(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<ProjectModel>($@"
select	p.Project     	{nameof(ProjectModel.Project)},
		p.ProjectName	{nameof(ProjectModel.ProjectName)},
        p.Cost          {nameof(ProjectModel.Cost)},
		p.Deadline	    {nameof(ProjectModel.Deadline)},
        p.IsDone        {nameof(ProjectModel.IsDone)},
        p.AuthorId      {nameof(ProjectModel.AuthorId)}
from UsersInProjects up
	join Projects p on up.ProjectId = p.Project
where up.UserId = @{nameof(userId)}
", new { userId });
            }
        }

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
        AuthorId          {nameof(ProjectModel.AuthorId)}
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

        public void UpdateStepOfDevelopmentStatus(int stepId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
update	StepsOfDevelopment   
set EndDate	= GETDATE()
where StepOfDevelopment = @{nameof(stepId)}
", new { stepId });
            }
        }
    }
}
