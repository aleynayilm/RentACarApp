using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/dealerships")]
    [ApiController]

    public class DealershipsController :ControllerBase
    {
        private readonly IServiceManager _manager;

        public DealershipsController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public IActionResult GetAllDealerships() {
            try
            {
                var dealerships = _manager.DealershipServices.GetAllDealerships(false);
                return Ok(dealerships);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOneDealership([FromRoute(Name ="id")] int id) {
            try
            {
                var dealership = _manager.DealershipServices.GetOneDealershipById(id, false);
                if (dealership is null)
                    return NotFound();
                return Ok(dealership);
            }
            catch(Exception ex) {
            throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOneDealership([FromBody] DealershipDtoForCreate dealershipDto) {
            try
            {
                if (dealershipDto is null)
                    return BadRequest();
                _manager.DealershipServices.CreateOneDealership(dealershipDto);
                return StatusCode(201, dealershipDto);
            }
            catch (Exception ex){ 
            return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOneDealership([FromRoute(Name = "id")] int id, [FromBody] DealershipDtoForUpdate dealershipDto)
        {
            try
            {
                if (dealershipDto is null)
                    return BadRequest();
                _manager.DealershipServices.UpdateOneDealership(id, dealershipDto, true);
                return NoContent();

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
        public IActionResult DeleteOneDealership([FromRoute(Name ="id")] int id)
        {
            try
            {
                _manager.DealershipServices.DeleteOneDealership(id, false);
                return NoContent();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
