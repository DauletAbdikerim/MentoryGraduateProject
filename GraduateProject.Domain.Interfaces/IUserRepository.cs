using GraduateProject.Domain.Core;

namespace GraduateProject.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByLoginAndPassword(string login, string password);
        User GetUser(Guid userId);
        IEnumerable<User> GetUsers();
        void UpdateUser(User user);

    }
}
