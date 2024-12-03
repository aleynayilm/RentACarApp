using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public UsersController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult GetAllUsers() {
            try
            {
                var users = _manager.UserServices.GetAllUsers(false);
                return Ok(users);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOneUserById([FromRoute(Name ="id")] string id) {
            try
            {
                var user = _manager.UserServices.GetOneUserById(id, false);
                if (user is null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        [HttpPost]
        public IActionResult CreateOneUser([FromBody] User user) {
            try
            {
                if (user is null)
                    return BadRequest();
                _manager.UserServices.CreateOneUser(user);
                return StatusCode(201, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOneUser([FromRoute(Name = "id")] string id, [FromBody] User user) {
            try
            {
                if (user is null)
                    return BadRequest(); //400
                _manager.UserServices.UpdateOneUser(id, user, true);
                return NoContent(); //204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOneUser([FromRoute(Name = "id")] string id) {
            try
            {
                _manager.UserServices.DeleteOneUser(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
