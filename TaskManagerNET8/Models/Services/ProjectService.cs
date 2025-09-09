using TaskManagerNET8.Models.Database.Project;
using TaskManagerNET8.Models.Helpers.ReportHelpers;
using TaskManagerNET8.Models.Services.Abstract;

namespace TaskManagerNET8.Models.Services
{
    public class ProjectService : IProjectService
    {
        readonly ProjectContext db;
        public ProjectService(ProjectContext _db)
        {
            db = _db;
        }
        public List<ProjectDto> DedicatedOngoingProjects(int userId)
        {
            List<ProjectUser> dedicatedData=db.ProjectUsers.Where(x=>x.UserId== userId).ToList();
            List<int> projectIds=dedicatedData.GroupBy(x=>x.ProjectId).Select(x=>x.Key).ToList();
            List<Project> projects = db.Projects.Where(x=>!x.Finished&&projectIds.Contains(x.Id)).ToList();
            List<ProjectUser> projectUsers= db.ProjectUsers.Where(x => projectIds.Contains(x.ProjectId)).ToList();
            List<int> memberIds = projectUsers.GroupBy(x => x.UserId).Select(x => x.Key).ToList();
            List<User> users = db.Users.Where(x => memberIds.Contains(x.Id)).ToList();
            List<ProjectDto> data = projects.Select(x => new ProjectDto(x, users.Where(u => projectUsers.Where(p => p.ProjectId == x.Id).GroupBy(up => up.UserId).Select(up => up.Key).Contains(u.Id)).ToList())).ToList();
            return data;
        }
    }
}
