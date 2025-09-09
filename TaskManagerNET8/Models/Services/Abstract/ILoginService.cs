using TaskManagerNET8.Models.Database.Project;
using TaskManagerNET8.Models.Helpers.LoginHelpers;

namespace TaskManagerNET8.Models.Services.Abstract
{
    public interface ILoginService
    {
        void Logout();
        Task<SessionModel> Login(User data);
        Task<SessionModel> UserUpdate(User data);
        List<User> GetUsers();
        List<User> AddUser(User user, string password);
    }
}
