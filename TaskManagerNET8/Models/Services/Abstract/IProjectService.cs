using TaskManagerNET8.Models.Database.Project;

namespace TaskManagerNET8.Models.Services.Abstract
{
    public interface IProjectService
    {
        List<Project> DedicatedOngoingProjects(int userId);
    }
}
