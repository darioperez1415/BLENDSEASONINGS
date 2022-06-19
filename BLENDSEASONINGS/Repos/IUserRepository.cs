using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(string id);
        void AddUser(User newUser);
        void UpdateUser(User user);
        void DeleteUser(string id);
    }
}
