using TaskManagerNET8.Models.Database.Project;
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
        public List<Project> DedicatedOngoingProjects(int userId)
        {
            List<ProjectUser> dedicatedData=db.ProjectUsers.Where(x=>x.UserId== userId).ToList();
            List<int> projectIds=dedicatedData.GroupBy(x=>x.ProjectId).Select(x=>x.Key).ToList();
            List<Project> projects = db.Projects.Where(x=>!x.Finished&&projectIds.Contains(x.Id)).ToList();
            return projects;
        }
    }
}
