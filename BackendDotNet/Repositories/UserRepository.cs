using System.Collections.Generic;
using System.Linq;
using BackendDotNet.Data;
using BackendDotNet.Models;
using BackendDotNet.Repositories.Interface;

namespace BackendDotNet.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateUser(User user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _databaseContext.Users.Remove(user);
            _databaseContext.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _databaseContext.Users.SingleOrDefault(o => o.Id == id);
        }

        public List<User> GetUsers()
        {
            return _databaseContext.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _databaseContext.Users.Update(user);
            _databaseContext.SaveChanges();
        }
    }
}