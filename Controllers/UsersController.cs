using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuxuryCars.Models;
using LuxuryCars.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LuxuryCars.Controllers
{
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly ILCRepository _repository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILCRepository repository, ILogger<UsersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllUsers());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get users: {ex}");
                return BadRequest("Failed to get users");
            }
        }

        [HttpGet]
        [Route("getUserById/{id}")]
        public IActionResult GetUserbyId([FromRoute] string id)
        {
            try
            {
                return Ok(_repository.GetUserById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get user by id: {ex}");
                return null;
            }
        }

        [HttpPost]
        [Route("updateUser")]
        public bool UpdateUser([FromBody] User user)
        {
            try
            {
                _repository.UpdateUser(user);
                _repository.SaveAll();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get user by id: {ex}");
                return false;
            }
        }

    }
}