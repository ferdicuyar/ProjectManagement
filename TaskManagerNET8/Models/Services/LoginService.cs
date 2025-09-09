using Blazored.SessionStorage;
using DocumentFormat.OpenXml.Bibliography;
using System.Security.Cryptography;
using System.Text;
using TaskManagerNET8.Models.Database.Project;
using TaskManagerNET8.Models.Helpers.LoginHelpers;
using TaskManagerNET8.Models.Services.Abstract;

namespace TaskManagerNET8.Models.Services
{
    public class LoginService : ILoginService
    {
        private readonly ISessionStorageService session;
        private readonly ProjectContext db;
        public LoginService(ISessionStorageService _session, ProjectContext _db)
        {
            session = _session;
            db = _db;
        }
        public void Logout()
        {
            session.RemoveItemAsync("login");
        }
        public async Task<SessionModel> Login(User data)
        {
            SessionModel sdata = new SessionModel();
            string password = Salter(data.Password);
            User theUser = db.Users.FirstOrDefault(x => x.UserName == data.UserName && x.Password == password);
            if (theUser != null&&!theUser.Deleted)
            {
                sdata.Message = "success";
                sdata.TheUser = theUser;

                await session.SetItemAsync("login", sdata);
            }
            else
            {
                sdata.Message = "Authorization is refused";
            }
            return sdata;
        }

        public async Task<SessionModel> UserUpdate(User data)
        {
            User model = db.Users.FirstOrDefault(x => x.Id == data.Id);
            model.UserName = data.UserName;
            model.Password = Salter(data.Password);
            db.Users.Attach(model);
            db.Entry(model).Property(x => x.UserName).IsModified = true;
            db.Entry(model).Property(x => x.Password).IsModified = true;
            db.SaveChanges();
            SessionModel sdata = new SessionModel();
            sdata.Message = "approved";
            sdata.TheUser = model;

            await session.SetItemAsync("login", sdata);
            return sdata;
        }


        public List<User> AddUser(User user,string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                user.Password = Salter(password);
            }
            if (user.Id == null || (user.Id != null && user.Id == 0))
            {
                db.Users.Add(user);
            }
            else
            {
                db.Users.Update(user);
            }
            db.SaveChanges();
            return GetUsers();
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        string Salter(string veri)
        {
            using var sha256 = SHA256.Create();
            string tuz = "GüçlüBirTuz123!"; 
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(veri + tuz));
            return Convert.ToBase64String(hashBytes);
        }
    }
}
