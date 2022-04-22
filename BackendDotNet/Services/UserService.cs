using System;
using System.Collections.Generic;
using BackendDotNet.Data;
using BackendDotNet.Models;
using BackendDotNet.Services.Interface;
using BackendDotNet.Repositories.Interface;

namespace BackendDotNet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser(User user)
        {
            try
            {
                var users = _userRepository.GetUsers();
                // business logic - check duplicate user
                if(users.Contains(user))
                {
                    throw new Exception("user is already in system");
                }
                else
                {
                    _userRepository.CreateUser(user);
                }
            }
            catch(Exception ex)
            {
            throw ex;
            }
        }

        public void DeleteUser(int id)
        {
            try
                {
                    var user = _userRepository.GetUserById(id);
                    if(user != null)
                    {
                        _userRepository.DeleteUser(user);
                    }
                }
            catch(Exception ex)
            {
            throw ex;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return _userRepository.GetUserById(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return _userRepository.GetUsers();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _userRepository.UpdateUser(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}