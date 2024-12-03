using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateOneDealership([FromBody] Dealership dealership) {
            try
            {
                if (dealership is null)
                    return BadRequest();
                _manager.DealershipServices.CreateOneDealership(dealership);
                return StatusCode(201, dealership);
            }
            catch (Exception ex){ 
            return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOneDealership([FromRoute(Name = "id")] int id, [FromBody] Dealership dealership)
        {
            try
            {
                if (dealership is null)
                    return BadRequest();
                _manager.DealershipServices.UpdateOneDealership(id, dealership, true);
                return NoContent();

            }
            catch (Exception ex) { 
            throw new Exception(ex.Message);
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
