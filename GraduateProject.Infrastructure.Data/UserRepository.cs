using GraduateProject.Domain.Core;
using GraduateProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraduateProject.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            
            return _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public User GetUser(Guid userId)
        {
            return _context.Users.Find(userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
