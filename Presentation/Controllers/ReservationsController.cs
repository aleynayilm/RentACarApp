﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public ReservationsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllReservations() {
            try
            {
                var reservations = _manager.ReservationServices.GetAllReservations(false);
                return Ok(reservations);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetOneReservation([FromRoute(Name = "id")] int id)
        {
            try
            {
                var reservation = _manager.ReservationServices.GetOneReservationById(id, false);
                if (reservation is null)
                    return NotFound();
                return Ok(reservation);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOneReservation([FromBody] Reservation reservation) {
            try
            {
                if (reservation is null)
                    return BadRequest();
                _manager.ReservationServices.CreateOneReservation(reservation);
                return StatusCode(200, reservation);
            }
            catch (Exception ex) {
            return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOneReservation([FromRoute(Name = "id")] int id, [FromBody] Reservation reservation) {
            try
            {
                if (reservation is null)
                    return BadRequest();
                _manager.ReservationServices.UpdateOneReservation(id, reservation, true);
                return NoContent();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOneReservation([FromRoute(Name = "id")] int id) {
            try
            {
                _manager.ReservationServices.DeleteOneReservation(id, false);
                return NoContent();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}