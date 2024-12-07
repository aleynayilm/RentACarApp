using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/cars")]
    [ApiController]
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

        [HttpGet("{vinNumber}")]
        public IActionResult GetOneCarByVinNumber([FromRoute(Name = "vinNumber")] string vinNumber)
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
        public IActionResult CreateOneCar([FromBody] CarDtoForCreate carDto)
        {
            try
            {
                if (carDto is null)
                    return BadRequest();
                _manager.CarServices.CreateOneCar(carDto);
                return StatusCode(201, carDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{vinNumber}")]
        public IActionResult UpdateOneCar([FromRoute(Name = "vinNumber")] string vinNumber, [FromBody] CarDtoForUpdate carDto)
        {
            try
            {
                if (carDto is null)
                    return BadRequest(); //400
                _manager.CarServices.UpdateOneCar(vinNumber, carDto, true);
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
        [HttpDelete("{vinNumber}")]
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
