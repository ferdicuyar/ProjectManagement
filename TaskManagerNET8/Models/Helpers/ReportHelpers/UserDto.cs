using TaskManagerNET8.Models.Database.Project;

namespace TaskManagerNET8.Models.Helpers.ReportHelpers
{
    public class UserDto
    {
        public int Id { get; set; }
        public string LongName { get; set; }
        public UserDto()
        {
            
        }
        public UserDto(User data)
        {
            Id= data.Id;    
            LongName= data.LongName;
        }
    }
}
