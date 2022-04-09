using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackendDotNet.Models;
using Microsoft.EntityFrameworkCore;
using BackendDotNet.Data;

namespace BackendDotNet.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly DatabaseContext _databaseContext;
        public UserController(ILogger<UserController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            // business logic
            try
            {
                var userAll = _databaseContext.Users.ToList();
                return Ok(new { result = userAll, message = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            // business logic
            try
            {
                var _user = _databaseContext.Users.SingleOrDefault(o => o.Id == user.Id);
            if(_user != null)
            {
                _user.Password = user.Password;
            }
            _databaseContext.SaveChanges();

            return Ok(new { message = "success" });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            // business logic
            try
            {
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();;
                return Ok(new { message = "success" });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            // business logic
            try
            {
                var _user = _databaseContext.Users.SingleOrDefault(o => o.Id == id);
                if(_user != null)
                {
                    _databaseContext.Users.Remove(_user);
                    _databaseContext.SaveChanges();
                }
                return Ok(new { message = "success" });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
