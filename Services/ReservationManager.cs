using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
    public class ReservationManager : IReservationServices
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerServices _logger;
        public ReservationManager(IRepositoryManager manager, IMapper mapper, ILoggerServices logger)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
        }

        public Reservation CreateOneReservation(ReservationsDtoForCreate reservationDto)
        {
            try
            {
                _logger.LogInfo($"CreateOneReservation started for UserId: {reservationDto.UserId}, CarId: {reservationDto.CarId}");
                var user = _manager.UserR.GetUser(reservationDto.UserId);
            if (user == null)
            {
                throw new Exception($"UserId '{reservationDto.UserId}' not found!");
            }
            var car= _manager.CarR.GetCar(reservationDto.CarId);
            if (car == null)
            {
                throw new Exception($"CarId '{reservationDto.CarId}' not found!");
            }
            var status = _manager.ResrvationStatusR.GetReservationStatus(reservationDto.Status);
            if (status == null)
            {
                throw new Exception($"Status '{reservationDto.Status}' not found!");
            }

            var reservation = _mapper.Map<Reservation>(reservationDto);

            reservation.UserId = user.Id;
            reservation.CarId = car.VinNumber;
            reservation.Status = status.Id;
                if (reservation == null)
                {
                    string error = "Reservation mapping failed!";
                    _logger.LogError(error);
                    throw new ArgumentNullException(nameof(reservation));
                }
                _manager.ReservationR.CreateOneReservation(reservation);
            _manager.Save();
                _logger.LogInfo($"Reservation created successfully for UserId: {reservation.UserId}, CarId: {reservation.CarId}");
                return reservation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"CreateOneReservation failed: {ex.Message}");
                throw;
            }
        }

        public void DeleteOneReservation(int id, bool trackChanges)
        {
            try
            {
                _logger.LogInfo($"DeleteOneReservation started for ReservationId: {id}");
                var entity = _manager.ReservationR.GetOneReservationById(id, trackChanges);
            if (entity is null)
                throw new Exception($"Reservation with id:{id} could not found");
            _manager.ReservationR.DeleteOneReservation(entity);
            _manager.Save();
                _logger.LogInfo($"Reservation with id:{id} deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteOneReservation failed for ReservationId: {id}: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Reservation> GetAllReservations(bool trackChanges)
        {
            _logger.LogInfo("GetAllReservations started");
            var reservations = _manager.ReservationR.GetAllReservations(trackChanges);
            _logger.LogInfo($"GetAllReservations completed with {reservations.Count()} reservations");
            return reservations;
        }

        public Reservation GetOneReservationById(int id, bool trackChanges)
        {
            _logger.LogInfo($"GetOneReservationById started for ReservationId: {id}");
            var reservation = _manager.ReservationR.GetOneReservationById(id, trackChanges);
            _logger.LogInfo($"GetOneReservationById completed for ReservationId: {id}");
            return reservation;
        }

        public void UpdateOneReservation(int id, ReservationDtoForUpdate reservationDto, bool trackChanges)
        {
            try
            {
                _logger.LogInfo($"UpdateOneReservation started for ReservationId: {id}");
                var entity = _manager.ReservationR.GetOneReservationById(id, trackChanges: true);
            if (entity is null)
            {
                string message = $"The reservation with id:{id} could not found";
                    _logger.LogError(message);
                    throw new Exception(message);

            }
            if (reservationDto is null)
                throw new ArgumentNullException(nameof(reservationDto));
            var existingCreatedDate = entity.CreatedDate;

            _mapper.Map(reservationDto, entity);
            //entity = _mapper.Map<Reservation>(reservationDto);
            entity.CreatedDate = existingCreatedDate;
            _manager.ReservationR.UpdateOneReservation(entity);
            _manager.Save();
                _logger.LogInfo($"Reservation with id:{id} updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateOneReservation failed for ReservationId: {id}: {ex.Message}");
                throw;
            }
        }
    }
}
