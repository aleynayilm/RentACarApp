using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UsersController> _logger;
        public UsersController(IServiceManager manager, ILogger<UsersController> logger)
        {
            _manager = manager;
            _logger = logger;
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
        public IActionResult CreateOneUser([FromBody] UserDtoForCreate userDto) {
            try
            {
                if (userDto is null)
                    return BadRequest();
                _manager.UserServices.CreateOneUser(userDto);
                return StatusCode(201, userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOneUser([FromRoute(Name = "id")] string id, [FromBody] UserDtoForUpdate userDto) {
            try
            {
                if (userDto is null)
                    return BadRequest(); //400
                _manager.UserServices.UpdateOneUser(id, userDto, true);
                return NoContent(); //204
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Veritabanı hatası: {dbEx.Message}");
                return StatusCode(500, "Veritabanında bir hata oluştu.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Genel hata: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
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
