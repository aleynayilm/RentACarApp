using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public PaymentsController(IServiceManager manager) { 
        _manager = manager;
        }
        [HttpGet]
        public IActionResult GetAllPayments() {
            try
            {
                var payments = _manager.PaymentServices.GetAllPayments(false);
                return Ok(payments);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOnePaymentById([FromRoute(Name ="id")] int id) {
            try
            {
                var payment = _manager.PaymentServices.GetOnePaymentById(id, false);
                if (payment is null)
                    return NotFound();
                return Ok(payment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOnePayment([FromBody] PaymentDtoForCreate paymentDto) {
            try
            {
                if (paymentDto is null)
                    return BadRequest();
                _manager.PaymentServices.CreateOnePayment(paymentDto);
                return StatusCode(201, paymentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOnePayment([FromRoute(Name ="id")] int id,[FromBody] PaymentDtoForUpdate paymentDto) {
            try
            {
                if (paymentDto is null)
                    return BadRequest(); 
                _manager.PaymentServices.UpdateOnePayment(id, paymentDto, true);
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
        public IActionResult DeleteOnePayment([FromRoute(Name ="id")] int id) {
            try
            {
                _manager.PaymentServices.DeleteOnePayment(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
