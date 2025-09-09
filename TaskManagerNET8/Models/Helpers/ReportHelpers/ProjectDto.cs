using System.ComponentModel.DataAnnotations.Schema;
using TaskManagerNET8.Models.Database.Project;

namespace TaskManagerNET8.Models.Helpers.ReportHelpers
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; } 
        public string ProjectDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool Finished { get; set; }
        public string Owner { get; set; }
        public List<UserDto> Members { get; set; }
        public ProjectDto()
        {
            
        }
        public ProjectDto(Project data, List<User> members)
        {
            Id = data.Id;
            ProjectTitle = data.ProjectTitle;
            ProjectDescription = data.ProjectDescription;
            CreateDate = data.CreateDate;
            Deadline = data.Deadline;
            FinishDate = data.FinishDate;
            Finished = data.Finished;
            Owner = members.FirstOrDefault(x => x.Id == data.OwnerId).LongName;
            Members=members.Select(x=>new UserDto(x)).ToList();
        }
    }
}
