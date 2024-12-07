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
    [Route("api/deleteds")]
    [ApiController]
    public class DeletedsController:ControllerBase
    {
        private readonly IServiceManager _manager;
        public DeletedsController(IServiceManager manager)
        {
            _manager = manager;
        }

        // GET: api/Deleted
        [HttpGet]
        public IActionResult GetAllDeleteds()
        {
            var deleteds = _manager.DeletedServices.GetAllDeleteds(trackChanges: false);
            return Ok(deleteds);
        }

        // GET: api/Deleted/{id}
        [HttpGet("{id}")]
        public IActionResult GetOneDeletedById(int id)
        {
            var deleted = _manager.DeletedServices.GetOneDeletedById(id, trackhanges: false);
            if (deleted == null)
            {
                return NotFound($"Deleted record with id: {id} not found.");
            }
            return Ok(deleted);
        }

        // POST: api/Deleted
        [HttpPost]
        public IActionResult CreateOneDeleted([FromBody] Deleted deleted)
        {
            if (deleted == null)
            {
                return BadRequest("Deleted object is null.");
            }

            var createdDeleted = _manager.DeletedServices.CreateOneDeleted(deleted);
            return CreatedAtAction(nameof(GetOneDeletedById), new { id = createdDeleted.Id }, createdDeleted);
        }

        // PUT: api/Deleted/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOneDeleted(int id, [FromBody] Deleted deleted)
        {
            if (deleted == null)
            {
                return BadRequest("Deleted object is null.");
            }

            _manager.DeletedServices.UpdateOneDeleted(id, deleted, trackChanges: true);
            return NoContent();
        }

        // DELETE: api/Deleted/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOneDeleted(int id)
        {
            _manager.DeletedServices.DeleteOneDeleted(id, trackChanges: false);
            return NoContent();
        }
    }
}
