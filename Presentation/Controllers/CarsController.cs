using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route ("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CarsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            try
            {
                var cars = _manager.CarServices.GetAllCars(false);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{vinNumber:string}")]
        public IActionResult GetOneCar([FromRoute(Name = "vinNumber")] string vinNumber)
        {
            try
            {
                var car = _manager.CarServices.GetOneCarByVinNumber(vinNumber, false);
                if (car is null)
                    return NotFound();
                return Ok(car);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        [HttpPost]
        public IActionResult CreateOneCars([FromBody] Car car)
        {
            try
            {
                if (car is null)
                    return BadRequest();
                _manager.CarServices.CreateOneCar(car);
                return StatusCode(201, car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{vinNumber:string}")]
        public IActionResult UpdateOneCar([FromRoute(Name = "vinNumber")] string vinNumber, [FromBody] Car car)
        {
            try
            {
                if (car is null)
                    return BadRequest(); //400
                _manager.CarServices.UpdateOneCar(vinNumber, car, true);
                return NoContent(); //204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{vinNumber:string}")]
        public IActionResult DeleteOneCar([FromRoute(Name = "vinNumber")] string vinNumber)
        {
            try
            {
                _manager.CarServices.DeleteOneCar(vinNumber, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
