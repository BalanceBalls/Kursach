using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
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

        public IEnumerable<UserModel> GetUsersInfo()
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<UserModel>($@"
select	id                  {nameof(UserModel.Id)},
		Name		        {nameof(UserModel.Name)},
        Email         {nameof(UserModel.Email)}
from    Users
");
            }
        }

        public void WriteUsersToProject(int projectId, int userId)
        {
           

                using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
insert into	UsersInProjects  (ProjectId, UserId) 
values
(  
    @{nameof(projectId)},
    @{nameof(userId)}
)
", new { projectId, userId });
            }
        }

        public void UpdateProjectStatus(int projectId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
update	Projects   
set IsDone	= 1
where Project = @{nameof(projectId)}
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

        public void WriteNewStep(string Name, string Description, int ProjectId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
insert into	StepsOfDevelopment  (Name, Description, EndDate, ProjectId) 
values
(  
    @{nameof(Name)},
    @{nameof(Description)},
    null,
    @{nameof(ProjectId)}
)
", new { Name, Description, ProjectId });
            }
        }

        public IEnumerable<UsersInProjectsModel> GetUsersInProject(int projectId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.Query<UsersInProjectsModel>($@"
select	UserId                 {nameof(UsersInProjectsModel.UserId)}
from    UsersInProjects 
Where ProjectId  = @{nameof(projectId)}
", new { projectId });
            }
        }

        public void RemoveUsersFromProject(int projectId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
delete  from UsersInProjects
Where ProjectId = @{nameof(projectId)}
", new { projectId });
            }
        }

        public void RemoveStep(int stepOfDevelopment)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
delete  from StepsOfDevelopment
Where StepOfDevelopment = @{nameof(stepOfDevelopment)}
", new { stepOfDevelopment });
            }
        }

        public void WriteNewProject(string ProjectName, double Cost, DateTime Deadline, int AuthorId)
        {
            using (var conn = Connection)
            {
                conn.Open();
          
                conn.Execute($@"
insert into	Projects  (ProjectName, Cost, Deadline, IsDone, AuthorId) 
values
(  
    @{nameof(ProjectName)},
    @{nameof(Cost)},
    @{nameof(Deadline)},
    0,
    @{nameof(AuthorId)}
)
", new { ProjectName, Cost, Deadline, AuthorId });
                conn.Execute($@"
insert into UsersInProjects  (ProjectId, UserID) 
values
(  
    (select top 1 Project from Projects
order by Project desc),
    @{nameof(AuthorId)}
   
)
", new { AuthorId });
            }
        }
    }
}
