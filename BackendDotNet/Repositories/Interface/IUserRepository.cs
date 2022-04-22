using System.Collections.Generic;
using BackendDotNet.Models;

namespace BackendDotNet.Repositories.Interface
{
    public interface IUserRepository
    {
         List<User> GetUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}