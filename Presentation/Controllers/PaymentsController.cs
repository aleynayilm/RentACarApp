using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateOnePayment([FromBody] Payment payment) {
            try
            {
                if (payment is null)
                    return BadRequest();
                _manager.PaymentServices.CreateOnePayment(payment);
                return StatusCode(201, payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOnePayment([FromRoute(Name ="id")] int id,[FromBody] Payment payment) {
            try
            {
                if (payment is null)
                    return BadRequest(); 
                _manager.PaymentServices.UpdateOnePayment(id, payment, true);
                return NoContent(); //204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
