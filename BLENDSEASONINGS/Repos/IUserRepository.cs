using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IUserRepository
    {
        public void CreateUser(User user);
        public User GetUserById(string id);
        public bool CheckUserExists(string id);
    }
}
