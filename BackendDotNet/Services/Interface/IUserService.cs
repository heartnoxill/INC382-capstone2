using System.Collections.Generic;
using BackendDotNet.Models;

namespace BackendDotNet.Services.Interface
{
    public interface IUserService
    {
         List<User> GetUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}