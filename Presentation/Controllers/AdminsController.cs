using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public AdminsController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            try
            {
                var admins = _manager.AdminServices.GetAllAdmins(false);
                return Ok(admins);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOneAdminById([FromRoute(Name = "id")] string id)
        {
            try
            {
                var admin = _manager.AdminServices.GetOneAdminById(id, false);
                if (admin is null)
                    return NotFound();
                return Ok(admin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        [HttpPost]
        public IActionResult CreateOneAdmin([FromBody] AdminDtoForCreate adminDto)
        {
            try
            {
                if (adminDto is null)
                    return BadRequest();
                _manager.AdminServices.CreateOneAdmin(adminDto);
                return StatusCode(201, adminDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOneAdmin([FromRoute(Name = "id")] string id, [FromBody] AdminDtoForUpdate adminDto)
        {
            try
            {
                if (adminDto is null)
                    return BadRequest(); //400
                _manager.AdminServices.UpdateOneAdmin(id, adminDto, true);
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
        public IActionResult DeleteOneAdmin([FromRoute(Name = "id")] string id)
        {
            try
            {
                _manager.AdminServices.DeleteOneAdmin(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
