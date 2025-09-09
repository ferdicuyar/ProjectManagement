using TaskManagerNET8.Models.Database.Project;
using TaskManagerNET8.Models.Helpers.ReportHelpers;

namespace TaskManagerNET8.Models.Services.Abstract
{
    public interface IProjectService
    {
        List<ProjectDto> DedicatedOngoingProjects(int userId);
        List<Technology> GetTechs();
        List<Technology> AddTechs(Technology newTech);
    }
}
